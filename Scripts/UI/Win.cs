using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
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
        SceneManager.LoadScene(1);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    private void OnPresentButtonClick()
    {
        _present.SetActive(false);
        _toy.SetActive(true);
    }
}