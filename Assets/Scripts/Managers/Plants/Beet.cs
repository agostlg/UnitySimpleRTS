using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Managers.Plants
{
    public class Beet: Plant
    {
        public Beet(List<Tile> tiles, Vector3Int location) : base(tiles, location)
        {
        }
    }
}