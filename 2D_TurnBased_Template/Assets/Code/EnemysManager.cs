using System.Collections.Generic;
using UnityEngine;

public class EnemysManager : MonoBehaviour
{
    public GameObject SwordsmanPrefab;
    public GameObject ArcherPrefab;
    public List<GameObject> EnemiesList;

    public int AmountOfEnemies;
    public float spacing = 1.0f;
    private void Start()
    {
        EnemiesList = new List<GameObject>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
            SpawnEnemies();
            
    }
    void SpawnEnemies()
    {
        if (EnemiesList != null && EnemiesList.Count == 0)
        {
            Vector2 spawnPosition = transform.position;//change this to a place they can spawn in
            for (int i = 0; i < AmountOfEnemies; i++)
            {
                Instantiate(SwordsmanPrefab, spawnPosition, Quaternion.identity);
                EnemiesList.Add(SwordsmanPrefab);
                spawnPosition.x += spacing;
                Debug.Log("instantiated " + SwordsmanPrefab.name);
            }
        }
        else
            Debug.Log("list is null:( or list is full still");
    }
}
