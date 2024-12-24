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
    public class PhyrexianFrontierSky : CustomSky
    {
        public static bool Open = false;
        public override void Deactivate(params object[] args)
        {
            skyActive = false;
        }

        public override void Reset()
        {
            skyActive = false;
        }

        public override bool IsActive()
        {
            return skyActive;
        }

      

        public override void Activate(Vector2 position, params object[] args)
        {
            skyActive = true;
        }

        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {

            if (maxDepth >= 3E+38f && minDepth < 3E+38f)
            {
                Texture2D sky = ModContent.Request<Texture2D>("PhyrexiaMod/Content/Biomes/PhyrexianFrontier/PhyrexianFrontierSky").Value;
                if(Main.dayTime)
                    spriteBatch.Draw(sky, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), new Color(255,255,255)*opacity);
                else{
                    spriteBatch.Draw(sky, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), new Color(255,255,255)*opacity);
                }
            }
        }
        public override void Update(GameTime gameTime)
        {
            if (skyActive)
            {
                if (opacity < 0.5f)
                    opacity += 0.02f;
                if (opacity > 0.5f)
                    opacity = 0.5f;

               
            }
            else
            {
                if (opacity > 0f)
                    opacity -= 0.02f;
                if (opacity < 0f)
                    opacity = 0f;
            }
        }
        public override float GetCloudAlpha()
        {
            return (1f - opacity) * 0.97f + 0.03f;
        }

        private bool skyActive;

        private float opacity;
    }

}