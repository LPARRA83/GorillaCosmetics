﻿using BepInEx;
using BepInEx.Configuration;
using GorillaCosmetics.HarmonyPatches;
using System.IO;
using UnityEngine;

namespace GorillaCosmetics
{
    [BepInPlugin("org.legoandmars.gorillatag.gorillacosmetics", "Gorilla Cosmetics", "2.1.1")]
    public class GorillaCosmetics : BaseUnityPlugin
    {
        public static ConfigEntry<string> selectedMaterial;
        public static ConfigEntry<string> selectedInfectedMaterial;
        public static ConfigEntry<string> selectedHat;
        public static ConfigEntry<bool> applyToOtherPlayers;
        public static ConfigEntry<bool> applyInfectedToOtherPlayers;
        public static ConfigEntry<bool> applyHatsToOtherPlayers;
        void Start()
        {
            Debug.Log("Starting Gorilla Cosmetics");

            // Config
            var customFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "GorillaCosmetics.cfg"), true);
            selectedMaterial = customFile.Bind("Cosmetics", "SelectedMaterial", "Rainbow", "What material to use from the BepInEx/plugins/GorillaCosmetics/Materials folder. Use Default for none");
            selectedInfectedMaterial = customFile.Bind("Cosmetics", "SelectedInfectedMaterial", "Default", "What material to use from the BepInEx/plugins/GorillaCosmetics/Materials folder for tagged/infected players. Use Default for none");
            selectedHat = customFile.Bind("Cosmetics", "SelectedHat", "Top Hat", "What hat to use from the BepInEx/plugins/GorillaCosmetics/Hats folder. Use Default for none");
            applyToOtherPlayers = customFile.Bind("Config", "ApplyMaterialsToOtherPlayers", false, "Whether or not other players should use your selected material.");
            applyInfectedToOtherPlayers = customFile.Bind("Config", "ApplyInfectedMaterialsToOtherPlayers", false, "Whether or not other players should use your selected infected material when tagged/infected.");
            applyHatsToOtherPlayers = customFile.Bind("Config", "ApplyHatsToOtherPlayers", false, "Whether or not other players should use your selected hat.");

            // Load Cosmetics
            AssetLoader.Load();

            // Harmony Patches
            GorillaCosmeticsPatches.ApplyHarmonyPatches();
        }
    }
}