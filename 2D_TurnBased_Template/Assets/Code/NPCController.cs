using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public static NPCController Instance { get; private set; }

    public GameObject Player;
    public int CurrentGoodGuyIndex = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

}
