using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PhyrexiaMod.Content.Tiles.PhyrexianFrontier
{
    public class OilyIceTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            TileID.Sets.Conversion.Ice[Type] = true;
            TileID.Sets.Ices[Type] = true;
            TileID.Sets.IcesSnow[Type] = true;
            TileID.Sets.IcesSlush[Type] = true;
            TileID.Sets.ChecksForMerge[Type] = true;
            TileID.Sets.CanBeClearedDuringOreRunner[Type] = true;
           
            Main.tileMerge[TileID.SnowBlock][Type] = true;
            Main.tileMerge[Type][TileID.SnowBlock] = true;
            Main.tileMerge[TileID.IceBlock][Type] = true;
            Main.tileMerge[Type][TileID.IceBlock] = true;
            Main.tileMerge[TileID.IceBrick][Type] = true;
            Main.tileMerge[Type][TileID.IceBrick] = true;
            Main.tileMerge[TileID.CorruptIce][Type] = true;
            Main.tileMerge[Type][TileID.CorruptIce] = true;
            Main.tileMerge[TileID.FleshIce][Type] = true;
            Main.tileMerge[Type][TileID.FleshIce] = true;
            Main.tileMerge[TileID.HallowedIce][Type] = true;
            Main.tileMerge[Type][TileID.HallowedIce] = true;
            DustType = DustID.Ash;
            AddMapEntry(new Color(20, 10, 20));
            HitSound = SoundID.Item50;
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
    
    }
}