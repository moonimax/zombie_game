using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DrawStatus : MonoBehaviour
{
    private PlayerStats playerStats;

    public Image hpBar;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;

    private void Start()
    {
        playerStats = PlayerStats.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.isDeath)
            return;

        hpBar.fillAmount = playerStats.health / playerStats.maxHealth;
        attackText.text = playerStats.attack.GetValue().ToString();
        defenseText.text = playerStats.defense.GetValue().ToString();
    }
}
