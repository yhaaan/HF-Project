using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Desc :: ��Ʋ�� ���õ� �⹫ ����
 */
public class BattleManager : MonoBehaviour
{
    [Header("# Player")]
    public Player player;
    public Text playerHpText;
    public Slider playerHpSlider;
    public float playerMaxHP;
    public float playerCurHP;

    [Header("# Enemy")]
    public Enemy enemy;
    public Text enemyHpText;
    public Slider enemyHpSlider;
    public float enemyMaxHP;
    public float enemyCurHP;

    [Header("# Skill Button")]
    public GameObject skillButtons;
    public Button[] skills;

    [Header("# DiceManager")]
    public DiceManager diceManager;

    private void Awake()
    {
        playerMaxHP = player.maxHP;
        playerCurHP = player.curruntHP;
        playerHpSlider.value = playerCurHP/ playerMaxHP;
        playerHpText.text = playerCurHP.ToString();

        enemyMaxHP = enemy.maxHP;
        enemyCurHP = enemy.curruntHP;
        enemyHpSlider.value = enemyCurHP / enemyMaxHP;
        enemyHpText.text = enemyCurHP.ToString();

        skills = skillButtons.GetComponentsInChildren<Button>();
    }

    private void Start()
    {
        StartPlayerTurn();
    }


    public void Reroll()
    {
        diceManager.ChangeAllDice();
        SetText();
    }

    public void Attack(int damage)
    {
        enemyCurHP -= damage;
        if (enemyCurHP < 0) enemyCurHP = 0;
        if (enemyCurHP > enemyMaxHP) enemyCurHP = enemyMaxHP;
        enemyHpSlider.value = enemyCurHP/enemyMaxHP;
        enemyHpText.text = enemyCurHP.ToString();

    }


    public void SetText()
    {
       // skills[2].GetComponentInChildren<Text>().text = " 123";
        
        for (int i = 0; i < skills.Length;i++)
        {
            if(skills[i].interactable)
            {
                skills[i].GetComponentInChildren<Text>().text = diceManager.GetDamege(i).ToString();
                skills[i].GetComponent<TESTSKILL>().AD = diceManager.GetDamege(i);
            }
        }
        
    }
    public void StartPlayerTurn()
    {
        Reroll();
    }
    public void EndPlayerTurn()
    {

    }
    public void StartEnemyTurn()
    {

    }
}
