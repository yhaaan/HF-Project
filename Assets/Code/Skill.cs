using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public int power;
    public int useLimit = 1;
    
    public BattleManager battleManager;
    public Button button;
    
    public void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(UseSkill);
    }

    public void UseSkill()
    {
        battleManager.AttackEnemy(power);
        useLimit--;
        battleManager.EndPlayerTurn();
        if (useLimit == 0)
        {
            button.interactable = false;
        }
    }

    public void Heal()
    {
        battleManager.AttackEnemy(power*-1);
    }
}
