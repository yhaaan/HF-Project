using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Desc :: 스킬 사용
 * SkillButton의 컴포넌트
 * battlemanager를 유니티에서 할당해줘야하는 문제가 있음
 */

public class TESTSKILL : MonoBehaviour
{
    public int AD = 5;
    
    public BattleManager battlemanager;
    
    public void Attack()
    {
        battlemanager.Attack(AD);
    }
    public void Heal()
    {
        battlemanager.Attack(AD*-1);
    }
}
