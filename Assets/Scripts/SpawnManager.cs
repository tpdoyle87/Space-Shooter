using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPreFab;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawning = false;
    [SerializeField]
    private float _spawnTimer = 3f;
    private float _spawnSpeedIncrease = 15f;
    private float _timePassed;
    
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    void Update()
    {
        _timePassed = Time.realtimeSinceStartup; 
        if (_spawnSpeedIncrease < _timePassed)
        {
            _spawnTimer -= 0.1f;
            _spawnSpeedIncrease += _spawnSpeedIncrease;
        }
    }

    public void onPlayerDeath()
    {
        _stopSpawning = true;
    }
    IEnumerator SpawnRoutine()
    {
        while (_stopSpawning  == false)
        {
            GameObject newEnemy = Instantiate(_enemyPreFab);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_spawnTimer);
        }
    }
}
