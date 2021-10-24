using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class Room : Node2D
{
	public List<Vector2> Spawns { get; } = new();

	public override void _Ready()
	{
		var tileMap = GetChild<TileMap>(0);
		var tileSet = tileMap.TileSet;

		var availableIds = tileSet.GetTilesIds()
			.Cast<int>()
			.Where(x => tileSet.TileGetNavigationPolygon(x) != null)
			.ToHashSet();

		var cells = tileMap.GetUsedCells();

		foreach (Vector2 cell in cells)
		{
			var cellIndex = tileMap.GetCellv(cell);
			if (availableIds.Contains(cellIndex)) Spawns.Add(cell * tileMap.CellSize);
		}


	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
