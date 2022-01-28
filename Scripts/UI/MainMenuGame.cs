using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuGame : MonoBehaviour
{
    [SerializeField] private UnityEvent _buttonPress;
    [SerializeField] private GameObject _help;
    [SerializeField] private GameObject _settings;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _openHelpButton;
    [SerializeField] private Button _closeHelpButton;

    [SerializeField] private Button _openSettingsButton;
    [SerializeField] private Button _closeSettingsButton;

    [SerializeField] private Button _plusMinutesButton;
    [SerializeField] private Button _minusMinutesButton;

    [SerializeField] private Button _plusSecondsButton;
    [SerializeField] private Button _minusSecondsButton;

    [SerializeField] private Button _plusSpawnSecondsButton;
    [SerializeField] private Button _minusSpawnSecondsButton;

    [SerializeField] private TMP_Text _textMinutesGameOver;
    [SerializeField] private TMP_Text _textSecondsGameOver;
    [SerializeField] private TMP_Text _textSpawnSeconds;

    private CanvasGroup _gameOverGroup;
    
    public static bool ChangeSpawnSeconds { get; private set; }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _openHelpButton.onClick.AddListener(OnOpenHelpButtonClick);
        _closeHelpButton.onClick.AddListener(OnCloseHelpButtonClick);

        _openSettingsButton.onClick.AddListener(OnOpenSettingsButtonClick);
        _closeSettingsButton.onClick.AddListener(OnCloseSettingsButtonClick);

        _plusMinutesButton.onClick.AddListener(OnPlusMinutesButtonClick);
        _minusMinutesButton.onClick.AddListener(OnMinusMinutesButtonClick);

        _plusSecondsButton.onClick.AddListener(OnPlusSecondsButtonClick);
        _minusSecondsButton.onClick.AddListener(OnMinusSecondsButtonClick);

        _plusSpawnSecondsButton.onClick.AddListener(OnPlusSpawnSecondsButtonClick);
        _minusSpawnSecondsButton.onClick.AddListener(OnMinusSpawnSecondsButtonClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _openHelpButton.onClick.RemoveListener(OnOpenHelpButtonClick);
        _closeHelpButton.onClick.RemoveListener(OnCloseHelpButtonClick);

        _openSettingsButton.onClick.RemoveListener(OnOpenSettingsButtonClick);
        _closeSettingsButton.onClick.RemoveListener(OnCloseSettingsButtonClick);

        _plusMinutesButton.onClick.RemoveListener(OnPlusMinutesButtonClick);
        _minusMinutesButton.onClick.RemoveListener(OnMinusMinutesButtonClick);

        _plusSecondsButton.onClick.RemoveListener(OnPlusSecondsButtonClick);
        _minusSecondsButton.onClick.RemoveListener(OnMinusSecondsButtonClick);

        _plusSpawnSecondsButton.onClick.RemoveListener(OnPlusSpawnSecondsButtonClick);
        _minusSpawnSecondsButton.onClick.RemoveListener(OnMinusSpawnSecondsButtonClick);
    }

    private void Start()
    {
        ChangeSpawnSeconds = false;
        Player.GameMinutesOver = 1.0f;
        Player.GameSecondsOver = 30.0f;
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 1;

        DisplaySecondsGameOver();
        DisplayMinutesGameOver();
        DisplaySecondsSpawn();

    }

    private void OnStartButtonClick()
    {
        EventButtonPress();

        SceneManager.LoadScene(1);
    }

    private void OnExitButtonClick()
    {
        EventButtonPress();

        Application.Quit();
    }

    private void OnOpenHelpButtonClick()
    {
        EventButtonPress();

        _help.SetActive(true);
    }

    private void OnCloseHelpButtonClick()
    {
        EventButtonPress();

        _help.SetActive(false);
    }

    private void OnOpenSettingsButtonClick()
    {
        EventButtonPress();

        _settings.SetActive(true);
    }

    private void OnCloseSettingsButtonClick()
    {
        EventButtonPress();

        _settings.SetActive(false);
    }

    private void OnPlusMinutesButtonClick()
    {
        EventButtonPress();

        Player.GameMinutesOver++;
        DisplayMinutesGameOver();
    }

    private void OnMinusMinutesButtonClick()
    {
        EventButtonPress();

        Player.GameMinutesOver--;
        DisplayMinutesGameOver();
    }

    private void OnPlusSecondsButtonClick()
    {
        EventButtonPress();

        Player.GameSecondsOver++;
        DisplaySecondsGameOver();
    }

    private void OnMinusSecondsButtonClick()
    {
        EventButtonPress();

        Player.GameSecondsOver--;
        DisplaySecondsGameOver();
    }

    private void OnPlusSpawnSecondsButtonClick()
    {
        ChangeSpawnSeconds = true;
        EventButtonPress();

        Spawner.SecondsBetweenSpawn2++;
        DisplaySecondsSpawn();
    }

    private void OnMinusSpawnSecondsButtonClick()
    {
        ChangeSpawnSeconds = true;
        EventButtonPress();

        Spawner.SecondsBetweenSpawn2--;
        DisplaySecondsSpawn();
    }

    private void EventButtonPress()
    {
        _buttonPress?.Invoke();
    }

    private void DisplayMinutesGameOver()
    {
        _textMinutesGameOver.text = "минуты = " + Player.GameMinutesOver;
    }

    private void DisplaySecondsGameOver()
    {
        _textSecondsGameOver.text = "секунды = " + Player.GameSecondsOver;
    }

    private void DisplaySecondsSpawn()
    {
        _textSpawnSeconds.text = "Количество секунд для спавна = " + Spawner.SecondsBetweenSpawn2;
    }
}