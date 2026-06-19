using BepInEx.Configuration;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DeadlyDaysModPack
{
    public class Config
    {

        public ConfigEntry<float> DamageMinScale { get; set; }
        public ConfigEntry<float> DamageMaxScale { get; set; }

        public ConfigEntry<bool> EnableCharacterHotkeys { get; set; }
        public ConfigEntry<bool> EnableDamageDisplayScale { get; set; }
        public ConfigEntry<bool> EnableDpsDisplay { get; set; }
        public ConfigEntry<bool> EnableFoodDelta { get; set; }
        public ConfigEntry<bool> EnableInstantSell { get; set; }
        public ConfigEntry<bool> EnableInventorySort { get; set; }
        public ConfigEntry<bool> EnableKeyBinds { get; set; }
        public ConfigEntry<bool> EnableVehicleSparkleSpeed { get; set; }

        public ConfigEntry<float> VehicleSparkleSpeed { get; set; }

        public List<ConfigEntry<KeyboardShortcut>> CharacterSelectHotkeys { get; set; } = new List<ConfigEntry<KeyboardShortcut>>();

        public Config(ConfigFile config)
        {
            DamageMinScale = config.Bind<float>("DamageDisplayScale", "DamageMinScale", 0.4f, "Minimum scale for damage numbers.");
            DamageMaxScale = config.Bind<float>("DamageDisplayScale", "DamageMaxScale", 0.4f, "Maximum scale for damage numbers.");

            EnableCharacterHotkeys = config.Bind<bool>("CharacterHotkeys", "Enable", true, "Enable character selection hotkeys.");
            EnableDamageDisplayScale = config.Bind<bool>("DamageDisplayScale", "Enable", true, "Enable damage display scale adjustments.");
            EnableDpsDisplay = config.Bind<bool>("DpsDisplay", "Enable", true, "Enable DPS display on weapon inspection.");
            EnableFoodDelta = config.Bind<bool>("FoodDelta", "Enable", true, "Enable food/parts/tools delta tracking in the day summary.");
            EnableInstantSell = config.Bind<bool>("InstantSell", "Enable", true, "Enable instant sell with the configured hotkey.");
            EnableInventorySort = config.Bind<bool>("InventorySort", "Enable", true, "Enable inventory sorting by repair status and level.");
            EnableKeyBinds = config.Bind<bool>("KeyBinds", "Enable", true, "Enable key remapping.");
            EnableVehicleSparkleSpeed = config.Bind<bool>("SparkleSpeed", "Enable", true, "Enable faster sparkle speed vehicles");

            VehicleSparkleSpeed = config.Bind<float>("VehicleSparkleSpeed", "Sparkle Speed", 5f, "The speed multiplier for the sparkle effect on vehicles.  Game defaults to 1");

            AddCharacterHotkeys(config);
        }

        private void AddCharacterHotkeys(ConfigFile configFile)
        {
            for (int i = 0; i < 6; i++)
            {
                ConfigEntry<KeyboardShortcut> shortcut = configFile.Bind<KeyboardShortcut>("CharacterHotkeys", $"SelectCharacter{i + 1}", new KeyboardShortcut(KeyCode.F1 + i), $"Hotkey to select character {i + 1} in a mission");

                CharacterSelectHotkeys.Add(shortcut);
            }
        }
    }
}
