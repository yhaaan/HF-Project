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


    void Awake()
    {
        curruntHP = maxHP;
    }

    

}
