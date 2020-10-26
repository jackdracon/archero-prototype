using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Spawn Manager responsable to create object
public class SpawnManager : MonoBehaviour
{
    [SerializeField, Tooltip("Spawn Player tag object")]
    private string spawnPlayerTag = "";

    [SerializeField, Tooltip("Spawn Enemy tag object")]
    private string spawnEnemyTag = "";

    [SerializeField, Tooltip("Enemies entities prefabs")]
    private GameObject[] enemies;

    [SerializeField, Tooltip("Player prefab")]
    private GameObject player;

    //enemies created 
    private int currentEnemies = 0;

    //Spawn objects related to enemy Collection
    private GameObject[] spawnEnemyObjs;
    
    //Spawn Player 
    private GameObject spawnPlayer;

    private void Awake()
    {
        spawnEnemyObjs = GameObject.FindGameObjectsWithTag(spawnEnemyTag);

        spawnPlayer = GameObject.FindGameObjectWithTag(spawnPlayerTag);
    }

    //Create Player 
    public void CreatePlayer()
    {
        GameObject _player = Instantiate(player) as GameObject;
        _player.transform.position = spawnPlayer.transform.position;
    }

    //Create enemies in all spawn point objects
    public void CreateAllEnemies()
    {
        foreach (GameObject _spawnPoint in spawnEnemyObjs)
        {
            CreateEnemy(_spawnPoint);
        }
    }

    //CreateEnemy on specific spawn point object
    public void CreateEnemy(GameObject _spawnPoint)
    {
        GameObject _obj = PickEnemy();
        GameObject _enemy = Instantiate(_obj) as GameObject;
        _enemy.transform.position = _spawnPoint.transform.position;
        currentEnemies++;
    }

    //Select enemy from enemies's array
    private GameObject PickEnemy()
    {
        int _id = UnityEngine.Random.Range(0, enemies.Length - 1);
        return enemies[_id];
    }

    //Get enemies count 
    public int GetEnemiesCount
    {
        get { return currentEnemies; }
    }
}
