using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Desc :: Enemy 정보
 */
public class Enemy : MonoBehaviour
{
    public float maxHP;
    public float curruntHP;
    public int remainingRolls;
    public SortedSet<int> reamainingSkillNum;
    void OnEnable()
    {
        curruntHP = maxHP;
    }
    public void ReduceHP(int damage)
    {
        if(damage <= curruntHP)
        {
            curruntHP -= damage;
        } else if (damage > curruntHP)
        {
            curruntHP = 0;
        }
    }
    public void RemoveSkillNum(int skillNum)
    {
        reamainingSkillNum.Remove(skillNum);
    }
}
