using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTSKILL : MonoBehaviour
{
    public int AD = 5;
    public int AP = -7;
    public BattleManager battlemanager;
    
    public void Attack()
    {
        battlemanager.Attact(AD);
    }

    public void Heal()
    {
        battlemanager.Attact(AP);
    }
}
