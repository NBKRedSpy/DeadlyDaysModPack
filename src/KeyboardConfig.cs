using BepInEx.Configuration;
using Rewired;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DeadlyDaysModPack
{
    public class KeyboardConfig
    {
        //record KeyBinding(string ActionId, KeyCode Key);

        internal struct KeyBinding
        {
            public string ActionId { get; set; }
            public KeyCode Key { get; set; }
            public KeyBinding(string ActionId, KeyCode Key)
            {
                this.ActionId = ActionId;
                this.Key = Key;
            }

        }


        /// <summary>
        /// Return to bus. Identical to clicking on the bus icon.
        /// </summary>
        public ConfigEntry<KeyboardShortcut> ReturnToBus { get; set; }

        /// <summary>
        /// Remap the UISubmit action.
        /// </summary>
        public ConfigEntry<KeyboardShortcut> UISubmit { get; set; }

        /// <summary>
        /// Remap the UICancel action.
        /// </summary>
        public ConfigEntry<KeyboardShortcut> UICancel { get; set; }

        /// <summary>
        /// Remap the PageRight action.
        /// </summary>
        public ConfigEntry<KeyboardShortcut> PageRight { get; set; }

        /// <summary>
        /// Remap the PageLeft action.
        /// </summary>
        public ConfigEntry<KeyboardShortcut> PageLeft { get; set; }

        /// <summary>
        /// Remap the Menu action.
        /// </summary>
        public ConfigEntry<KeyboardShortcut> Menu { get; set; }

        /// <summary>
        /// Remap the UseSpecialPower1 action.
        /// </summary>
        public ConfigEntry<KeyboardShortcut> UseSpecialPower1 { get; set; }

        /// <summary>
        /// Remap the UseSpecialPower2 action.
        /// </summary>
        public ConfigEntry<KeyboardShortcut> UseSpecialPower2 { get; set; }

        /// <summary>
        /// Remap the UseSpecialPower3 action.
        /// </summary>
        public ConfigEntry<KeyboardShortcut> UseSpecialPower3 { get; set; }

        /// <summary>
        /// Remap the UseAirStrike action.
        /// </summary>
        public ConfigEntry<KeyboardShortcut> UseAirStrike { get; set; }

        /// <summary>
        /// Remap the UseHeal action.
        /// </summary>
        public ConfigEntry<KeyboardShortcut> UseHeal { get; set; }

        /// <summary>
        /// Remap the AttackPosition action.
        /// </summary>
        public ConfigEntry<KeyboardShortcut> AttackPosition { get; set; }

        /// <summary>
        /// Remap the TempPause action.
        /// </summary>
        public ConfigEntry<KeyboardShortcut> TempPause { get; set; }

        /// <summary>
        /// Move the camera left.
        /// </summary>
        public ConfigEntry<KeyboardShortcut> CameraLeft { get; set; }

        /// <summary>
        /// Move the camera right.
        /// </summary>
        public ConfigEntry<KeyboardShortcut> CameraRight { get; set; }

        /// <summary>
        /// Move the camera up.
        /// </summary>
        public ConfigEntry<KeyboardShortcut> CameraUp { get; set; }

        /// <summary>
        /// Move the camera down.
        /// </summary>
        public ConfigEntry<KeyboardShortcut> CameraDown { get; set; }
        public ConfigEntry<KeyboardShortcut> InstantSellKey { get; private set; }
        private Player Player { get; set; }


        public KeyboardConfig(ConfigFile config)
        {

            const string section = "Keyboard";

            ReturnToBus = config.Bind(section, "ReturnToBus", new KeyboardShortcut(KeyCode.Q),
                "Return to bus.  Identical to clicking on the bus icon.");

            UISubmit = config.Bind(section, "UISubmit", new KeyboardShortcut(KeyCode.Return),
                "Remap the UISubmit action.");

            UICancel = config.Bind(section, "UICancel", new KeyboardShortcut(KeyCode.Escape),
                "Remap the UICancel action.");

            PageRight = config.Bind(section, "PageRight", new KeyboardShortcut(KeyCode.E),
                "Remap the PageRight action.");

            PageLeft = config.Bind(section, "PageLeft", new KeyboardShortcut(KeyCode.Q),
                "Remap the PageLeft action.");

            Menu = config.Bind(section, "Menu", new KeyboardShortcut(KeyCode.Escape),
                "Remap the Menu action.");

            UseSpecialPower1 = config.Bind(section, "UseSpecialPower1", new KeyboardShortcut(KeyCode.Alpha3),
                "Remap the UseSpecialPower1 action.");

            UseSpecialPower2 = config.Bind(section, "UseSpecialPower2", new KeyboardShortcut(KeyCode.Alpha4),
                "Remap the UseSpecialPower2 action.");

            UseSpecialPower3 = config.Bind(section, "UseSpecialPower3", new KeyboardShortcut(KeyCode.Alpha5),
                "Remap the UseSpecialPower3 action.");

            UseAirStrike = config.Bind(section, "UseAirStrike", new KeyboardShortcut(KeyCode.Alpha1),
                "Remap the UseAirStrike action.");

            UseHeal = config.Bind(section, "UseHeal", new KeyboardShortcut(KeyCode.Alpha2),
                "Remap the UseHeal action.");

            AttackPosition = config.Bind(section, "AttackPosition", new KeyboardShortcut(KeyCode.LeftControl),
                "Remap the AttackPosition action.");

            TempPause = config.Bind(section, "TempPause", new KeyboardShortcut(KeyCode.Space),
                "Remap the TempPause action.");

            CameraLeft = config.Bind(section, "CameraLeft", new KeyboardShortcut(KeyCode.A),
                "Move the camera left.");

            CameraRight = config.Bind(section, "CameraRight", new KeyboardShortcut(KeyCode.D),
                "Move the camera right.");

            CameraUp = config.Bind(section, "CameraUp", new KeyboardShortcut(KeyCode.W),
                "Move the camera up.");

            CameraDown = config.Bind(section, "CameraDown", new KeyboardShortcut(KeyCode.S),
                "Move the camera down.");

            InstantSellKey = config.Bind("InstantSell", "InstantSellKey", new KeyboardShortcut(KeyCode.Mouse2), 
                "Hotkey to instantly sell the selected in the inventory");

            config.SettingChanged += Config_SettingChanged;
        }

        private void Config_SettingChanged(object sender, SettingChangedEventArgs e)
        {
            RemapButtons();
        }

        public void RemapButtons(Player player)
        {
            Player = player;
            RemapButtons();
        }

        private void RemapButtons()
        {
            RemapButton(Player, "ReturnToBus", ReturnToBus.Value.MainKey);
            RemapButton(Player, "UISubmit", UISubmit.Value.MainKey);
            RemapButton(Player, "UICancel", UICancel.Value.MainKey);
            RemapButton(Player, "PageRight", PageRight.Value.MainKey);
            RemapButton(Player, "PageLeft", PageLeft.Value.MainKey);
            RemapButton(Player, "Menu", Menu.Value.MainKey);
            RemapButton(Player, "UseSpecialPower1", UseSpecialPower1.Value.MainKey);
            RemapButton(Player, "UseSpecialPower2", UseSpecialPower2.Value.MainKey);
            RemapButton(Player, "UseSpecialPower3", UseSpecialPower3.Value.MainKey);
            RemapButton(Player, "UseAirStrike", UseAirStrike.Value.MainKey);
            RemapButton(Player, "UseHeal", UseHeal.Value.MainKey);
            RemapButton(Player, "AttackPosition", AttackPosition.Value.MainKey);
            RemapButton(Player, "TempPause", TempPause.Value.MainKey);
            RemapButton(Player, "CameraHorizontal", CameraRight.Value.MainKey, CameraLeft.Value.MainKey);
            RemapButton(Player, "CameraVertical", CameraUp.Value.MainKey, CameraDown.Value.MainKey);

        }

        /// <summary>
        /// Remaps a button from the game's ReWire settings.
        /// </summary>
        /// <param name="actionName">The text id of the action.  Ex:  CameraVertical</param>
        /// <param name="keyCode">The key code to map to the action.</param>
        /// <param name="keyCodeNegative">The key code to map to the negative action.  Only for the rare 'Axis' actions that have a positive and negative.  Ex: CameraHorizontal positive is left and negative is right. </param>
        private void RemapButton(Player player, string actionName, KeyCode keyCode, KeyCode keyCodeNegative = KeyCode.None)
        {
            ControllerMap map = player.controllers.maps.GetMap(ControllerType.Keyboard, 0,
                                ReInput.mapping.GetMapCategoryId("Default"),
                                ReInput.mapping.GetLayoutId(ControllerType.Keyboard, "Default"));

            int actionId = ReInput.mapping.GetActionId(actionName);

            IEnumerable<ActionElementMap> existingElements = map.ElementMapsWithAction(actionName).ToList();

            foreach (var existingElement in existingElements)
            {
                map.DeleteElementMap(existingElement.id);
            }

            map.ReplaceOrCreateElementMap(new ElementAssignment(keyCode, ModifierKeyFlags.None,
                actionId, Pole.Positive));

            if (keyCodeNegative != KeyCode.None)
            {
                map.ReplaceOrCreateElementMap(new ElementAssignment(keyCodeNegative, ModifierKeyFlags.None,
                    actionId, Pole.Negative));
            }   
        }

    }

}
