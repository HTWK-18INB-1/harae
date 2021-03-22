using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthScript : MonoBehaviour
{
    private Slider healthBar;
    private playerCombat player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerCombat>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = player.getMaxHealth();
    }

    void Update(){
        healthBar.value = player.getCurrentHealth();
    }
    
}
