using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _encounterEnemy;
    [SerializeField] private int _health;

    public event UnityAction<int> HealthChanged;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);
        _encounterEnemy?.Invoke();

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        
    }
}