using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace PhyrexiaMod.Content.Tiles.PhyrexianFrontier
{
    public class FrontierTree : ModTree
    {
        public override TreePaintingSettings TreeShaderSettings => new()
        {
            UseSpecialGroups = true,
            SpecialGroupMinimalHueValue = 11f / 72f,
            SpecialGroupMaximumHueValue = 0.25f,
            SpecialGroupMinimumSaturationValue = 0.88f,
            SpecialGroupMaximumSaturationValue = 1f
        };
        public override void SetStaticDefaults()
        {
            GrowsOnTileId = new int[1] { ModContent.TileType<OilGrassTile>()};
        }
        public override bool Shake(int x, int y, ref bool createLeaves) => false;
        public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
        {
        }
        public override Asset<Texture2D> GetTexture()
        {
            return ModContent.Request<Texture2D>("PhyrexiaMod/Content/Tiles/PhyrexianFrontier/FrontierTree");
        }
        // public override int SaplingGrowthType(ref int style)
        // {
        //     style = 0;
        //     return ModContent.TileType<>();
        // }
        public override Asset<Texture2D> GetBranchTextures()
        {
            return ModContent.Request<Texture2D>("PhyrexiaMod/Content/Tiles/PhyrexianFrontier/FrontierTree_Branches");
        }
        public override Asset<Texture2D> GetTopTextures()
        {
            return ModContent.Request<Texture2D>("PhyrexiaMod/Content/Tiles/PhyrexianFrontier/FrontierTree_Top");
        }
        public override int DropWood() => 1;//ModContent.ItemType<Items.Materials.Chronowood>();
        public override int CreateDust() => DustID.Ash;
    }
}