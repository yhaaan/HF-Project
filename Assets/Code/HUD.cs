using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUD : MonoBehaviour
{
    public enum InfoType {PlayerHealth, EnemyHealth, Skill}
    public InfoType type;

    public Text myText;
    public Slider mySlider;
    private void Awake()
    {
        myText = GetComponentInChildren<Text>();
        mySlider = GetComponentInChildren<Slider>();
        switch (type)
        {
            case InfoType.Skill:
                Button[] skillButtons;
                skillButtons = GetComponentsInChildren<Button>();
                break;
        }
        
    }

    
   
    public void UpdateHpHUD()
    {
        switch (type)
        {
            case InfoType.PlayerHealth:
                float playerCurHP = BattleManager.instance.player.currentHP;
                float playerMaxHP = BattleManager.instance.player.maxHP;
                mySlider.value = playerCurHP / playerMaxHP;
                myText.text = "HP : " +playerCurHP.ToString();
                break;
            case InfoType.EnemyHealth:
                float enemyCurHP = BattleManager.instance.enemy.currentHP;
                float enemyMaxHP = BattleManager.instance.enemy.maxHP;
                mySlider.value = enemyCurHP / enemyMaxHP;
                myText.text = "HP : " +enemyCurHP.ToString();
                break;
            case InfoType.Skill:
                
                
                break;
        }
    }
}
