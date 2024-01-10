using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 * Desc :: ��ų ���
 * SkillButton�� ������Ʈ
 * battlemanager�� ����Ƽ���� �Ҵ�������ϴ� ������ ����
 */

public class TESTSKILL : MonoBehaviour
{
    public int AD = 5;
    
    public BattleManager battlemanager;
    public Button button;
    
    public void Awake()
    {
        button = this.GetComponent<Button>();
    }
    public void Attack()
    {
        battlemanager.Attack(AD);
        battlemanager.EndPlayerTurn();
        button.interactable = false;
    }
    public void Heal()
    {
        battlemanager.Attack(AD*-1);
    }
}
