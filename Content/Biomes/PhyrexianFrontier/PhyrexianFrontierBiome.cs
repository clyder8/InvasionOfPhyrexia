using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace PhyrexiaMod.Content.Biomes.PhyrexianFrontier
{
    public class PhyrexianFrontierBiome : ModBiome
    {
        public override SceneEffectPriority Priority
            => SceneEffectPriority.BiomeHigh;

        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle
        => ModContent.Find<ModSurfaceBackgroundStyle>("PhyrexiaMod/PhyrexianFrontierBackgroundStyle");

        


        public override void SpecialVisuals(Player player, bool isActive)
        {
            if (isActive)
            {
                
              SkyManager.Instance.Activate("PhyrexianFrontierSky");
              if(!Filters.Scene["Graveyard"].IsActive()){
              Filters.Scene.Activate("Graveyard", player.Center);
              Filters.Scene["Graveyard"].GetShader().UseIntensity(1.2f).UseOpacity(.7f);
              }
                
            }
        }
        public override void OnLeave(Player player)
        {
            SkyManager.Instance.Deactivate("PhyrexianFrontierSky");
            if(Filters.Scene["Graveyard"].IsActive())
                Filters.Scene.Deactivate("Graveyard");
        }

        public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("PhyrexiaMod/PhyrexianFrontierWaterStyle");

        //public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/StasisSurfaceTheme");

        public override bool IsBiomeActive(Player player)
        {
            return PhyrexiaModWorld.PhyrexianFrontierTiles >= 100;
        }
    }
}