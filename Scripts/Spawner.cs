using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _prefabTemplates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _pastTense = 0;

    private void Start()
    {
        Initialize(_prefabTemplates);
    }

    private void Update()
    {
        _pastTense += Time.deltaTime;

        if (_pastTense >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _pastTense = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);

            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}