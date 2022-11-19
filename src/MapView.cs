using Godot;
using System;
using System.Collections.Generic;

public class MapView : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    TileMap terrainTileMap;
    TileMap unitsTileMap;
    MapModel currentMap;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        terrainTileMap = CreateTileset("/terrain");
        unitsTileMap = CreateTileset("/units");

        currentMap = new MapModel();

        RenderMap();
    }

    TileMap CreateTileset(string folder)
    {
        TileMap tileMap = new TileMap();
        tileMap.TileSet = GetTilesetWithImages(folder);
        AddChild(tileMap);
        return tileMap;
    }

    void StartNextTurn()
    {
        currentMap.UpdateTurn();
    }

    void RenderMap()
    {
        for (int x = 0; x < currentMap.terrain.GetLength(0); x++)
        {
            for (int y = 0; y < currentMap.terrain.GetLength(1); y++)
            {
                terrainTileMap.SetCell(x, y, terrainTileMap.TileSet.FindTileByName("terrain/" + currentMap.terrain[x, y].terrain));
            }
        }

        foreach (var unit in currentMap.units)
        {
            unitsTileMap.SetCell(unit.Key.Item1, unit.Key.Item2, unitsTileMap.TileSet.FindTileByName("units/" + unit.Value.GetImage()));
        }

        SetMapLocation(terrainTileMap, 9, 9);
        SetMapLocation(unitsTileMap, 9, 9);
    }

    void SetMapLocation(TileMap tilemap, int width, int height)
    {
        tilemap.Position = new Vector2(
            (GetViewportRect().Size.x - width * 64) / 2,
            (GetViewportRect().Size.y - width * 64) / 2
        );
    }

    TileSet GetTilesetWithImages(string folder)
    {
        var images = GetFilesInFolder(folder);
        var newTileset = new TileSet();
        foreach (var image in images)
        {
            var id = newTileset.GetLastUnusedTileId();
            newTileset.CreateTile(id);
            newTileset.TileSetName(id, image.ToLower());
            newTileset.TileSetTexture(id, GD.Load<Texture>("res://assets/" + image + ".png"));
            newTileset.TileSetRegion(id, new Rect2(0, 0, 64, 64));
        }

        return newTileset;
    }

    List<String> GetFilesInFolder(string folder)
    {
        string extension = ".png";

        List<String> filesInFolder = new List<string>();
        var dir = new Directory();
        dir.Open("res://assets" + folder);
        dir.ListDirBegin(true, true);
        while (true)
        {
            var open = dir.GetNext();
            if (open.EndsWith(extension))
            {
                var file = open.GetFile();
                filesInFolder.Add((folder + "/").TrimStart('/') + file.Left(file.Length() - extension.Length()));
            }
            else if (open == "")
            {
                break;
            }
        }
        return filesInFolder;
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
