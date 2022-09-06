using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;

    public void Spawn()
    {
        Instantiate(_prefab, transform.position, quaternion.identity);
    }
}