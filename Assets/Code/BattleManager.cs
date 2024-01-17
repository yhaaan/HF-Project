using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
        //set player info 
        playerMaxHP = player.maxHP;
        playerCurHP = player.curruntHP;
        playerHpSlider.value = playerCurHP/ playerMaxHP;
        playerHpText.text = playerCurHP.ToString();
        //set enemy info
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
        diceManager.RollTheDice();
        SetText();
    }

    public void AttackEnemy(int damage)
    {
        enemyCurHP -= damage;
        if (enemyCurHP < 0) enemyCurHP = 0;
        if (enemyCurHP > enemyMaxHP) enemyCurHP = enemyMaxHP;
        enemyHpSlider.value = enemyCurHP/enemyMaxHP;
        enemyHpText.text = enemyCurHP.ToString();

    }
    
    public void AttackPlayer(int damage)
    {
        playerCurHP -= damage;
        if (playerCurHP < 0) playerCurHP = 0;
        if (playerCurHP > playerMaxHP) playerCurHP = playerMaxHP;
        playerHpSlider.value = playerCurHP/playerMaxHP;
        playerHpText.text = playerCurHP.ToString();

    }


    public void SetText()
    {
       // skills[2].GetComponentInChildren<Text>().text = " 123";
        
        for (int i = 0; i < skills.Length;i++)
        {
            if(skills[i].interactable)
            {
                int damage = diceManager.GetDamage(i);
                skills[i].GetComponentInChildren<Text>().text = damage.ToString();
                skills[i].GetComponent<Skill>().power = damage;
            }
        }
        
    }
    public void StartPlayerTurn()
    {
        
        for (int i = 0; i < skills.Length; i++)
        {
            if (skills[i].GetComponent<Skill>().useLimit > 0)
            {
                skills[i].interactable = true;
            }
        }

    }
    public void EndPlayerTurn()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            skills[i].interactable = false;
        }
        diceManager.ClearAllKeep();
        StartEnemyTurn();
    }
    public void StartEnemyTurn()
    {
        StartCoroutine(TestEnemy());
        
    }

    private IEnumerator TestEnemy()
    {
        Debug.Log("Enemy turn...");
        yield return new WaitForSeconds(1f);
        diceManager.RollTheDice();
        yield return new WaitForSeconds(1f);
        AttackPlayer(diceManager.GetDamage(6));
        yield return new WaitForSeconds(1f);
        StartPlayerTurn();
        
    }
}
