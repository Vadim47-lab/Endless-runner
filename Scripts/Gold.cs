using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField] private int gold;

    public static int Value { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Value += gold;
            player.DisplayGold();
        }

        Die();
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}