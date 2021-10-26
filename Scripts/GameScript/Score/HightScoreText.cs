using UnityEngine;
using UnityEngine.UI;

public class HightScoreText : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();

        ToRecodingHightScoreText();
    }

    public void ToRecodingHightScoreText()
    {
        _text.text = $"{PlayerPrefs.GetInt(GameData.HightScore)}";
    } 
}
