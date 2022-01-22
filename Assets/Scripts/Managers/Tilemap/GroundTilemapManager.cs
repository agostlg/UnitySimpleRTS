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
    }
}
