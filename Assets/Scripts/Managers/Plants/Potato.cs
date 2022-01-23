using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Managers.Plants
{
    public class Potato: Plant
    {
        public Potato(List<Tile> tiles, Vector3Int location) : base(tiles, location)
        {
        }
    }
}