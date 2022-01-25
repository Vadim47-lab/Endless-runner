using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] private int _increaseHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.GetHealth(_increaseHealth);
        }

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}