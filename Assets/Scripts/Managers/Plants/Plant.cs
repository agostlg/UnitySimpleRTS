using System.Collections.Generic;
using Managers.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Managers.Plants
{
    public class Plant
    {
        public Vector3Int Location;

        private readonly List<Tile> _tiles;
        private Tile _currentTile;

        private float _time = 0f;
        private float maxTime = 5f;


        protected Plant(List<Tile> tiles, Vector3Int location)
        {
            _tiles = tiles;
            _currentTile = tiles[0];
            Location = location;
        }

        private void Evolve()
        {
            _time += Time.deltaTime;
            if (_time > maxTime)
            {
                _time = 0f;
                _currentTile = _tiles[_tiles.IndexOf(_currentTile) + 1];

                Debug.Log("Evolved to " + _currentTile);
            }
        }

        public Tile GetTile()
        {
            if (_tiles.IndexOf(_currentTile) + 1 < _tiles.Count)
            {
                Evolve();
            }

            return _currentTile;
        }
    }
}