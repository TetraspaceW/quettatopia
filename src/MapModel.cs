using System.Collections.Generic;

class MapModel
{
    public TerrainTile[,] terrain = new TerrainTile[10, 10];
    List<Unit> units;

    public MapModel()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                var d = RND.d(8);
                if (d <= 2) { terrain[x, y] = new TerrainTile("forest"); }
                else if (d == 3) { terrain[x, y] = new TerrainTile("mountains"); }
                else { terrain[x, y] = new TerrainTile("plains"); }
            }
        }
    }
}

class TerrainTile
{
    public string terrain;


    public TerrainTile(string terrain) { this.terrain = terrain; }
}

class Unit { }