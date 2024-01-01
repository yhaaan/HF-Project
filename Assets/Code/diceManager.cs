using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceManager : MonoBehaviour
{
    public List<Dice> dices = new List<Dice>();
    public int sum = 0;

    private void OnEnable()
    {
    }

    public void Reroll()
    {
        sum = 0;
        foreach(Dice dice in dices)
        {
            if(dice.isKept)
            {
                dice.ChangeN();
            }
            sum += dice.power;
        }
    }

  

    
}
