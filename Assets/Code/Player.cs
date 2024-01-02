using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Desc :: Player Á¤º¸
 */
public class Player : MonoBehaviour
{

    public float maxHP = 100;
    public float curruntHP;


    void OnEnable()
    {
        curruntHP = maxHP;
    }

    

}
