using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diceManager : MonoBehaviour
{
    public dice[] dices;
    public int sum = 0;
    public Text sumText;
    public Text hpText;
    public Slider hpSlider;
    public float maxHP;
    public float currentHP;
    private void OnEnable()
    {
        dices = this.GetComponentsInChildren<dice>();
        sumText.text = "Sum = " + sum;
        hpText.text = "hp = " + currentHP;
        hpSlider.value = currentHP / maxHP;
    }

    public void Reroll()
    {
        sum = 0;
        foreach(dice dice in dices)
        {
            if(dice.isKept)
            {
                dice.ChangeN();
            }
            sum += dice.power;
        }
        sumText.text = "Sum = " + sum;
    }

    public void Attack()
    {
        currentHP = currentHP - sum;
        hpSlider.value = currentHP / maxHP;
        hpText.text = "hp = " + currentHP;
    }

    
}
