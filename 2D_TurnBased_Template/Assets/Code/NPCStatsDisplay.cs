using UnityEngine;

public class NPCStatsDisplay : MonoBehaviour//maybe call this NPCStatsController.....,,.....,.,.,.,,,.,,,
{
    public BaseNPCStats NPCsStats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            NPCsStats.PrintInfo();
    }
}
