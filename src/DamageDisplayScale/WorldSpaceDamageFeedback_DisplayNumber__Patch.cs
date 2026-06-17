using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace DeadlyDaysModPack.DamageDisplayScale
{
    /// <summary>
    /// Changes the scale of the damage numbers that pop up when you hit an enemy.  
    /// </summary>
    [HarmonyPatch(typeof(WorldSpaceDamageFeedback), nameof(WorldSpaceDamageFeedback.DisplayNumber))]
    public static class WorldSpaceDamageFeedback_DisplayNumber__Patch
    {
        public static bool Prepare() => Plugin.ModConfig.EnableDamageDisplayScale.Value;

        public static void Prefix(WorldSpaceDamageFeedback __instance)
        {
            //Have to overwrite becuase the value is changed from the prefab.
            __instance.worldSpaceDamageSetting.MinScaleMultiple = Plugin.ModConfig.DamageMinScale.Value;
            __instance.worldSpaceDamageSetting.MaxScaleMultiple = Plugin.ModConfig.DamageMaxScale.Value;
        }
    }
}
