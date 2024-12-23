using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using BepInEx;
using HarmonyLib;

namespace Infinite_Use_Spellbooks {
    internal static class ModInfo {
        internal const string Guid = "air1068.elin.infinitespellbooks";
        internal const string Name = "Infinite Use Spellbooks";
        internal const string Version = "0.1.1";
    }

    [BepInPlugin(ModInfo.Guid, ModInfo.Name, ModInfo.Version)]
    class InfiniteUseSpellbooks : BaseUnityPlugin {
        private void Awake() {
            var harmony = new Harmony(ModInfo.Guid);
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(TraitBaseSpellbook), nameof(TraitBaseSpellbook.ModCharge))]
    public static class TraitBaseSpellbook_ModCharge_patch {
        static bool Prefix(TraitBaseSpellbook __instance) {
            if (__instance.BookType == TraitBaseSpellbook.Type.Spell || __instance.BookType == TraitBaseSpellbook.Type.RandomSpell) {
                return false;
            }
            return true;
        }
    }
}
