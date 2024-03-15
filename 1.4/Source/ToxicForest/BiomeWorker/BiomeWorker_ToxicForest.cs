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
    public class BiomeWorker_ToxicForest : BiomeWorker
    {
        public override float GetScore(Tile tile, int tileID)
        {
            if (tile.WaterCovered) { return -100f; }
            if (tile.temperature < 10f || tile.temperature > 17f) { return 0f; }
            if (tile.rainfall < 1500f || tile.rainfall > 2100f) { return 0f; }
            return 22f + (tile.temperature - 14f) * 1.6f + (tile.rainfall - 300f) / 172f;
		}
	}
}
