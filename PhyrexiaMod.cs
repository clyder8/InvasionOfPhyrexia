using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using PhyrexiaMod.Content.Biomes.PhyrexianFrontier;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Shaders;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

namespace PhyrexiaMod
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class PhyrexiaMod : Mod
	{
		public override void Load(){
			if (!Main.dedServ)
            {	
				SkyManager.Instance["PhyrexianFrontierSky"] = new PhyrexianFrontierSky();
			}
           	base.Load();
		}
	}
}
