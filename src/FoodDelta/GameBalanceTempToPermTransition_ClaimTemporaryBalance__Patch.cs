using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace DeadlyDaysModPack.FoodDelta
{
    [HarmonyPatch(typeof(GameBalanceTempToPermTransition), nameof(GameBalanceTempToPermTransition.ClaimTemporaryBalance))]
    internal static class GameBalanceTempToPermTransition_ClaimTemporaryBalance__Patch
    {
        public static bool Prepare() => Plugin.ModConfig.EnableFoodDelta.Value;

        public static void Prefix(GameBalanceTempToPermTransition __instance)
        {
            //The TemporaryBalance is actually always zero in this function.  The nightly code has already moved
            //  the temporary balance to the main balance.  Probably a bug.

            //Store the values for the summary save code to use the delta values instead.
            DayTracker_SaveCurrentState__Patch.QueuedParts = (int)__instance.gameBalance.TemporaryBalance.Parts;
            DayTracker_SaveCurrentState__Patch.QueuedFood = (int)__instance.gameBalance.TemporaryBalance.Food;
            DayTracker_SaveCurrentState__Patch.QueuedTools = (int)__instance.gameBalance.TemporaryBalance.Tools;
        }
    }
}
