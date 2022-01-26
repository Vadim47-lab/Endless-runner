using UnityEngine;
using TMPro;

public class Gold : MonoBehaviour
{
    [SerializeField] private int gold;

    public int Value { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Value += gold;
            player.DisplayGold();
            Debug.Log("Количество золота = " + Value);
        }

        Die();
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}