using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text _text;

    private int _scoreCurrent;

    private void Start()
    {
        _text = GetComponent<Text>();

        _text.text = $"{_scoreCurrent}";
    }

    public void TakeScore(int point)
    {
        _scoreCurrent += point;
        _text.text = $"{_scoreCurrent}";

        if (_scoreCurrent > HightScore.AllHightScore)
        {
            HightScore.ToRecordingHightScore(_scoreCurrent);
        }
    }
}