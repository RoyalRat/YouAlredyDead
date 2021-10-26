public class AmmoSpellBook : Item
{
    private Shooting _ammo;

    private void Start()
    {
        OnPickedUp += GetAmmoSpellBook;

        _ammo = _player.gameObject.GetComponent<Shooting>();
    }

    private void Update()
    {
        ReactionToThePlayer();

        transform.Rotate(0, 1, 0);
    }

    private void GetAmmoSpellBook()
    {
        OnPickedUp -= GetAmmoSpellBook;

        _ammo.TakeAmmo();

        Destroy(gameObject);
    }
}
