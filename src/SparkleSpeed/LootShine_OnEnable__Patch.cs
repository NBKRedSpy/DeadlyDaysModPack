using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace DeadlyDaysModPack.SparkleSpeed
{
    /// <summary>
    /// Increases the speed of the sparkle effect on vehicles.
    /// </summary>
    [HarmonyPatch(typeof(LootShine), nameof(LootShine.OnEnable))]
    public static class LootShine_OnEnable__Patch
    {
        public static bool Prepare()
        {
            return Plugin.ModConfig.EnableVehicleSparkleSpeed.Value;
        }

        public static void Postfix(LootShine __instance)
        {
            if(__instance.loot == null || __instance.loot is SearchableContainer == false)
            {
                return;
            }

            var main = __instance.particles.main;
            main.simulationSpeed = Plugin.ModConfig.VehicleSparkleSpeed.Value;
        }
    }
}
