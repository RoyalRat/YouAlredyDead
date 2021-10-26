public class GreenPotion : Item
{
    private Health _hp;

    private void Start()
    {
        OnPickedUp += GetGreenPotion;

        _hp = _player.gameObject.GetComponent<Health>();
    }

    private void Update()
    {
        ReactionToThePlayer();

        transform.Rotate(0, 1, 0);
    }

    private void GetGreenPotion()
    {
        OnPickedUp -= GetGreenPotion;

        _hp.TakeHP(1);

        Destroy(gameObject);
    }
}
