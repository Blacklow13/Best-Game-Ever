using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyAI enemyPrefab;
    public PlayerController player;
    public List<Transform> patrolPoints;
    public PlayerProgress playerProgress;

    public int enemiesMaxCount = 8;
    public float delay = 7;
    public float increaseEnemiesCountDelay = 20;

    private List<Transform> _spawnerPoints;
    private List<EnemyAI> _enemies;

    private float _timeLastSpawned;

    private void Start()
    {
        _enemies = new List<EnemyAI>();
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        Invoke("IncreaseEnemiesMaxCount", increaseEnemiesCountDelay);
    }


    private void Update()
    {
        CheckForDeadEnemies();
        CreateEnemy();

    }

    private void IncreaseEnemiesMaxCount()
    {
        enemiesMaxCount++;
        Invoke("IncreaseEnemiesMaxCount", increaseEnemiesCountDelay);
    }

    private void CheckForDeadEnemies()
    {
        for (var i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i].IsAlive()) continue;
            _enemies.RemoveAt(i);
            i--;
        }
        if (_enemies.Count >= enemiesMaxCount) return;
        if (Time.time - _timeLastSpawned < delay) return; for (var i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i].IsAlive()) continue;
            _enemies.RemoveAt(i);
            i--;
        }
        if (_enemies.Count >= enemiesMaxCount) return;
        if (Time.time - _timeLastSpawned < delay) return;
    }

    private void CreateEnemy()
    {
        if (_enemies.Count >= enemiesMaxCount) return;
        if (Time.time - _timeLastSpawned < delay) return;
        var enemy = Instantiate(enemyPrefab);
        enemy.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;
        enemy.player = player;
        enemy.patrolPoints = patrolPoints;
        enemy.enemyHealth.playerProgress = playerProgress;
        _enemies.Add(enemy);
        _timeLastSpawned =  Time.time;
    }   
}
