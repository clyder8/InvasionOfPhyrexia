using Terraria;
using Terraria.ModLoader;

namespace PhyrexiaMod.Content.Dusts
{
    public class PhyrexianFrontierWaterSplash : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.alpha = 170;
            dust.velocity *= 0.5f;
            dust.velocity.Y += 1f;
        }
    }
}
