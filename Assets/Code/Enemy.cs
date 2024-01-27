using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Desc :: Enemy 정보
 */
public class Enemy : MonoBehaviour
{
    
    public float maxHP;
    public float currentHP;
    //public int remainingRolls;
    //public SortedSet<int> reamainingSkillNum;
    void Awake()
    {
        currentHP = maxHP;
    }
    public void attacked(int power)
    {
        currentHP -= power;
        if (currentHP < 0) currentHP = 0;
        if (currentHP > maxHP) currentHP = maxHP;
    }

    public void Heal(int power)
    {
        currentHP += power;
        if (currentHP > maxHP) currentHP = maxHP;
    }
}
