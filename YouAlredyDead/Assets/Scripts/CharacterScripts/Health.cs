using UnityEngine;

public class Health : MonoBehaviour
{
    public delegate void Damage();
    public event Damage OnTakeDamage;

    public delegate void TakeHealth();
    public event TakeHealth OnHealth;

    public delegate void Death();
    public event Death OnDeath;

    public int CurrentHealth;
    public bool IsAlive;

    public void TakeDamage(int dmg)
    {
        IsAlive = true;

        CurrentHealth -= dmg;

        if (CurrentHealth <= 0)
        {
            OnDeath?.Invoke();

            ToDeathEnemy();

            IsAlive = false;
            CurrentHealth = 0;
        }

        OnTakeDamage?.Invoke();
    }

    public void TakeHP(int health)
    {
        CurrentHealth += health;

        OnHealth?.Invoke();
    }

    private void ToDeathEnemy()
    {
        if (GetComponent<EnemyFeature>())
        {
            Destroy(gameObject);
        }
    }
}
