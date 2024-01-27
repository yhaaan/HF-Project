using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    private int power;
    public int skillCode;
    public int useLimit = 1;
    public BattleManager battleManager;
    public Button button;
    public Text powerText;
    
    public void Awake()
    {
        button = GetComponent<Button>();
        powerText = GetComponentInChildren<Text>();
        button.onClick.AddListener(UseSkill);
    }

    public void SetText()
    {
        powerText.text = BattleManager.instance.playerDices.GetDamage(skillCode).ToString();
    }
    public void UseSkill()
    {
        power = BattleManager.instance.playerDices.GetDamage(skillCode);
        battleManager.AttackEnemy(power);
        useLimit--;
        battleManager.EndPlayerTurn();
        if (useLimit == 0)
        {
            button.interactable = false;
        }
    }
}
