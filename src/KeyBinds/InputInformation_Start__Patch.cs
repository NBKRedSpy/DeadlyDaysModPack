using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DeadlyDaysModPack.KeyBinds
{
    /// <summary>
    /// Adds key remapping
    /// </summary>
    [HarmonyPatch(typeof(InputInformation), nameof(InputInformation.Start))]
    public static class InputInformation_Start__Patch
    {
        private static bool Inited = false;

        public static bool Prepare() => Plugin.ModConfig.EnableKeyBinds.Value;

        public static void Postfix(InputInformation __instance)
        {
            if (Inited) return;
            Inited = true;

            Plugin.KeyboardConfig.RemapButtons(__instance.player);
        }
    }
}
