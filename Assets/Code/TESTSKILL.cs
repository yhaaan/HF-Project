using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Desc :: ��ų ���
 * SkillButton�� ������Ʈ
 * battlemanager�� ����Ƽ���� �Ҵ�������ϴ� ������ ����
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
