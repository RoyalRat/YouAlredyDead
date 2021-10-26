public class CandyStrong : Item
{
    private Shooting _shooting;

    private void Start()
    {
        _shooting = FindObjectOfType<Shooting>();

        OnPickedUp += ActiveBuff;
    }
    private void Update()
    {
        ReactionToThePlayer();

        transform.Rotate(0, 1, 0);
    }

    private void ActiveBuff()
    {
        OnPickedUp -= ActiveBuff;

        _shooting.TakeStrongAmmo();

        Destroy(gameObject);
    }
}
