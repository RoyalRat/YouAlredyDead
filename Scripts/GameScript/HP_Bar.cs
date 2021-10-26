using UnityEngine;
using UnityEngine.UI;

public class HP_Bar : MonoBehaviour
{
    [SerializeField] private Health _HP;
    [Space]
    [SerializeField] private Sprite _bloodSkull;
    [SerializeField] private Sprite _normalSkull;
    [Space]
    [SerializeField] private Image[] _skull;

    private int dmgCounter = 0;

    private void Start()
    {
        _HP.OnTakeDamage += IsDamage;
        _HP.OnHealth += TryHealth;
    }

    private void IsDamage()
    {
        _skull[dmgCounter].sprite = _bloodSkull;
        dmgCounter++;

        if (dmgCounter > 2)
        {
            dmgCounter = 2;
        }
    }

    private void TryHealth()
    {
        if (dmgCounter > 0)
        {
            dmgCounter--;
            _skull[dmgCounter].sprite = _normalSkull;
        }

        if (dmgCounter < 0)
        {
            dmgCounter = 0;
        }
    }
}
