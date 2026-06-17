using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace DeadlyDaysModPack.InstantSell
{

    [HarmonyPatch(typeof(WeaponScrapper), nameof(WeaponScrapper.Update))]
    internal class WeaponScrapper_Update__Patch
    {
        public static bool Prepare() => Plugin.ModConfig.EnableInstantSell.Value;

        public static void Postfix(WeaponScrapper __instance)
        {
            if (__instance.WeaponRep != null && __instance.WeaponRep.Weapon != null 
                && Input.GetKeyDown(Plugin.KeyboardConfig.InstantSellKey.Value.MainKey))
            {
                //COPY WARNING - This is a copy of the logic in the popup dialog from 
                //  WeaponScrapper.HandleSellPressed()

                InventoryWeaponRepresentation cachedWeaponRep = __instance.WeaponRep;
                GameBalance gameBalance = GameBalance.Instance;
                gameBalance.PartsBalance.AddAmount(cachedWeaponRep.Weapon.CurrentSellValue);
                __instance.weaponInventory.RemoveFromInventory(cachedWeaponRep.Weapon);
                __instance.weaponInventoryPanel.RefreshInventory();
            }
        }
    }
}
