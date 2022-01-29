using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _encounterEnemy;
    [SerializeField] private UnityEvent _encounterItem;
    [SerializeField] private int _health;
    [SerializeField] private TMP_Text _textGold;
    [SerializeField] private TMP_Text _textTime;


    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;
    private string _stringMinutes;
    private string _stringSeconds;
    private float _gameSeconds;
    private float _gameMinutes;
    private bool _die = false;

    public static float GameMinutesOver { get; set; }
    public static float GameSecondsOver { get; set; }
    public static float Minutes { get; private set; }
    public static float Seconds { get; private set; }

    private void Start()
    {
        GameMinutesOver = 1.0f;
        GameSecondsOver = 30.0f;
        HealthChanged?.Invoke(_health);
    }

    private void Update()
    {
        _gameSeconds = _gameSeconds + Time.deltaTime + .0f;
        _stringSeconds = _gameSeconds.ToString("###");
        if (_gameMinutes != 0)
        {
            _stringMinutes = _gameMinutes.ToString() + ":";
        }
        else
        {
            _stringMinutes = "";
        }

        if (_gameSeconds >= 60.0f)
        {
            _gameMinutes++;
            _gameSeconds = 0.0f;
        }

        if (_gameMinutes >= GameMinutesOver && _gameSeconds >= GameSecondsOver)
        {
            SceneManager.LoadScene(2);
        }

        _textTime.text = "Время - " + _stringMinutes + _stringSeconds;

        if (_die == false) {
            Minutes = _gameMinutes;
            Seconds = _gameSeconds;
        }
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

    public void GetHealth(int health)
    {
        _health += health;
        _encounterItem?.Invoke();
        HealthChanged?.Invoke(_health);
    }

    public void Die()
    {
        _die = true;
        Died?.Invoke();
    }

    public void DisplayGold()
    {
        _encounterItem?.Invoke();
        _textGold.text = "Золото = " + Gold.Value;
    }
}