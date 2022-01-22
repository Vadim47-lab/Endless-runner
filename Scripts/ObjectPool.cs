using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity1;
    [SerializeField] private int _capacity2;
    [SerializeField] private int _capacity3;

    private readonly List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity1; i++)
        {
            Spawn(prefab);
        }

        for (int i = 0; i < _capacity2; i++)
        {
            Spawn(prefab);
        }

        for (int i = 0; i < _capacity3; i++)
        {
            Spawn(prefab);
        }
    }

    protected void Spawn(GameObject prefab)
    {
        GameObject spawned = Instantiate(prefab, _container.transform);
        spawned.SetActive(false);

        _pool.Add(spawned);
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }
}