using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Managers.Plants
{
    public class Tomato: Plant
    {
        public Tomato(List<Tile> tiles, Vector3Int location) : base(tiles, location)
        {
        }
    }
}