using System.Collections.Generic;
using System.Reflection;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;
namespace PhyrexiaMod.WorldGeneration;

public class PhyrexianFrontierGen : ModSystem
{
    public override void ModifyHardmodeTasks(List<GenPass> tasks)
    {
        GenPass currentPass;
        if (true)
        {
            int start = tasks.FindIndex(genPass => genPass.Name == "Hardmode Announcement");
            if (start != -1)
            {

                tasks.Insert(start + 1, new PassLegacy("Frontier",  (progress, config) =>PhyrexianFrontier.GenFrontier()));
            }
        }
    }
}
