using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity1;
    [SerializeField] private int _capacity2;
    [SerializeField] private int _capacity3;
    [SerializeField] private int _capacity4;

    private readonly List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        Spawn(prefab, _capacity1);
        Spawn(prefab, _capacity2);
        Spawn(prefab, _capacity3);
        Spawn(prefab, _capacity4);
    }

    protected void Spawn(GameObject prefab, int capacity)
    {
        for (int i = 0; i < capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }
}