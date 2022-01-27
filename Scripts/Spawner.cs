using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _prefabTemplates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn1;

    private float _pastTense = 0;
    public static float SecondsBetweenSpawn2 { get; set; }

    private void Start()
    {
        Initialize(_prefabTemplates);
    }

    private void Update()
    {
        if (MainMenuGame.ChangeSpawnSeconds == true)
        {
            _secondsBetweenSpawn1 = SecondsBetweenSpawn2;
        }

        _pastTense += Time.deltaTime;

        if (_pastTense >= _secondsBetweenSpawn1)
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