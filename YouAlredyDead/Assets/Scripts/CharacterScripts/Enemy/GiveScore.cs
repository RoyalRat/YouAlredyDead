using UnityEngine;

[RequireComponent(typeof(Health))]
public class GiveScore : MonoBehaviour
{
    public ScoreText Score;

    private Health _HP;
    private EnemyFeature _type;

    private void Start()
    {
        _HP = GetComponent<Health>();

        _type = GetComponent<EnemyFeature>();

        Score = FindObjectOfType<ScoreText>();

        _HP.OnDeath += SendScore;
    }

    private void SendScore()
    {
        Score.TakeScore(_type.ScorePrice);
    }
}
