using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using System.IO;
using static Terraria.ModLoader.ModContent;
using System;
using System.Threading;
using Microsoft.Xna.Framework;
using PhyrexiaMod.Content.Tiles.PhyrexianFrontier;

namespace PhyrexiaMod
{
	public class PhyrexiaModWorld : ModSystem
	{
		public static int PhyrexianFrontierTiles;
		public override void ResetNearbyTileEffects(){
			PhyrexianFrontierTiles=0;
		}
		public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts){
			PhyrexianFrontierTiles= tileCounts[TileType<OilGrassTile>()]+tileCounts[TileType<OilyStoneTile>()]+tileCounts[TileType<OilSandTile>()]+tileCounts[TileType<OilyIceTile>()]+tileCounts[TileType<OilSandTile>()]+tileCounts[TileType<OilSandTile>()];
		}	
	}
}



	
