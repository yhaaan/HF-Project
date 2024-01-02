using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;



public class DiceManager : MonoBehaviour
{
    public int testSkillNum = 1;
    public List<Dice> dices = new List<Dice>();

    private void OnEnable()
    {
        
    }

    public void Reroll()
    {
        foreach(Dice dice in dices)
        {
            if(!dice.isKept)
            {
                dice.ChangeN();
            }
        }
        //아래는 테스트 코드입니다.
        if(testSkillNum <= 6)
        {
            Debug.Log("상단스킬 damage : " + GetUpperDamage(testSkillNum));
        } else if (testSkillNum == 7)
        {
            Debug.Log("초이스 damage : " + GetChoiceDamage());
        } else if (testSkillNum == 8)
        {
            Debug.Log("포카인드 damage : " + GetFourKindDamage());
        } else if (testSkillNum == 9)
        {
            Debug.Log("풀하우스 damage : " + GetFullHouseDamage());
        } else if (testSkillNum == 10)
        {
            Debug.Log("스몰스트 damage : " + GetStraightDamage(4));
        } else if (testSkillNum == 11)
        {
            Debug.Log("라지스트 damage : " + GetStraightDamage(5));
        } else if (testSkillNum == 12)
        {
            Debug.Log("야추 damage : " + GetYachtDamage());
        }else
        {
            Debug.Log("testSkillNum 초과");
        }
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
        for (int i = 1; i <= 5; i++)
        {
            Dice dice = dices[i] ;
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
        for (int i = 1; i <= 5; i++)
        {
            Dice dice = dices[i] ;
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
        for (int i = 1; i <= 5; i++)
        {
            Dice dice = dices[i] ;
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
    public int GetFullHouseDamage()
    {
        int damage = 0;
        var sortDict = new Dictionary<int, int>();  //<주사위눈, 주사위 갯수>
        for (int i = 1; i <= 5; i++)
        {
            Dice dice = dices[i] ;
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
    public int GetStraightDamage(int straightNum)
    {
        List<int> diceNums = new List<int>();
        for (int i = 1; i <= 5; i++)
        {
            Dice dice = dices[i] ;
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
    public int GetYachtDamage()
    {
        var sortDict = new Dictionary<int, int>();  //<주사위눈, 주사위 갯수>
        for (int i = 1; i <= 5; i++)
        {
            Dice dice = dices[i] ;
            if(sortDict.ContainsKey(dice.num))
            {
                sortDict[dice.num] += 1;
            } else
            {
                sortDict.Add(dice.num, 1);
            }
            Debug.Log(dice.num.ToString() + sortDict[dice.num]);
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
