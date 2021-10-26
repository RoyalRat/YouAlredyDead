using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int CurrentAmmo { get; private set; }
    public int CurrentStrongAmmo { get; private set; }

    [SerializeField] private Transform _firePoint;
    [SerializeField] private Transform _fireTarget;
    [Space]
    [SerializeField] private List<GameObject> _projectiles;
    [Space]
    [SerializeField] private float _bulleteForce;

    [SerializeField] private GameObject _activeProjectile;
    private Rigidbody _rb;

    private void Start()
    {
        _activeProjectile = _projectiles[0];

        CurrentAmmo = 50;
        CurrentStrongAmmo = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CurrentAmmo > 0 || CurrentStrongAmmo > 0)
            {
                AccountingAmmo();

                GameObject projectile = Instantiate(_activeProjectile, _firePoint.position, Quaternion.identity);

                _rb = projectile.GetComponent<Rigidbody>();

                _rb.AddForce((_fireTarget.position - _firePoint.position) * _bulleteForce, ForceMode.Impulse);
            }
        }
    }
    public void AccountingAmmo()
    {
        if (_activeProjectile == _projectiles[0])
        {
            CurrentAmmo -= 1;

            if (CurrentAmmo < 0)
            {
                CurrentAmmo = 0;
            }
        }
        else if (_activeProjectile == _projectiles[1])
        {
            CurrentStrongAmmo -= 1;

            if (CurrentStrongAmmo < 0)
            {
                CurrentStrongAmmo = 0;

                TrySwitchAmmo();
            }
        }
    }

    public void TakeAmmo()
    {
        CurrentAmmo += 50;

        if (CurrentAmmo > 50)
        {
            CurrentAmmo = 50;
        }

        TrySwitchAmmo();
    }

    public void TakeStrongAmmo()
    {
        CurrentStrongAmmo += 5;

        if (CurrentStrongAmmo > 15)
        {
            CurrentStrongAmmo = 15;
        }

        TrySwitchAmmo();
    }

    public void TrySwitchAmmo()
    {
        if (CurrentStrongAmmo > 0)
        {
            _activeProjectile = _projectiles[1];
        }
        else
        {
            _activeProjectile = _projectiles[0];
        }
    }
}