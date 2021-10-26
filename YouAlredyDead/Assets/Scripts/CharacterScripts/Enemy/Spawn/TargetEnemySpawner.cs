using UnityEngine;

public class TargetEnemySpawner : MonoBehaviour
{
    private GameObject _enemy;
    private EnemySpawner _enemySpawner;
    private Transform _targetEnemySpawner;

    private void Awake()
    {
        _targetEnemySpawner = GetComponent<Transform>();

        _enemySpawner = GameObject.FindGameObjectWithTag("Game").GetComponent<EnemySpawner>();

       ToEnemiesSpawned();
    }

    private void ToEnemiesSpawned()
    {
        int enemyCount = 0;
        _enemySpawner.ToCheckCountEnemy();

        if (_enemySpawner.SpawnCurrency >= 100)
        {
            int currency = _enemySpawner.SpawnCurrency;

            while (currency >= 30 && enemyCount <= 20)
            {
                int rmd = Random.Range(0, _enemySpawner.EnemiesOnScene.Count);
                _enemy = _enemySpawner.EnemiesOnScene[rmd];

                int price = _enemy.GetComponent<EnemyFeature>().SpawnPrice;

                if (currency - price >= 0)
                {
                    _enemySpawner.EnemiesOnScene.RemoveAt(rmd);

                    _enemy.transform.position = _targetEnemySpawner.position;
                    _enemy.transform.SetParent(_targetEnemySpawner);

                    _enemy.SetActive(true);

                    currency -= price;
                }
                else continue;

                enemyCount++;
            }

            _enemySpawner.ToUpSpawnCurrency();
        }
    }
}
