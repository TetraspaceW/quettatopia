using Godot;
using System;

public class TileMapArea : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    MapView mapView;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        mapView = GetParent<MapView>();
    }

    public override void _InputEvent(Godot.Object viewport, InputEvent @event, int shapeIdx)
    {
        if (@event is InputEventMouseButton)
        {
            InputEventMouseButton mouseClickEvent = @event as InputEventMouseButton;

            var pos = mouseClickEvent.Position - GetGlobalTransformWithCanvas().origin;
            var (x, y) = (pos.x / 64, pos.y / 64);

            if (mouseClickEvent.ButtonIndex == (int)ButtonList.Left && !mouseClickEvent.Pressed)
            {

            }
        }
    }
}
