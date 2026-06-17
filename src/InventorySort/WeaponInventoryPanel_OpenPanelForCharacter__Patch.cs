using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadlyDaysModPack.InventorySort
{
    [HarmonyPatch(typeof(WeaponInventoryPanel), nameof(WeaponInventoryPanel.OpenPanelForCharacter))]
    internal static class WeaponInventoryPanel_OpenPanelForCharacter__Patch
    {
        public static bool Prepare() => Plugin.ModConfig.EnableInventorySort.Value;

        public static bool Prefix(WeaponInventoryPanel __instance, CharacterPortrait character, bool forceRefresh = true)
        {
            //COPY WARNING - This is a full copy of the original method.  Since the game is finished and 
            //  it is unlikely to be modded by others, it should be safe to not bother with a more complex
            //  transpiler patch.

            __instance.selectingCharacterBehaviour = character.CharacterReference;
            if (!__instance.IsExpanded || forceRefresh)
            {
                //Debug
                //IEquipable[] items = inventory.EquipablesInInventory.Where((IEquipable t) => !t.IsEquipped).ToArray();
                IEquipable[] items = __instance.inventory.EquipablesInInventory.Where((IEquipable t) => !t.IsEquipped)
                    .OrderByDescending(x => x is InventoryWeapon ? ((InventoryWeapon)x).BuildInformation.IsRepaired : false)
                    .ThenByDescending(x => x is InventoryWeapon ? ((InventoryWeapon)x).BuildInformation.Level : 0)
                    .ThenBy(x => x.Name)
                    .ToArray();
                __instance.GeneratePagesData(items);
                if (__instance.pageIndex > __instance.pages.Count - 1)
                {
                    __instance.pageIndex = __instance.pages.Count - 1;
                    __instance.itemIndex = __instance.collums * __instance.maxRows;
                }
                __instance.ribbonObject.SetActive(value: true);
                __instance.DisplayCurrentPage();
            }

            return false;
        }
    }
}
