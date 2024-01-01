using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DiceManager : MonoBehaviour
{
    public List<Dice> dices = new List<Dice>();

    private void OnEnable()
    {
    }

    public void Reroll()
    {
        foreach(Dice dice in dices)
        {
            if(dice.isKept)
            {
                dice.ChangeN();
            }
        }
        int damage = GetUpperDamage(3);
        Debug.Log("damage : " + damage);
    }
    /// <summary>
    /// 스킬번호를 입력받아 1~6번 스킬의 데미지를 반환
    /// </summary>
    /// <param name="dices"></param>
    /// <param name="diceNum"></param>
    /// <returns></returns>
    public int GetUpperDamage(int diceNum)
    {
        int damage = 0;
        foreach(Dice dice in dices)
        {
            if(dice.num == diceNum)
            {
                damage += dice.num;
            }
        }
        return damage;
    }
    /// <summary>
    /// Choice의 스킬 데미지를 반환
    /// </summary>
    /// <param name="dices">스킬에 사용할 다섯개 주사위</param>
    /// <returns></returns>
    public int GetChoiceDamage()
    {
        int damage = 0;
        foreach (Dice dice in dices)
        {
            damage += dice.num;
        }
        return damage;
    }
    /// <summary>
    /// FourKind의 스킬 데미지를 반환
    /// </summary>
    /// <returns></returns>
    public int GetFourKindDamage()
    {
        int damage = 0;
        var sortDict = new Dictionary<int, int>();  //<주사위눈, 주사위 갯수>
        foreach(Dice dice in dices)
        {
            if(sortDict.ContainsKey(dice.num))
            {
                sortDict[dice.num] += 1;
            } else
            {
                sortDict.Add(dice.num, 1);
            }
            damage += dice.num;
        }
        if(sortDict.Values.Any(value => value > 4))
        {
            return damage;
        } else
        {
            return 0;
        }
    }
    public int GetFullHouseDamage()
    {
        int damage = 0;
        var sortDict = new Dictionary<int, int>();  //<주사위눈, 주사위 갯수>
        foreach(Dice dice in dices)
        {
            if(sortDict.ContainsKey(dice.num))
            {
                sortDict[dice.num] += 1;
            } else
            {
                sortDict.Add(dice.num, 1);
            }
            damage += dice.num;
        }
        if((sortDict.ContainsValue(3) & sortDict.ContainsValue(2)) | sortDict.ContainsValue(5))
        {
            return damage;
        } else
        {
            return 0;
        }
    }
    public int GetSmallSTDamage()
    {
        return 30;
    }
}
