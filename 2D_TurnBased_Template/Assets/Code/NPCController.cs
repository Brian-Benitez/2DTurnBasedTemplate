using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public static NPCController Instance { get; private set; }

    public List<GameObject> GoodGuysList;
    public int CurrentGoodGuyIndex = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public int PickGoodGuyAtRandom()
    {
        int index = 0;
        CurrentGoodGuyIndex = 0;
        index = Random.Range(0, GoodGuysList.Count);
        CurrentGoodGuyIndex = index;
        return index;
    }
    
}
