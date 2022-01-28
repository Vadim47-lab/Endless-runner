using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private UnityEvent _buttonPress;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _textGold;
    [SerializeField] private TMP_Text _textTime;
    [SerializeField] private Player _player;
    [SerializeField] private Gold _gold;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void Start()
    {
        _textGold.text = "Золото = " + Gold.Value;
        _textTime.text = "Время - " + Player.Minutes + Player.Seconds;
    }

    private void OnRestartButtonClick()
    {
        EventButtonPress();

        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    private void OnExitButtonClick()
    {
        EventButtonPress();

        Application.Quit();
    }

    private void EventButtonPress()
    {
        _buttonPress?.Invoke();
    }
}