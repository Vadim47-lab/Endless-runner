using UnityEngine;

public class EnemyMoveLeft : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.left);
    }
}