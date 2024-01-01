using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }

    public void Attact(int damage)
    {
        enemyCurHP -= damage;
        if (enemyCurHP < 0) enemyCurHP = 0;
        if (enemyCurHP > enemyMaxHP) enemyCurHP = enemyMaxHP;
        enemyHpSlider.value = enemyCurHP/enemyMaxHP;
        enemyHpText.text = enemyCurHP.ToString();

    }
}
