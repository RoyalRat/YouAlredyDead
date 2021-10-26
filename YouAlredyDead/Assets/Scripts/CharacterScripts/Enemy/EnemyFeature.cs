using UnityEngine;

public class EnemyFeature : MonoBehaviour
{
    public EnumEnemyType Type;

    public int SpawnPrice { get; private set; }
    public int ScorePrice { get; private set; }
    public int AttackSpeedVolume { get; private set; }

    private void Awake()
    {
        SpawnPrice = GivingSpawnPrice();
        ScorePrice = GivingScorePrice();
    }

    private int GivingSpawnPrice()
    {
        int price = 0;

        switch (Type)
        {
            case EnumEnemyType.Barbarian: price = 40; break;
            case EnumEnemyType.Knight: price = 50; break;
            case EnumEnemyType.Rogue: price = 30; break;
            case EnumEnemyType.Mage: price = 100; break;
        }

        return price;
    }

    private int GivingScorePrice()
    {
        int score = 0;

        switch (Type)
        {
            case EnumEnemyType.Barbarian: score = 4; break;
            case EnumEnemyType.Knight: score = 5; break;
            case EnumEnemyType.Rogue: score = 3; break;
            case EnumEnemyType.Mage: score = 10; break;
        }

        return score;
    }

    private void AttackSpeed()
    {
        if (Type == EnumEnemyType.Mage)
        {
            AttackSpeedVolume = 3;
        }
        else
        {
            AttackSpeedVolume = 1;
        }
    }
}
