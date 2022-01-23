using System;
using System.Collections.Generic;
using System.Diagnostics;
using Managers.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;
using Debug = UnityEngine.Debug;

namespace Managers.Plants
{
    public class PlantsManager : MonoBehaviour
    {
        [SerializeField] private List<Tile> tomatoTiles;
        [SerializeField] private List<Tile> potatoTiles;
        [SerializeField] private List<Tile> beetsTiles;
        
        [SerializeField] private GroundTilemapManager _groundTilemapManager;
        private readonly List<Plant> _plants = new List<Plant>();

        private void AddPlant(Plant plant)
        {
            _plants.Add(plant);
        }

        public bool CreatePlant(PlantType plantType, Vector3Int location)
        {
            if (location.x < 0 || location.x > _groundTilemapManager.gridSize.x ||
                location.y < 0 || location.y > _groundTilemapManager.gridSize.y
               )
            {
                return false;
            }

            Plant plant = plantType switch
            {
                PlantType.Potatoes => new Potato(potatoTiles, location),
                PlantType.Tomatoes => new Tomato(tomatoTiles, location),
                PlantType.Beets => new Beet(beetsTiles, location),
                _ => throw new ArgumentOutOfRangeException(nameof(plantType), plantType, null)
            };

            AddPlant(plant);

            return true;
        }

        private void Update()
        {
            foreach (Plant plant in _plants)
            {
                _groundTilemapManager.tilemap.SetTile(plant.Location, plant.GetTile());
            }
        }
    }

    public enum PlantType
    {
        Potatoes,
        Tomatoes,
        Beets
    }
}
