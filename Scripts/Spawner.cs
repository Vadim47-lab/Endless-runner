using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _pastTense = 0;

    private void Update()
    {
        _pastTense += Time.deltaTime;

        if (_pastTense >= _secondsBetweenSpawn)
        {
            _pastTense = 0;

            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
            Instantiate(_enemyPrefab, _spawnPoints[spawnPointNumber]);
        }
    }
}