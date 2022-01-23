using UnityEngine;
using UnityEngine.Tilemaps;

namespace Managers.Tilemap
{
    public class GroundTilemapManager : TilemapManager
    {
        [SerializeField] private TileBase grassTile;
        void Start()
        {
            BuildGround();
        }

        private void BuildGround()
        {
            foreach (Vector2Int vector2Int in GridIterator())
            {
                tilemap.SetTile(new Vector3Int(vector2Int.x, vector2Int.y, 0), grassTile);
            }
        }


        public void PlotTile(Vector3Int pos, Tile tile)
        {
            if (pos.x >= 0 && pos.y >= 0 && pos.x <= gridSize.x && pos.y <= gridSize.y)
            {
                Debug.Log("Plot tile" + tile + pos);
                tilemap.SetTile(pos, tile);    
            }
        }
    }
}
