using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHP;
    public float curruntHP;
    void OnEnable()
    {
        maxHP = 100;
        curruntHP = maxHP;
    }

    /// <summary>
    /// 스킬사용시 첫번째 원소에 스킬 번호 반환 /
    /// 리롤시 첫번째 원소에 0반환, 뒤 다섯개 원소에 리롤하는 주사위idx에서 1반환 /
    /// 주사위정보, 남은 리롤횟수, 남은 스킬정보를 바탕으로 액션을 리턴함
    /// </summary>
    /// <param name=""></param>
    /// <param name="leftReroll"></param>
    /// <param name="leftSkill"></param>
    public int[] GetNextAction(Dice[] dices, int leftReroll, int[] leftSkill)
    {
        //우선 첫번째 원소가 주사위가 1일 때 까지 리롤하게 작성
        //리롤 종료시 초이스 반환
        if(leftReroll < 1)
        {
            return new int[] {7,0,0,0,0,0};
        }
        if(dices[0].num == 1)
        {
            return new int[] {7,0,0,0,0,0};
        } else
        {       
            return new int[] {0,1,0,0,0,0};
        }

        
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
}
