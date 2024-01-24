using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/*
 * Desc :: 주사위와 관련된 모든 기능 수행
 */

public class DiceManager : MonoBehaviour
{
    public Dice[] dices;

    private void Awake()
    {
        dices = this.GetComponentsInChildren<Dice>();
    }

    public void UnKeepAllDice()
    {
        foreach(Dice dice in dices)
        {
            if(dice.isKept)
            {
                dice.ToggleKeptStatus();
            }
        }
    }
    public void RollAllDice()
    {
        foreach(Dice dice in dices)
        {
            if(!dice.isKept)
            {
                dice.Roll();
            }
        }

    }
    
    /// <summary>
    /// 스킬번호를 입력받아 1~6번 스킬의 데미지를 반환
    /// </summary>
    /// <param name="dices"></param>
    /// <param name="diceNum"></param>
    /// <returns></returns>
    
   
    public int GetDamage(int skillNum)
    {
        if (skillNum < 6)
        {
            return GetUpperDamage(skillNum+1);
        }
        else if (skillNum == 6)
        {
          return GetChoiceDamage();
        }
        else if (skillNum == 7)
        {
            return GetFourKindDamage();
        }
        else if (skillNum == 8)
        {
            return GetFullHouseDamage();
        }
        else if (skillNum == 9)
        {
            return GetStraightDamage(4);
        }
        else if (skillNum == 10)
        {
            return GetStraightDamage(5);
        }
        else if (skillNum == 11)
        {
            return GetYachtDamage();
        }
        else
        {
            return 1000;
        }
    }
   

    private int GetUpperDamage(int diceNum)
    {
        int damage = 0;

        foreach (Dice dice in dices)
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
    private int GetChoiceDamage()
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
    private int GetFourKindDamage()
    {
        int damage = 0;
        var sortDict = new Dictionary<int, int>();  //<주사위눈, 주사위 갯수>
        foreach (Dice dice in dices)
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
        if(sortDict.ContainsValue(4) | sortDict.ContainsValue(5))
        {
            return damage;
        } else
        {
            return 0;
        }
    }
    /// <summary>
    /// FullHouse의 스킬 데미지를 반환
    /// </summary>
    /// <returns></returns>
    private int GetFullHouseDamage()
    {
        int damage = 0;
        var sortDict = new Dictionary<int, int>();  //<주사위눈, 주사위 갯수>
        foreach (Dice dice in dices)
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
    /// <summary>
    /// SmallStraight는 매개변수에 4입력, LargeStraight는 매개변수에 5입력
    /// </summary>
    /// <param name="straightNum"></param>
    /// <returns></returns>
    private int GetStraightDamage(int straightNum)
    {
        List<int> diceNums = new List<int>();
        foreach (Dice dice in dices)
        {
            
            diceNums.Add(dice.num);
        }
        diceNums.Sort();
        diceNums = diceNums.Distinct().ToList();
        int preNum = 0;
        int count = 1;
        foreach(int diceNum in diceNums)
        {
            if(preNum == 0)
            {
                preNum = diceNum;
                continue;
            }
            if(preNum + 1 == diceNum)
            {
                count += 1;
            } else
            {
                count = 0;
            }
            preNum = diceNum;
        }
        if(count >= straightNum)
        {
            return 15 * (straightNum - 3);
        } else
        {
            return 0;
        }
    }
    /// <summary>
    /// FullHouse의 스킬 데미지를 반환
    /// </summary>
    /// <returns></returns>
    private int GetYachtDamage()
    {
        var sortDict = new Dictionary<int, int>();  //<주사위눈, 주사위 갯수>
        foreach (Dice dice in dices)
        {
            
            if(sortDict.ContainsKey(dice.num))
            {
                sortDict[dice.num] += 1;
            } else
            {
                sortDict.Add(dice.num, 1);
            }
            //Debug.Log(dice.num.ToString() + sortDict[dice.num]);
        }
        if(sortDict.ContainsValue(5))
        {
            return 50;
        } else
        {
            return 0;
        }
    }
}
