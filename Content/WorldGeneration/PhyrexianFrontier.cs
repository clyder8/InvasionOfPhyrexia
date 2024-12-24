using System;
using System.Collections.Generic;
using PhyrexiaMod.Content.Tiles.PhyrexianFrontier;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Generation;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace PhyrexiaMod.WorldGeneration;

public class PhyrexianFrontier
{


    public static void GenFrontier()
    {
        int beachBordersWidth = 275;
        int beachSandRandomCenter = beachBordersWidth + 5 + 40;
        int evilBiomeBeachAvoidance = beachSandRandomCenter + 60;
        int evilBiomeAvoidanceMidFixer = 50;

        int jungleTilesUpperX = Main.maxTilesX;
        int jungleTilesLowerX = 0;
        int snowTilesUpperX = Main.maxTilesX;
        int snowTilesLowerX = 0;
        Tile tile;
        for (int x = 0; x < Main.maxTilesX; x++)
        {
            for (int y = 0; y < Main.worldSurface; y++)
            {
                tile = Main.tile[x, y];
                if (tile.HasTile)
                {
                    tile = Main.tile[x, y];
                    if (tile.TileType == TileID.JungleGrass)
                    {
                        if (x < jungleTilesUpperX)
                        {
                            jungleTilesUpperX = x;
                        }

                        if (x > jungleTilesLowerX)
                        {
                            jungleTilesLowerX = x;
                        }
                    }
                    else
                    {
                        tile = Main.tile[x, y];
                        if (tile.TileType is not TileID.SnowBlock and not TileID.IceBlock)
                        {
                            continue;
                        }

                        // Found snow or ice
                        if (x < snowTilesUpperX)
                        {
                            snowTilesUpperX = x;
                        }

                        if (x > snowTilesLowerX)
                        {
                            snowTilesLowerX = x;
                        }
                    }
                }
            }
        }

        int boundaryOffset = 10;
        jungleTilesUpperX -= boundaryOffset;
        jungleTilesLowerX += boundaryOffset;
        snowTilesUpperX -= boundaryOffset;
        snowTilesLowerX += boundaryOffset;

        const int num500 = 500;
        const int num100 = 100;

        bool notDrunk = true;
        double iterations = Main.maxTilesX * 0.00045;
        if (Terraria.WorldGen.drunkWorldGen)
        {
            iterations /= 2.0;
            if (Terraria.WorldGen.genRand.Next(2) == 0)
            {
                notDrunk = false;
            }
        }

        for (int iteration = 0; iteration < iterations; iteration++)
        {
            int snowTilesUpperXInner = snowTilesUpperX;
            int snowTilesLowerXInner = snowTilesLowerX;
            int jungleTilesUpperXInner = jungleTilesUpperX;
            int jungleTilesLowerXInner = jungleTilesLowerX;
            bool foundGoodSpot = false;
            int randomX = 0;
            int leftBeachAvoidanceCheck = 0;
            int rightBeachAvoidanceCheck = 0;

            while (!foundGoodSpot)
            {
                foundGoodSpot = true;
                int centerX = Main.maxTilesX / 2;
                int minDistanceFromCenter = 200;
                if (Terraria.WorldGen.drunkWorldGen)
                {
                    minDistanceFromCenter = 100;
                    randomX = !notDrunk
                        ? Terraria.WorldGen.genRand.Next((int)(Main.maxTilesX * 0.5), Main.maxTilesX - num500)
                        : Terraria.WorldGen.genRand.Next(num500, (int)(Main.maxTilesX * 0.5));
                }
                else
                {
                    randomX = Terraria.WorldGen.genRand.Next(num500, Main.maxTilesX - num500);
                }

                leftBeachAvoidanceCheck = randomX - Terraria.WorldGen.genRand.Next(200) - 100;
                rightBeachAvoidanceCheck = randomX + Terraria.WorldGen.genRand.Next(200) + 100;
                if (leftBeachAvoidanceCheck < evilBiomeBeachAvoidance)
                {
                    leftBeachAvoidanceCheck = evilBiomeBeachAvoidance;
                }

                if (rightBeachAvoidanceCheck > Main.maxTilesX - evilBiomeBeachAvoidance)
                {
                    rightBeachAvoidanceCheck = Main.maxTilesX - evilBiomeBeachAvoidance;
                }

                if (randomX < leftBeachAvoidanceCheck + evilBiomeAvoidanceMidFixer)
                {
                    randomX = leftBeachAvoidanceCheck + evilBiomeAvoidanceMidFixer;
                }

                if (randomX > rightBeachAvoidanceCheck - evilBiomeAvoidanceMidFixer)
                {
                    randomX = rightBeachAvoidanceCheck - evilBiomeAvoidanceMidFixer;
                }

                if ( Terraria.WorldBuilding.GenVars.dungeonSide < 0 && leftBeachAvoidanceCheck < 400)
                {
                    leftBeachAvoidanceCheck = 400;
                }
                else if ( Terraria.WorldBuilding.GenVars.dungeonSide > 0 &&
                         leftBeachAvoidanceCheck > Main.maxTilesX - 400)
                {
                    leftBeachAvoidanceCheck = Main.maxTilesX - 400;
                }

                if (randomX > centerX - minDistanceFromCenter && randomX < centerX + minDistanceFromCenter)
                {
                    foundGoodSpot = false;
                }

                if (leftBeachAvoidanceCheck > centerX - minDistanceFromCenter &&
                    leftBeachAvoidanceCheck < centerX + minDistanceFromCenter)
                {
                    foundGoodSpot = false;
                }

                if (rightBeachAvoidanceCheck > centerX - minDistanceFromCenter &&
                    rightBeachAvoidanceCheck < centerX + minDistanceFromCenter)
                {
                    foundGoodSpot = false;
                }

                if (randomX > Terraria.WorldBuilding.GenVars.UndergroundDesertLocation.X && randomX <
                    Terraria.WorldBuilding.GenVars.UndergroundDesertLocation.X + Terraria.WorldBuilding.GenVars.UndergroundDesertLocation.Width)
                {
                    foundGoodSpot = false;
                }

                if (leftBeachAvoidanceCheck > Terraria.WorldBuilding.GenVars.UndergroundDesertLocation.X && leftBeachAvoidanceCheck <
                    Terraria.WorldBuilding.GenVars.UndergroundDesertLocation.X + Terraria.WorldBuilding.GenVars.UndergroundDesertLocation.Width)
                {
                    foundGoodSpot = false;
                }

                if (rightBeachAvoidanceCheck > Terraria.WorldBuilding.GenVars.UndergroundDesertLocation.X && rightBeachAvoidanceCheck <
                    Terraria.WorldBuilding.GenVars.UndergroundDesertLocation.X + Terraria.WorldBuilding.GenVars.UndergroundDesertLocation.Width)
                {
                    foundGoodSpot = false;
                }

                if (leftBeachAvoidanceCheck < Terraria.WorldBuilding.GenVars.dungeonSide + num100 &&
                    rightBeachAvoidanceCheck > Terraria.WorldBuilding.GenVars.dungeonSide - num100)
                {
                    foundGoodSpot = false;
                }

                if (leftBeachAvoidanceCheck < snowTilesLowerXInner && rightBeachAvoidanceCheck > snowTilesUpperXInner)
                {
                    snowTilesUpperXInner++;
                    snowTilesLowerXInner--;
                    foundGoodSpot = false;
                }

                if (leftBeachAvoidanceCheck < jungleTilesLowerXInner &&
                    rightBeachAvoidanceCheck > jungleTilesUpperXInner)
                {
                    jungleTilesUpperXInner++;
                    jungleTilesLowerXInner--;
                    foundGoodSpot = false;
                }
            }

            // Just checked that randomX is valid and now we start
            // Modify jungle
            for (int x = leftBeachAvoidanceCheck; x < rightBeachAvoidanceCheck; x++)
            {
                for (int y = (int) Terraria.WorldBuilding.GenVars.worldSurfaceLow; y < Main.worldSurface - 1.0; y++)
                {
                    tile = Main.tile[x, y];
                    if (tile.HasTile)
                    {
                        int randomY = y + Terraria.WorldGen.genRand.Next(10, 14);
                        for (int y2 = y; y2 < randomY; y2++)
                        {
                            tile = Main.tile[x, y2];
                            if (tile.TileType is not TileID.Mud and not TileID.JungleGrass)
                            {
                                continue;
                            }

                            if (x >= leftBeachAvoidanceCheck + Terraria.WorldGen.genRand.Next(5) &&
                                x < rightBeachAvoidanceCheck - Terraria.WorldGen.genRand.Next(5))
                            {
                                tile.TileType = TileID.Dirt;
                            }
                        }

                        break;
                    }
                }
            }

            // Replace tiles
            double randomYOffset = Main.worldSurface + 40.0;
            for (int x = leftBeachAvoidanceCheck; x < rightBeachAvoidanceCheck; x++)
            {
                randomYOffset += Terraria.WorldGen.genRand.Next(-2, 3);
                if (randomYOffset < Main.worldSurface + 30.0)
                {
                    randomYOffset = Main.worldSurface + 30.0;
                }

                if (randomYOffset > Main.worldSurface + 50.0)
                {
                    randomYOffset = Main.worldSurface + 50.0;
                }

                bool unusedFlag = false;
                for (int y = (int) Terraria.WorldBuilding.GenVars.worldSurfaceLow; y < randomYOffset; y++)
                {
                    tile = Main.tile[x, y];
                    if (tile.HasTile)
                    {
                        if (tile.TileType == TileID.Sand || tile.TileType == TileID.Crimsand || tile.TileType == TileID.Ebonsand && x >= leftBeachAvoidanceCheck + Terraria.WorldGen.genRand.Next(5) &&
                            x <= rightBeachAvoidanceCheck - Terraria.WorldGen.genRand.Next(5))
                        {
                            tile.TileType = (ushort)ModContent.TileType<OilSandTile>();
                        }

                        tile = Main.tile[x, y];
                        if (tile.TileType == TileID.Dirt && y < Main.worldSurface - 1.0 && !unusedFlag)
                        {
                            Terraria.WorldGen.SpreadGrass(x, y, TileID.Dirt, ModContent.TileType<OilGrassTile>());
                        }

                       

                        switch (tile.TileType)
                        {
                            case TileID.Stone:
                            {
                                if (x >= leftBeachAvoidanceCheck + Terraria.WorldGen.genRand.Next(5) &&
                                    x <= rightBeachAvoidanceCheck - Terraria.WorldGen.genRand.Next(5))
                                {
                                    tile.TileType = (ushort)ModContent.TileType<OilyStoneTile>();
                                }

                                break;
                            }
                            case TileID.Ebonstone:
                            {
                                if (x >= leftBeachAvoidanceCheck + Terraria.WorldGen.genRand.Next(5) &&
                                    x <= rightBeachAvoidanceCheck - Terraria.WorldGen.genRand.Next(5))
                                {
                                    tile.TileType = (ushort)ModContent.TileType<OilyStoneTile>();
                                }

                                break;
                            }
                            case TileID.Crimstone:
                            {
                                if (x >= leftBeachAvoidanceCheck + Terraria.WorldGen.genRand.Next(5) &&
                                    x <= rightBeachAvoidanceCheck - Terraria.WorldGen.genRand.Next(5))
                                {
                                    tile.TileType = (ushort)ModContent.TileType<OilyStoneTile>();
                                }

                                break;
                            }
                            case TileID.Grass:
                                tile.TileType = (ushort)ModContent.TileType<OilGrassTile>();
                                break;
                            case TileID.CrimsonGrass:
                                tile.TileType = (ushort)ModContent.TileType<OilGrassTile>();
                                break;
                            case TileID.CorruptGrass:
                                tile.TileType = (ushort)ModContent.TileType<OilGrassTile>();
                                break;
                            case TileID.JungleGrass:
                                tile.TileType = (ushort)ModContent.TileType<OilGrassTile>();
                                break;
                            case TileID.IceBlock:
                                tile.TileType = (ushort)ModContent.TileType<OilyIceTile>();
                                break;
                            case TileID.CorruptIce:
                                tile.TileType = (ushort)ModContent.TileType<OilyIceTile>();
                                break;
                            case TileID.FleshIce:
                                tile.TileType = (ushort)ModContent.TileType<OilyIceTile>();
                                break;
                            case TileID.Sandstone:
                                tile.TileType = (ushort)ModContent.TileType<OilSandTile>();
                                break;
                            case TileID.CorruptSandstone :
                                tile.TileType = (ushort)ModContent.TileType<OilSandTile>();
                                break;
                            case TileID.CrimsonSandstone:
                                tile.TileType = (ushort)ModContent.TileType<OilSandTile>();
                                break;
                            case TileID.CrimsonHardenedSand:
                                tile.TileType = (ushort)ModContent.TileType<OilSandTile>();
                                break;
                            case TileID.CorruptHardenedSand:
                                tile.TileType = (ushort)ModContent.TileType<OilSandTile>();
                                break;
                            case TileID.HardenedSand:
                                tile.TileType = (ushort)ModContent.TileType<OilSandTile>();
                                break;
                            case TileID.Mud:
                                tile.TileType = (ushort)TileID.Dirt;
                                break;
                            WorldGen.SquareTileFrame(x, y, true);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                    }
                }
            }

        }
       
    }
}
