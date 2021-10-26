using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public int Count;
    public GameObject EnemyPrefab;
}
public class EnemySpawner : MonoBehaviour
{
    public int SpawnCurrency { get; private set; }

    [SerializeField] public List<GameObject> EnemiesOnScene;
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private Transform[] _enemiesStorage;

    private void Awake()
    {
        SpawnCurrency = 100;

        ToSpawnEnemys();
    }

    public void ToCheckCountEnemy()
    {
        if (_enemiesStorage[0].transform.childCount < 20) ToSpawnKnight();
        if (_enemiesStorage[1].transform.childCount < 20) ToSpawnBarbarian();
        if (_enemiesStorage[2].transform.childCount < 20) ToSpawnMage();
        if (_enemiesStorage[3].transform.childCount < 20) ToSpawnRogue();
    }

    public void ToSpawnEnemys()
    {
        for (int i = 0; i < _enemies.Count; i++)
            for (int j = 0; j < _enemies[i].Count; j++)
            {
                GameObject enemyObject = Instantiate(_enemies[i].EnemyPrefab);

                if (enemyObject.GetComponent<EnemyFeature>().Type == EnumEnemyType.Knight) enemyObject.transform.SetParent(_enemiesStorage[0]);
                else if (enemyObject.GetComponent<EnemyFeature>().Type == EnumEnemyType.Barbarian) enemyObject.transform.SetParent(_enemiesStorage[1]);
                else if (enemyObject.GetComponent<EnemyFeature>().Type == EnumEnemyType.Mage) enemyObject.transform.SetParent(_enemiesStorage[2]);
                else if (enemyObject.GetComponent<EnemyFeature>().Type == EnumEnemyType.Rogue) enemyObject.transform.SetParent(_enemiesStorage[3]);

                EnemiesOnScene.Add(enemyObject);
                enemyObject.SetActive(false);
            }
    }

    public void ToUpSpawnCurrency()
    {
        SpawnCurrency += 100;
    }

    private void ToSpawnBarbarian()
    {
        for (int i = 0; i < _enemies[0].Count; i++)
        {
            GameObject enemyObject = Instantiate(_enemies[0].EnemyPrefab);

            enemyObject.transform.SetParent(_enemiesStorage[1]);

            EnemiesOnScene.Add(enemyObject);
            enemyObject.SetActive(false);
        }
    }

    private void ToSpawnKnight()
    {
        for (int i = 0; i < _enemies[1].Count; i++)
        {
            GameObject enemyObject = Instantiate(_enemies[1].EnemyPrefab);

            enemyObject.transform.SetParent(_enemiesStorage[0]);

            EnemiesOnScene.Add(enemyObject);
            enemyObject.SetActive(false);
        }
    }

    private void ToSpawnMage()
    {
        for (int i = 0; i < _enemies[2].Count; i++)
        {
            GameObject enemyObject = Instantiate(_enemies[2].EnemyPrefab);

            enemyObject.transform.SetParent(_enemiesStorage[2]);

            EnemiesOnScene.Add(enemyObject);
            enemyObject.SetActive(false);
        }
    }

    private void ToSpawnRogue()
    {
        for (int i = 0; i < _enemies[3].Count; i++)
        {
            GameObject enemyObject = Instantiate(_enemies[3].EnemyPrefab);

            enemyObject.transform.SetParent(_enemiesStorage[3]);

            EnemiesOnScene.Add(enemyObject);
            enemyObject.SetActive(false);
        }
    }

    
}