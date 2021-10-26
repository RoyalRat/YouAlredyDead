public class GodCup : Item
{
    private  ScoreText _score;

    private void Start()
    {
        _score = FindObjectOfType<ScoreText>();

        OnPickedUp += SendScore;
    }
    private void Update()
    {
        ReactionToThePlayer();

        transform.Rotate(0, 1, 0);
    }

    private void SendScore()
    {
        OnPickedUp -= SendScore;

        _score.TakeScore(100);

        Destroy(gameObject);
    }
}
