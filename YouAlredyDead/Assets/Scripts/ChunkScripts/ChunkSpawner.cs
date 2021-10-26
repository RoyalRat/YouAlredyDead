using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private Chunk[] _chunkPrefab;

    [SerializeField] private Chunk _firstChunk;

    private List<Chunk> _chunkSpawned = new List<Chunk>();

    private void Start()
    {
        _chunkSpawned.Add(_firstChunk);
    }

    private void Update()
    {
        if (_player.position.z > _chunkSpawned[_chunkSpawned.Count - 1].End.position.z - 20)
        {
            ChunkSpawn();
        }
    }

    private void ChunkSpawn()
    {
        Chunk newChunk = Instantiate(_chunkPrefab[Random.Range(0, _chunkPrefab.Length)]);

        newChunk.transform.position = _chunkSpawned[_chunkSpawned.Count-1].End.position - newChunk.Begin.localPosition;

        _chunkSpawned.Add(newChunk);

        if (_chunkSpawned.Count >= 3)
        {
            Destroy(_chunkSpawned[0].gameObject);
            _chunkSpawned.RemoveAt(0);
            _chunkSpawned[0].ToSwapDoor();
        }
    }
}
