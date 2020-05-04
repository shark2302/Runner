using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawningSpots;

    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private GameObject _heelPrefab;
    [SerializeField] private float _timeBetweenSpawnsOfEnemies;
    [SerializeField] private float _timeBetweenSpawnsOfHeels;
    private float _spawnTime;
    private float _heelTime;

    private void Start()
    {
        _heelTime = _timeBetweenSpawnsOfHeels;
    }

    void Update()
    {
       
        if (_spawnTime <= 0)
        {
            Instantiate(_prefabToSpawn, _spawningSpots[Random.Range(0, 3)].position, Quaternion.identity);
            _spawnTime = _timeBetweenSpawnsOfEnemies;
        }
        else
            _spawnTime -= Time.deltaTime;
        
        if (_heelTime <= 0)
        {
            Instantiate(_heelPrefab, _spawningSpots[Random.Range(0, 3)].position, Quaternion.identity);
            _heelTime = _timeBetweenSpawnsOfHeels;
        }
        else
            _heelTime -= Time.deltaTime;

      
    }
}
