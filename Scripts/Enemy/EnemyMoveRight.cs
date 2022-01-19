using UnityEngine;

public class EnemyMoveRight : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.right);
    }
}
