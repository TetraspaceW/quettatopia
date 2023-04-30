using System.Collections.Generic;
using System;

class MapModel
{
    static int width = 9;
    static int height = 9;

    public TerrainTile[,] terrain = new TerrainTile[width, height];
    public Dictionary<(int, int), Unit> units = new Dictionary<(int, int), Unit>();

    public MapModel()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var d = RND.d(8);
                if (d <= 2) { terrain[x, y] = new TerrainTile("forest"); }
                else if (d == 3) { terrain[x, y] = new TerrainTile("mountains"); }
                else { terrain[x, y] = new TerrainTile("plains"); }
            }
        }

        units.Add((4, 4), new Unit(new UnitType(movement: 1, attack: (1, 2), health: 8, image: "group")));
    }

    public void UpdateTurn()
    {

    }

    List<(int, int)> CalculateValidMoves((int, int) position, int movement)
    {
        var validMoves = new List<(int, int)>();
        var (unitX, unitY) = position;

        for (int x = unitX; x <= Math.Max(unitX + movement, 8); x++)
        {
            for (int y = unitY; y <= Math.Max(unitY + movement, 8); y++)
            {
                if (position != (x, y)) { validMoves.Add((x, y)); }
            }
        }
        return validMoves;
    }
}

class TerrainTile
{
    public string terrain;

    public TerrainTile(string terrain) { this.terrain = terrain; }
}

class Unit
{
    uint owner;
    UnitType type;

    public Unit(UnitType type)
    {
        owner = 0;
        this.type = type;
    }

    public string GetImage()
    {
        return type.image;
    }
}

class UnitType
{
    int movement;
    (int, int) attack;
    int health;

    public string image;

    public UnitType(int movement, (int, int) attack, int health, string image) { this.movement = movement; this.attack = attack; this.health = health; this.image = image; }
}