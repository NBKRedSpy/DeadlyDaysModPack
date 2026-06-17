using BepInEx.Configuration;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DeadlyDaysModPack.CharacterHotkeys
{
    /// <summary>
    /// The patch to add hotkeys to the character panel on the right side of the screen during a mission.
    /// </summary>
    [HarmonyPatch(typeof(GameplayControllerCharacterSelector), nameof(GameplayControllerCharacterSelector.Update))]
    public static class GameplayControllerCharacterSelector_Update__Patch
    {
        private static GUIStateManager GUIStateManager { get; set; }

        public static bool Prepare() => Plugin.ModConfig.EnableCharacterHotkeys.Value;

        public static void Postfix(GameplayControllerCharacterSelector __instance)
        {
            if(GUIStateManager == null) GUIStateManager = GameObjectSingleton<GUIStateManager>.Instance;
            if(GUIStateManager.CurrentState != GUIState.Game) return;

            ProcessCharacterHotkeys(__instance);
        }
        
        /// <summary>
        /// Handles the character hotkeys.  
        /// </summary>
        private static void ProcessCharacterHotkeys(GameplayControllerCharacterSelector characterSelector)
        {
            if (!Input.anyKey) return;

            int index = -1;
            index = Plugin.ModConfig.CharacterSelectHotkeys
                .FindIndex(x => x.Value.IsPressed());

            if (index == -1) return;

            //I'm pretty sure SpawnedItems is a list of the character portraits, but to be safe, we'll filter it down to just the portraits.
            List<CharacterPortrait> characterPortraits;
            characterPortraits = characterSelector.characterPanel.SpawnedItems
                .Where(x => x is CharacterPortrait).Cast<CharacterPortrait>()
                .ToList();

            if (index >= characterPortraits.Count) return;  //Early exit

            characterPortraits[index].ZoomToCharacter();
        }
    }
}
