using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;

    private float _spawnDelay = 2f;
    
    private void Start()
    {
        StartCoroutine(Spawn());
    }
    
    private IEnumerator Spawn()
    {
        foreach (var spawner in _spawners)
        {
            spawner.Spawn();
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}