using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    [Header("# Battle Info")]
    public bool isPlayerTurn;
    
    [Header("# Player Info")]
    public Player player;
    public HUD playerHUD;
    [Header("# Enemy Info")]
    public Enemy enemy;
    public HUD enemyHUD;


    [Header("# Skill Button")]
    public GameObject skillButtons;
    public Button[] skills;

    [Header("# DiceController")]
    public DiceManager playerDices;
    public DiceManager enemyDices;


    
    private void Awake()
    {
        instance = this;
        isPlayerTurn = true;
        skills = skillButtons.GetComponentsInChildren<Button>();
    }
    
    private void Start()
    {
        if(isPlayerTurn)
            StartPlayerTurn();
        else
            StartEnemyTurn();
        playerHUD.UpdateHpHUD();
        enemyHUD.UpdateHpHUD();
    }
    public void StartPlayerTurn()
    {
        //1.스킬버튼 활성화
        for (int i = 0; i < skills.Length; i++)
        {
            if (skills[i].GetComponent<Skill>().useLimit > 0)
            {
                skills[i].interactable = true;
            }
        }
        //2.리롤
        Reroll();
    }
    public void EndPlayerTurn()
    {
        //1.스킬버튼 비활성화
        for (int i = 0; i < skills.Length; i++)
        {
            skills[i].interactable = false;
        }
        //2.다이스 모두 언킵
        playerDices.UnKeepAllDice();
        //3.상대 턴 시작
        StartEnemyTurn();
    }
    public void StartEnemyTurn()
    {
        StartCoroutine(TestEnemy());
    }

    public void EndEnemyTurn()
    {
        StopCoroutine(TestEnemy());
        //1.플레이어 턴 시작
        StartPlayerTurn();
    }
    private IEnumerator TestEnemy()
    {
        Debug.Log("Enemy turn...");
        yield return new WaitForSeconds(1f);
        //1.리롤
        enemyDices.RollAllDice();
        yield return new WaitForSeconds(1f);
        //2.공격
        AttackPlayer(enemyDices.GetDamage(7));
        yield return new WaitForSeconds(1f);
        //3.턴 종료
        EndEnemyTurn();
        
    }
    public void Reroll()
    {
        playerDices.RollAllDice();
        foreach (Button skill in skills)
        {
            if(skill.interactable) 
                skill.GetComponent<Skill>().SetText();
        }
    }

    public void AttackEnemy(int power)
    {
        enemy.attacked(power);
        enemyHUD.UpdateHpHUD();
    }
    
    public void AttackPlayer(int power)
    {
       player.attacked(power);
       playerHUD.UpdateHpHUD();

    }
}
