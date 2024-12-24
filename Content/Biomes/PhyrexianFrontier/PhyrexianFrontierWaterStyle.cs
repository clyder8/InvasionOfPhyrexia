using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PhyrexiaMod.Content.Biomes.PhyrexianFrontier
{
    public class PhyrexianFrontierWaterStyle : ModWaterStyle
    {
        public override int ChooseWaterfallStyle() => Find<ModWaterfallStyle>("PhyrexiaMod/PhyrexianFrontierWaterfallStyle").Slot;

        public override int GetSplashDust() => Find<ModDust>("PhyrexiaMod/PhyrexianFrontierWaterSplash").Type;

        public override int GetDropletGore() => Find<ModGore>("PhyrexiaMod/PhyrexianFrontierWaterDroplet").Type;

        public override Color BiomeHairColor()
        {
            return new Color(60,10,55);
        }
        public override byte GetRainVariant()
        {
            return (byte)Main.rand.Next(3);
        }
        public override Asset<Texture2D> GetRainTexture()
        {
            return Request<Texture2D>("PhyrexiaMod/Content/Biomes/PhyrexianFrontier/PhyrexianFrontierRain");
        }
    }
}