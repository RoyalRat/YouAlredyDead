using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _player;

    private Playerinput _playerInput;
    private PlayerMovemed _playerMovemed;
    private Shooting _shooting;

    private void Awake()
    {
        _playerInput = _player.GetComponent<Playerinput>();
        _playerMovemed = _player.GetComponent<PlayerMovemed>();
        _shooting = _player.GetComponent<Shooting>();
    }

    public void ToPause()
    {
        Time.timeScale = 0;

        _playerInput.enabled = false;
        _playerMovemed.enabled = false;
        _shooting.enabled = false;

        _pauseMenu.SetActive(true);
    }

    public void ToContinue()
    {
        Time.timeScale = 1;

        _playerInput.enabled = true;
        _playerMovemed.enabled = true;
        _shooting.enabled = true;

        _pauseMenu.SetActive(false);
    }

    public void ToMenu()
    {
        Time.timeScale = 1;

        _playerInput.enabled = true;
        _playerMovemed.enabled = true;
        _shooting.enabled = true;

        _pauseMenu.SetActive(false);

        SceneManager.LoadScene(0);
    }

    public void ToQuit()
    {
        Application.Quit();
    }
}
