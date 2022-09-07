using System.Collections;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;

    private float _spawnDelay = 2f;
    
    private void Start()
    {
        StartCoroutine(Spawn());
    }
    
    private IEnumerator Spawn()
    {
        var waitForSeconds = new WaitForSeconds(_spawnDelay);
        
        foreach (var spawner in _spawners)
        {
            spawner.Spawn();
            yield return waitForSeconds;
        }
    }
}