using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Desc :: Player ����
 */
public class Player : MonoBehaviour
{

    public float maxHP;
    public float curruntHP;
    public int remainingRolls;
    public SortedSet<int> reamainingSkillNum = new SortedSet<int>();

    void Awake()
    {
        curruntHP = maxHP;

        remainingRolls = 2;

        for (int i = 0; i < 12; i++)
        {
            //Todo 0~11가 아닌 플레이어가 가진 스킬 목록으로 바꿀 것
            reamainingSkillNum.Add(i);
        }
    }

    public void RemoveSkillNum(int skillNum)
    {
        reamainingSkillNum.Remove(skillNum);
    }
    public void ReduceSkillNum()
    {
        if(remainingRolls > 0)
        {
            remainingRolls -= 1;
        }
    }

}
