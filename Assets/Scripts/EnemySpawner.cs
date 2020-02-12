using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawningPosition;
    public GameObject enemyPrefab;


    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnEnemies", 0f, 1f);
    }

    void SpawnEnemies()
    {
        //Instantiate(enemyPrefab, spawningPosition);       
        GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject("Enemy");
        if (enemy != null)
        {
            enemy.transform.position = spawningPosition.position;
            enemy.transform.rotation = spawningPosition.rotation;
            enemy.SetActive(true);
        }        
    }
}