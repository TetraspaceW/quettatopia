using Godot;
using System;
using System.Collections.Generic;

public class MapView : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    TileMap tileMap;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        tileMap = (TileMap)GetNode("./TileMap");
        tileMap.TileSet = GetTilesetWithImages("/terrain");

        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                tileMap.SetCell(x, y, tileMap.TileSet.FindTileByName("terrain/plains"));
            }
        }

        SetMapLocation(10, 10);
    }

    void SetMapLocation(int width, int height)
    {
        tileMap.Position = new Vector2(
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
