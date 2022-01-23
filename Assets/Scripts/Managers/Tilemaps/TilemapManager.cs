using System.Collections.Generic;
using UnityEngine;

namespace Managers.Tilemaps
{
    public class TilemapManager : MonoBehaviour
    {
        [SerializeField] public UnityEngine.Tilemaps.Tilemap tilemap;
        [SerializeField] public Vector2Int gridSize = new Vector2Int(3,3);

        protected IEnumerable<Vector3Int> GridIterator()
        {
            for (var x=0;x<gridSize.x;x++) {
                for (var y=0;y<gridSize.y;y++)
                {
                    yield return new Vector3Int(x, y, 0);
                }
            }
        }
    }
}
