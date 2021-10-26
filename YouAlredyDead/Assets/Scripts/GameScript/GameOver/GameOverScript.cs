using System.Collections;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private Health _playerHP;
    [SerializeField] private GameObject _gameOverPalnel;

    private void Start()
    {
        Time.timeScale = 1;

        _gameOverPalnel.SetActive(false);
        _playerHP.OnDeath += StartCorruntine;
    }

    private void StartCorruntine()
    {
        StartCoroutine(nameof(GameOver));
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.2f);

        Time.timeScale = 0;

        _playerHP.gameObject.GetComponent<PlayerMovemed>().enabled = false;
        _playerHP.gameObject.GetComponent<Shooting>().enabled = false;

        _gameOverPalnel.SetActive(true);
    }
}
