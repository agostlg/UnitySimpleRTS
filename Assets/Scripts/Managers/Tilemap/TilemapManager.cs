using System.Collections.Generic;
using UnityEngine;

namespace Managers.Tilemap
{
    public class TilemapManager : MonoBehaviour
    {
        [SerializeField] protected UnityEngine.Tilemaps.Tilemap tilemap;
        [SerializeField] private Vector2Int gridSize = new Vector2Int(3,3);

        protected IEnumerable<Vector2Int> GridIterator()
        {
            for (var x=0;x<gridSize.x;x++) {
                for (var y=0;y<gridSize.y;y++)
                {
                    yield return new Vector2Int(x, y);
                }
            }
        }
    }
}
