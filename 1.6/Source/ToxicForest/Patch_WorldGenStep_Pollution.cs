using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using HarmonyLib;
using RimWorld.Planet;

namespace ToxicForest
{
    [HarmonyPatch(typeof(WorldGenStep_Pollution), "GenerateFresh")]
    public static class Patch_WorldGenStep_Pollution
    {
        [HarmonyPostfix]
        public static void Postfix(string seed, PlanetLayer layer)
        {
            for (int i = 0; i < layer.TilesCount; i++)
            {
                Tile tile = layer[i];
                if (tile.PrimaryBiome.HasModExtension<DefModExt_ToxifyBiome>())
                {
                    tile.pollution = 1f;
                }
            }
        }
    }
}
