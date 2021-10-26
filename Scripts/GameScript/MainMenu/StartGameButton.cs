using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void LoadSceneGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
