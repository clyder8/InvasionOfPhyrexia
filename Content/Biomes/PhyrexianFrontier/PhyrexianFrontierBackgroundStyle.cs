using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace PhyrexiaMod.Content.Biomes.PhyrexianFrontier
{
    public class PhyrexianFrontierBackgroundStyle : ModSurfaceBackgroundStyle
    {
        

        private const string Path = "PhyrexiaMod/Assets/Backgrounds/PhyrexianFrontier/";

        public override int ChooseFarTexture()
            => BackgroundTextureLoader.GetBackgroundSlot(Path+"PhyrexianFrontierFar");

        public override int ChooseMiddleTexture()
            => BackgroundTextureLoader.GetBackgroundSlot(Path+"PhyrexianFrontierMiddle");

        public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
            => BackgroundTextureLoader.GetBackgroundSlot(Path+"PhyrexianFrontierNear");
       

        // Use this to keep far Backgrounds like the mountains.
        public override void ModifyFarFades(float[] fades, float transitionSpeed)
        {
            for (int i = 0; i < fades.Length; i++)
            {
                if (i == Slot)
                {
                    fades[i] += transitionSpeed;
                    if (fades[i] > 1f)
                    {
                        fades[i] = 1f;
                    }
                }
                else
                {
                    fades[i] -= transitionSpeed;
                    if (fades[i] < 0f)
                    {
                        fades[i] = 0f;
                    }
                }
            }
        }
    }
}