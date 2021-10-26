using UnityEngine;

public class HightScore : MonoBehaviour
{
    public static int AllHightScore { get; private set; }

    private void Start()
    {
        AllHightScore = PlayerPrefs.GetInt(GameData.HightScore);
    }

    public static void ToRecordingHightScore(int score)
    {
        PlayerPrefs.SetInt(GameData.HightScore, score);

        AllHightScore = PlayerPrefs.GetInt(GameData.HightScore);

        PlayerPrefs.Save();
    }
}
