using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ObjectPull;

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

    private PullBase<Chunk> _pullBase;
    private void Start()
    {
        _pullBase = new PullBase<Chunk>(Preload,GetAction, ReturnAction, 10);
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
            _pullBase.Return(_spawnedChunks[1]);
           
            
        }
    }
    private void ChunkSpawn()
    {

        
        for (int i = 0; i < _chunksToSpawn; i++)
        {                                      
             Chunk newChank = _pullBase.Get();
             newChank.transform.position = _spawnedChunks[_spawnedChunks.Count - 1]._endLvl.position - newChank._beginLvl.localPosition;
             _spawnedChunks.Add(newChank);                            
            _lvlCounter++;
        }
        
    }

    public Chunk Preload() => Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
    public void GetAction(Chunk chunk) => chunk.gameObject.SetActive(true);
    public void ReturnAction(Chunk chunk) => chunk.gameObject.SetActive(false);



}