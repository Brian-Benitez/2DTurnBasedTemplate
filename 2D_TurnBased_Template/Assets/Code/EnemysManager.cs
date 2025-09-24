using System.Collections.Generic;
using UnityEngine;

public class EnemysManager : MonoBehaviour
{
    public static EnemysManager Instance { get; private set; }

    public GameObject SwordsmanPrefab;
    public GameObject ArcherPrefab;
    public List<GameObject> SpawnList;

    public int AmountOfEnemies;
    public int AmountOfEnemiesToSpawn;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
            SpawnEnemies();
            
    }
    void SpawnEnemies()
    {
        
        if (AmountOfEnemies == 0)
        {
            //Vector2 spawnPosition = transform.position;//change this to a place they can spawn in
            for (int i = 0; i < AmountOfEnemiesToSpawn; i++)
            {
                Instantiate(SwordsmanPrefab, SpawnList[RandomSpawnPoint()].transform.position, Quaternion.identity);
                AmountOfEnemies++;
                Debug.Log("instantiated " + SwordsmanPrefab.name);
            }
        }
        else
            Debug.Log("list is null:( or list is full still");
    }

    int RandomSpawnPoint() => Random.Range(0, SpawnList.Count);
}
