using System.Collections.Generic;

class MapModel
{
    List<List<TerrainTile>> terrain;
    List<Unit> units;

    public MapModel()
    {

    }
}

class TerrainTile
{
    public string terrain;


    public TerrainTile(string terrain) { this.terrain = terrain; }
}

class Unit { }