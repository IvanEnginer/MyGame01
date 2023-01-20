using System.Collections;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyTemplates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _timeBetweenSpawned = 2f;
    [SerializeField] private bool _isEnabelSpawn = true;


    private void Start()
    {
        Initilize(_enemyTemplates);

        StartCoroutine(Spawned());
    }

    private IEnumerator Spawned()
    {
        var waitForSpawnedSeconds = new WaitForSeconds(_timeBetweenSpawned);

        while(_isEnabelSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            }

            yield return waitForSpawnedSeconds;
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
