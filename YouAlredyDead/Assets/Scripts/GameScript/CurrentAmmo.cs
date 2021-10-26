using UnityEngine;
using UnityEngine.UI;

public class CurrentAmmo : MonoBehaviour
{
    [SerializeField] private Shooting _ammo;

    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        if (_ammo.CurrentAmmo >= 10)
        {
            _text.text = $"{_ammo.CurrentAmmo}";
        }
        else
        {
            _text.text = $"{0}{_ammo.CurrentAmmo}";
        }
    }
}
