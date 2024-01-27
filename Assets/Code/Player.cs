using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Desc :: Player ����
 */
public class Player : MonoBehaviour
{

    public float maxHP;
    public float currentHP;
    //public SortedSet<int> reamainingSkillNum = new SortedSet<int>();

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
    public void RemoveSkillNum(int skillNum)
    {
       
    }
    public void ReduceSkillNum()
    {
        
    }

}
