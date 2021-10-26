using UnityEngine;

public class HightScoreButton : MonoBehaviour
{
    [SerializeField] private HightScoreText _hightScoreText;
    [SerializeField] private GameObject _hightScoreButton;

    private void Start()
    {
        if (PlayerPrefs.GetInt(GameData.HightScore) > 0)
            _hightScoreButton.SetActive(true);
    }

    public void DeleteHightScore()
    {
        PlayerPrefs.DeleteKey(GameData.HightScore);

        _hightScoreText.ToRecodingHightScoreText();
    }
}
