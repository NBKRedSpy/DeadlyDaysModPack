using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace DeadlyDaysModPack.DpsDisplay
{
    /// <summary>
    /// Adds an estimated total DPS number to the weapon inspection panel including the fire rate.
    /// </summary>
    [HarmonyPatch(typeof(PopupWeaponDisplay), nameof(PopupWeaponDisplay.ApplyWeapon))]
    public static class PopupWeaponDisplay_ApplyWeapon__Patch
    {
        public static bool Prepare() => Plugin.ModConfig.EnableDpsDisplay.Value;

        public static void Postfix(PopupWeaponDisplay __instance, InventoryWeapon weapon, CharacterBehaviour tempCharacter)
        {
            if (weapon is null || !weapon.IsRepaired) return;



            WeaponInformation weaponInformation = weapon.BuildInformation.WeaponType.WeaponInformation;
            WeaponInstance inspectionInstance = weapon.InspectionInstance;

            if (tempCharacter != null)
            {
                inspectionInstance.AssignOnlyCharacterStats(tempCharacter);
            }

            string estimatedDamage = (inspectionInstance.Damage * Mathf.Max(1, __instance.GetBulletCount(inspectionInstance)) * inspectionInstance.AttacksPerSeconds).RoundNumberToString();

            __instance.bulletMultiplier.text += $" ({estimatedDamage})";


        }
    }
}
