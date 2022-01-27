using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] private UnityEvent _buttonPress;
    [SerializeField] private GameObject _present;
    [SerializeField] private GameObject _toy;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _presentButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
        _presentButton.onClick.AddListener(OnPresentButtonClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClick);
        _presentButton.onClick.RemoveListener(OnPresentButtonClick);
    }

    private void OnRestartButtonClick()
    {
        EventButtonPress();

        SceneManager.LoadScene(1);
    }

    private void OnExitButtonClick()
    {
        EventButtonPress();

        Application.Quit();
    }

    private void OnMainMenuButtonClick()
    {
        EventButtonPress();

        SceneManager.LoadScene(0);
    }

    private void OnPresentButtonClick()
    {
        EventButtonPress();

        _present.SetActive(false);
        _toy.SetActive(true);
    }

    private void EventButtonPress()
    {
        _buttonPress?.Invoke();
    }
}