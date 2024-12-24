using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace PhyrexiaMod.Content.Biomes.PhyrexianFrontier
{
    public class PhyrexianFrontierLighting : ModSystem
    {
        public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
        {
           
            
            if (PhyrexiaModWorld.PhyrexianFrontierTiles >= 100&&Main.dayTime)
            {
                float strength = PhyrexiaModWorld.PhyrexianFrontierTiles / 100f;
                strength = Math.Min(strength, 1f);

                strength *= 1f - Main.lightning;

                int sunR = backgroundColor.R;
                int sunG = backgroundColor.G;
                int sunB = backgroundColor.B;

                sunR -= (int)(167f * strength * (backgroundColor.R / 255f));
                sunG -= (int)(211f * strength * (backgroundColor.G / 255f));
                sunB -= (int)(201f * strength * (backgroundColor.B / 255f));

                sunR = Utils.Clamp(sunR, 15, 255);
                sunG = Utils.Clamp(sunG, 15, 255);
                sunB = Utils.Clamp(sunB, 15, 255);

                Main.ColorOfTheSkies.R = (byte)sunR;
                Main.ColorOfTheSkies.G = (byte)sunG;
                Main.ColorOfTheSkies.B = (byte)sunB;

                tileColor.R = (byte)((Main.ColorOfTheSkies.R + Main.ColorOfTheSkies.G + Main.ColorOfTheSkies.B + Main.ColorOfTheSkies.R * 8) / 10);
                tileColor.G = (byte)((Main.ColorOfTheSkies.R + Main.ColorOfTheSkies.G + Main.ColorOfTheSkies.B + Main.ColorOfTheSkies.G * 8) / 10);
                tileColor.B = (byte)((Main.ColorOfTheSkies.R + Main.ColorOfTheSkies.G + Main.ColorOfTheSkies.B + Main.ColorOfTheSkies.B * 8) / 10);
            }
            if (PhyrexiaModWorld.PhyrexianFrontierTiles >= 100&&!Main.dayTime)
            {
                float strength = PhyrexiaModWorld.PhyrexianFrontierTiles / 100f;
                strength = Math.Min(strength, 0.5f);

                strength *= 1.3f - Main.lightning;

                int sunR = backgroundColor.R;
                int sunG = backgroundColor.G;
                int sunB = backgroundColor.B;

                sunR -= (int)(218f * strength * (backgroundColor.R / 255f));
                sunG -= (int)(253f * strength * (backgroundColor.G / 255f));
                sunB -= (int)(233f * strength * (backgroundColor.B / 255f));

                sunR = Utils.Clamp(sunR, 15, 255);
                sunG = Utils.Clamp(sunG, 15, 255);
                sunB = Utils.Clamp(sunB, 15, 255);

                Main.ColorOfTheSkies.R = (byte)sunR;
                Main.ColorOfTheSkies.G = (byte)sunG;
                Main.ColorOfTheSkies.B = (byte)sunB;

                tileColor.R = (byte)((Main.ColorOfTheSkies.R + Main.ColorOfTheSkies.G + Main.ColorOfTheSkies.B + Main.ColorOfTheSkies.R * 8) / 10);
                tileColor.G = (byte)((Main.ColorOfTheSkies.R + Main.ColorOfTheSkies.G + Main.ColorOfTheSkies.B + Main.ColorOfTheSkies.G * 8) / 10);
                tileColor.B = (byte)((Main.ColorOfTheSkies.R + Main.ColorOfTheSkies.G + Main.ColorOfTheSkies.B + Main.ColorOfTheSkies.B * 8) / 10);
            }
       }
    }
}