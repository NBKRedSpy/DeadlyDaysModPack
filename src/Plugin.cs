using BepInEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace DeadlyDaysModPack
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {

        public static KeyboardConfig KeyboardConfig { get; private set; }

        public static Config ModConfig { get; private set; }

        public void Awake()
        {
            ModConfig = new Config(Config);
            KeyboardConfig = new KeyboardConfig(Config);

            new Harmony(PluginInfo.PLUGIN_GUID).PatchAll(); 
        }
    }
}
