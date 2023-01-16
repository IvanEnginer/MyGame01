using System.Collections;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyTemplates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _framesBetweenSpawn = 2000f;


    private void Start()
    {
        Initilize(_enemyTemplates);

        StartCoroutine(Spawned());
    }

    private IEnumerator Spawned()
    {
        for(int i = 0; i < _framesBetweenSpawn; i++)
        {
            yield return null;
        }

        if (TryGetObject(out GameObject enemy))
        {
            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

            SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
        }

        StartCoroutine(Spawned());
    }

private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
