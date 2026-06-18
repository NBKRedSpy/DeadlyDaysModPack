using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadlyDaysModPack.InventorySort
{
    [HarmonyPatch(typeof(InventoryWeapon), nameof(InventoryWeapon.OrderedWeapons))]
    internal static class InventoryWeapon_OrderedWeapons__Patch
    {
        public static bool Prepare() => Plugin.ModConfig.EnableInventorySort.Value;

        public static bool Prefix(IEnumerable<InventoryWeapon> items, ref IEnumerable<InventoryWeapon> __result)
        {

            __result = items
                    .OrderBy(x => x.Name)
                    .ThenByDescending(x => x.BuildInformation.Level)
                    .ThenByDescending(x => x.BuildInformation.IsRepaired)
                    .ToList();

            return false;
        }
    }
}
