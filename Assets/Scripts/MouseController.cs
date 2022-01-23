using System;
using Managers.Tilemap;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;
using Tile = UnityEngine.Tilemaps.Tile;

public class MouseController: MonoBehaviour
{
    [SerializeField] private Tile selectedTile;
    [SerializeField] private GroundTilemapManager groundTilemapManager;

    public void SelectTile(Tile tile)
    {
        selectedTile = tile;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse down");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector3Int cellSelected = groundTilemapManager.tilemap.WorldToCell(mousePos);
            cellSelected.z = 0;
            groundTilemapManager.PlotTile(cellSelected, selectedTile);
        }
    }
}
