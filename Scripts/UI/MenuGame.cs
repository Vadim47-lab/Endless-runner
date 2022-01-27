using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    [SerializeField] private UnityEvent _buttonPress;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _returnMainMenuButton;

    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(OnContinueButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _returnMainMenuButton.onClick.AddListener(OnReturnMainMenuClick);
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(OnContinueButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _returnMainMenuButton.onClick.RemoveListener(OnReturnMainMenuClick);
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            _gameOverGroup.alpha = 1;
        }
    }

    private void OnContinueButtonClick()
    {
        EventButtonPress();

        Time.timeScale = 1;
        _gameOverGroup.alpha = 0;
    }

    private void OnExitButtonClick()
    {
        EventButtonPress();

        Application.Quit();
    }

    private void OnReturnMainMenuClick()
    {
        EventButtonPress();

        SceneManager.LoadScene(0);
    }

    private void EventButtonPress()
    {
        _buttonPress?.Invoke();
    }
}