using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PhyrexiaMod.Content.Tiles.PhyrexianFrontier
{
    public class OilGrassTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileSolid[Type] = true;

            TileID.Sets.CanBeDugByShovel[Type] = true;
            TileID.Sets.Grass[Type] = false;
            TileID.Sets.ChecksForMerge[Type] = true;
            TileID.Sets.NeedsGrassFraming[Type] = false;
            TileID.Sets.ForcedDirtMerging[Type] = true;
            TileID.Sets.Conversion.Grass[Type] = false;
            TileID.Sets.Conversion.MergesWithDirtInASpecialWay[Type] = true;
            TileID.Sets.ResetsHalfBrickPlacementAttempt[Type] = false;
            TileID.Sets.DoesntPlaceWithTileReplacement[Type] = true;
            AddMapEntry(new Color(45, 10, 40));
            MinPick = 10;
            MineResist = 0.1f;
            DustType = DustID.Ash;
            RegisterItemDrop(0, 0);
        }
        public override bool CanExplode(int i, int j)
        {
            
            return true;
        }
        public override void RandomUpdate(int i, int j)
        {
            Tile tileBelow = Framing.GetTileSafely(i, j + 1);
            Tile tileAbove = Framing.GetTileSafely(i, j - 1);
            Tile tile = Framing.GetTileSafely(i, j);
            

            if (!tileAbove.HasTile && Main.tile[i, j].HasTile && Main.rand.NextBool(15) && Main.tile[i, j - 1].LiquidAmount == 0)
            {
                int rand = Main.rand.Next(22);
                Terraria.WorldGen.PlaceObject(i, j - 1, ModContent.TileType<OilFoliage>(), true, rand);
                NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<OilFoliage>(), rand, 0, -1, -1);
            }
            if (Main.rand.NextBool(4))
               Terraria.WorldGen.SpreadGrass(i + Main.rand.Next(-1, 1), j + Main.rand.Next(-1, 1), TileID.Dirt, Type, false, tile.BlockColorAndCoating());
        }
        public override void FloorVisuals(Player player)
        {
            if (player.velocity.X != 0f && Main.rand.NextBool(20))
            {
                Dust dust = Dust.NewDustDirect(player.Bottom, 0, 0, DustType, 0f, -Main.rand.NextFloat(2f));
                dust.noGravity = true;
                dust.fadeIn = 1f;
            }
        }
        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (!fail)
            {
                fail = true;
                Framing.GetTileSafely(i, j).TileType = (ushort)0;
            }
        }
        
    }
}

