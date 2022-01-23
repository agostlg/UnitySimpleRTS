using System;
using Managers;
using Managers.Plants;
using Managers.Tilemaps;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using Tile = UnityEngine.Tilemaps.Tile;

public class MouseController: MonoBehaviour
{
    public PlantType selectedPlantType;
    [SerializeField] private GroundTilemapManager groundTilemapManager;
    [SerializeField] private WalletManager walletManager;
    [SerializeField] private PlantsManager plantsManager;

    public void SelectPlantType(int plantType)
    {
        selectedPlantType = plantType switch
        {
            1 => PlantType.Potatoes,
            2 => PlantType.Tomatoes,
            3 => PlantType.Beets,
            _ => throw new ArgumentOutOfRangeException(nameof(plantType), plantType, null)
        };
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector3Int cellSelected = groundTilemapManager.tilemap.WorldToCell(mousePos);
            cellSelected.z = 0;

            if (walletManager.CanAfford(10))
            {
                var plotted= plantsManager.CreatePlant(selectedPlantType, cellSelected);
                if (plotted)
                {
                    walletManager.Decrease(10);
                }
            }
        }
    }
}
