using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ScriptableTiles
{
    [CreateAssetMenu(menuName = "PotatoTile")]
    public class PotatoTile : Tile
    {
        [SerializeField] private Tile seedTile;
        [SerializeField] private Tile babyTile;
        [SerializeField] private Tile adultTile;
        [SerializeField] private Tile deadTile;


        private Phase _currentPhase = Phase.Seed;
        private float time = 0f;
        private float maxTime = 10f;

        public void Evolve()
        {
            time += Time.deltaTime;
            if (time > maxTime)
            {
                time = 0f;
                switch (_currentPhase)
                {
                    case Phase.Seed:
                        _currentPhase = Phase.Baby;
                        break;
                    case Phase.Baby:
                        _currentPhase = Phase.Adult;
                        break;
                    case Phase.Adult:
                        _currentPhase = Phase.Dead;
                        break;
                }
                
                Debug.Log("Evolved to Phase " + _currentPhase);
            }
        }

        public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData)
        {
            if (_currentPhase != Phase.Dead)
            {
                Evolve();                
            }

            switch (_currentPhase)
            {
                case Phase.Seed:
                    sprite = seedTile.sprite;
                    break;
                case Phase.Baby:
                    sprite = babyTile.sprite;
                    break;
                case Phase.Adult:
                    sprite = adultTile.sprite;
                    break;
                case Phase.Dead:
                    sprite = deadTile.sprite;
                    break;
            }

            tileData.sprite = sprite;
            base.GetTileData(location, tilemap, ref tileData);
        }
    }

    public enum Phase
    {
        Seed,
        Baby,
        Adult,
        Dead
    }
}