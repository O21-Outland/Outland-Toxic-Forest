using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace ToxicForest
{
    public class WorldGenStep_PostPollution : WorldGenStep
    {
        public override int SeedPart => 759372056;

        public override void GenerateFresh(string seed)
        {
            WorldGrid worldGrid = Find.WorldGrid;
            for (int i = 0; i < worldGrid.TilesCount; i++)
            {
                Tile tile = worldGrid.tiles[i];
                if (tile.biome.HasModExtension<DefModExt_ToxifyBiome>())
                {
                    WorldPollutionUtility.PolluteWorldAtTile(i, new FloatRange(0.3f, 1.5f).RandomInRange);
                }
            }
        }
    }
}
