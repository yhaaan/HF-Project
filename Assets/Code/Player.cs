using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHP;
    public float curruntHP;
    void OnEnable()
    {
        maxHP = 100;
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
}
