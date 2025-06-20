using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace ToxicForest
{
    public class ToxicForestMod : Mod
    {
        public static ToxicForestMod mod;

        public static string VersionDir => Path.Combine(mod.Content.ModMetaData.RootDir.FullName, "Version.txt");

        public static string CurrentVersion { get; private set; }

        public ToxicForestMod(ModContentPack content) : base(content)
        {
            mod = this;

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            CurrentVersion = $"{version.Major}.{version.Minor}.{version.Build}";

            Log.Message($":: {mod.Content.Name} :: {CurrentVersion} ::");

            File.WriteAllText(VersionDir, CurrentVersion);

            Harmony harmony = new Harmony("Neronix17.ToxicForest.RimWorld");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
