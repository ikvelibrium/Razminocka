using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LocationSpawner : MonoBehaviour
{
   
    [SerializeField] Chunk[] ChunkPrefabs;
    [SerializeField] private Chunk _firstChunk;
    [SerializeField] private LayerMask _spawnWallLayer;
    [SerializeField] private int _chunksToSpawn;
    [SerializeField] private Chunk _chunkWithSpawnLinePref;
    private List<Chunk> _spawnedChunks = new List<Chunk>();
    private int _timesDeleted = 0;
    private int _lvlCounter = 0;
    private void Start()
    {
        _spawnedChunks.Add(_firstChunk);
        ChunkSpawn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _spawnWallLayer) > 0)
        {
            ChunkSpawn();
            DeleteChunks();
        }
    }
    
    private void DeleteChunks()
    {
        for (int i = 0; i < _chunksToSpawn; i++)
        {
            Destroy( _spawnedChunks[_timesDeleted].gameObject);
            _timesDeleted++;
        }
    }
    private void ChunkSpawn()
    {
        
        for (int i = 0; i < _chunksToSpawn + 1; i++)
        {
            if ( _lvlCounter % 3 == 0)
            {
                Chunk newChank = Instantiate(_chunkWithSpawnLinePref);
                newChank.transform.position = _spawnedChunks[_spawnedChunks.Count - 1]._endLvl.position - newChank._beginLvl.localPosition;
                _spawnedChunks.Add(newChank);
            } else
            {
                Chunk newChank = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
                newChank.transform.position = _spawnedChunks[_spawnedChunks.Count - 1]._endLvl.position - newChank._beginLvl.localPosition;
                _spawnedChunks.Add(newChank);
            }
            _lvlCounter++;
        }
        
    }
    
}