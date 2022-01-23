using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Managers.Tilemaps
{
    public class GroundTilemapManager : TilemapManager
    {
        [SerializeField] private TileBase grassTile;
        private float _time;
        private const float MaxTime = 1.0f;

        void Start()
        {
            BuildGround();
        }

        private void BuildGround()
        {
            foreach (Vector3Int vector3Int in GridIterator())
            {
                tilemap.SetTile(vector3Int, grassTile);
            }
        }

        public bool PlotTile(Vector3Int pos, Tile tile)
        {
            if (pos.x >= 0 && pos.y >= 0 && pos.x <= gridSize.x && pos.y <= gridSize.y)
            {
                Debug.Log("Plot tile" + tile + pos);
                tilemap.SetTile(pos, tile);

                return true;
            }

            return false;
        }
        
        private void Update()
        {
            foreach (Vector3Int vector3Int in GridIterator())
            {
                tilemap.RefreshTile(vector3Int);
            }
            _time += Time.deltaTime;

            if (_time > MaxTime)
            {
                _time = 0f;
                tilemap.RefreshAllTiles();
            }
        }
    }
}
