using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BaseStatsDisplay : MonoBehaviour
{
    [Header("Base Stats Objects")]
    public BaseStats PlayersBaseStats;

    [Header("Players UI")]
    public TextMeshProUGUI PlayersNameText;
    public TextMeshProUGUI PlayersHealthText;
    public TextMeshProUGUI PlayersMaxHealthText;
    public TextMeshProUGUI PlayersSanityText;
    public TextMeshProUGUI PlayersLevelText;

    private void Start()
    {
        PlayersNameText.text = PlayersBaseStats.Name;
        PlayersHealthText.text = PlayersBaseStats.Health.ToString();
        PlayersMaxHealthText.text = PlayersBaseStats.MaxHealth.ToString();
        PlayersSanityText.text = PlayersBaseStats.Sanity.ToString();
        PlayersLevelText.text = PlayersBaseStats.Level.ToString();  
    }
}
