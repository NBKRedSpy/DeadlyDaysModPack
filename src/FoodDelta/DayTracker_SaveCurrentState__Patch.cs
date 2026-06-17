using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace DeadlyDaysModPack.FoodDelta
{
    /// <summary>
    /// Override the daily summary using the main balance.  Use the amounts that were extracted from
    /// the temporary balance from the mission.
    /// </summary>
    [HarmonyPatch(typeof(DayTracker), nameof(DayTracker.SaveCurrentState))]
    internal static class DayTracker_SaveCurrentState__Patch
    {

        public static int QueuedParts { get; set; } = 0;

        public static int QueuedFood { get; set; } = 0;

        public static int QueuedTools { get; set; } = 0;

        public static bool Prepare() => Plugin.ModConfig.EnableFoodDelta.Value;

        public static bool Prefix(DayTracker __instance)
        {
            //COPY WARNING - This is a full copy and replace of the original function.
            //  The game is "finished" so it's unlikely someone else will mod it.  
            //  A transpiler is probably not worth the effort.


            if (__instance.currentTrackedMission != null)
            {
                __instance.saveCachedDay();
                int day = __instance.CurrentDay - 1;
                BaseItemDefinition[] items = __instance.itemInventory.EquipablesInInventory.OfType<BaseItemDefinition>().Except(__instance.oldBaseItems).ToArray();
                __instance.trackingPersistency.AddItemsForDay(day, items);
                SpecialPowerDefinition[] powers = __instance.powerInventory.EquipablesInInventory.OfType<SpecialPowerDefinition>().Except(__instance.oldPowers).ToArray();
                __instance.trackingPersistency.AddPowerForDay(day, powers);
                InventoryWeapon[] weapons = __instance.weaponInventory.EquipablesInInventory.OfType<InventoryWeapon>().Where((InventoryWeapon w) => !__instance.weaponsToIgnore.Contains(w.BuildInformation.WeaponType)).Except(__instance.oldWeapons)
                    .ToArray();
                __instance.trackingPersistency.AddWeaponForDay(day, weapons);

                //---- Original Code:
                //  Note that the GameBalance.Instance.TemporaryBalance is already cleared out before this function
                //  is executed.  Probably a bug.
                //__instance.trackingPersistency.AddPartsForDay(day, GameBalance.Instance.PartsBalance.Amount + (float)GameBalance.Instance.TemporaryBalance.Parts);
                //__instance.trackingPersistency.AddFoodForDay(day, GameBalance.Instance.FoodBalance.Amount + (float)GameBalance.Instance.TemporaryBalance.Food);
                //__instance.trackingPersistency.AddToolsForDay(day, GameBalance.Instance.ToolBalance.Amount + (float)GameBalance.Instance.TemporaryBalance.Tools);

                //The TemporaryBalance is actually always zero in this function.  The nightly code has already moved
                //  the temporary balance to the main balance.  Probably a bug.
                __instance.trackingPersistency.AddPartsForDay(day, QueuedParts);
                __instance.trackingPersistency.AddFoodForDay(day, QueuedFood);
                __instance.trackingPersistency.AddToolsForDay(day, QueuedTools);

                __instance.trackingPersistency.AddCharactersForDay(day, RunStateFactory.Instance.Characters);
            }
            __instance.ResetItemLists();
            __instance.currentTrackedMission = null;


            //Cleanup
            QueuedFood = 0;
            QueuedTools = 0;
            QueuedParts = 0;

            return false;
        }
    }
}
