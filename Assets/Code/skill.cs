using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill : MonoBehaviour
{
    /// <summary>
    /// 테스트(디버그)용 메소드
    /// </summary>
    public void OnClick() {
        Debug.Log("!");
        //int print = yatchCalculator.GetUpperPower(dices, 2);
        //Debug.Log(print);
    }

    /// <summary>
    /// 다섯개의 int값을 입력받아 Aces ~ Sixes의 스킬 데미지를 출력
    /// </summary>
    /// <param name="dices">스킬에 사용할 다섯개 주사위</param>
    /// <param name="diceNum">스킬에 사용할 주사위 눈</param>
    /// <returns></returns>
    public int GetUpperPower(int[] dices, int diceNum)
    {
        int sum = 0;
        foreach(int dice in dices)
        {
            if(dice == diceNum)
            {
                sum += dice;
            }
        }
        return sum;
    }
    /// <summary>
    /// 다섯개의 int값을 입력받아 Choice의 스킬 데미지를 출력
    /// </summary>
    /// <param name="dices">스킬에 사용할 다섯개 주사위</param>
    /// <returns></returns>
    public int GetChoicePower(int[] dices)
    {
        int sum = 0;
        foreach (int dice in dices)
        {
            sum += dice;
        }
        return sum;
    }
    /// <summary>
    /// 다섯개의 int값을 입력받아 FourKind의 스킬 데미지를 출력
    /// </summary>
    /// <param name="dices">스킬에 사용할 다섯개 주사위</param>
    /// <returns></returns>
    public int GetFourKindPower(int[] dices)
    {
        int sum = 0;
        var sortDict = new Dictionary<int, int>();
        foreach(int dice in dices)
        {
            if(sortDict.ContainsKey(dice))
            {
                sortDict[dice] += 1;
            } else
            {
                sortDict.Add(dice, 0);
            }
            //추가작성필요
            sum += dice;
        }
        return sum;
    }
    /// <summary>
    /// 다섯개의 int값을 입력받아 FullHouse의 스킬 데미지를 출력
    /// </summary>
    /// <param name="dices">스킬에 사용할 다섯개 주사위</param>
    /// <returns></returns>
    public int GetFullHousePower(int[] dices)
    {
        int sum = 0;
        foreach (int dice in dices)
        {
            //작성필요
        }
        return sum;
    }
    /// <summary>
    /// 다섯개의 int값을 입력받아 SmallST의 스킬 데미지를 출력
    /// </summary>
    /// <param name="dices">스킬에 사용할 다섯개 주사위</param>
    /// <returns></returns>
    public int GetSmallSTPower(int[] dices)
    {
        int sum = 0;
        foreach (int dice in dices)
        {
            //작성필요
        }
        return sum;
    }
    /// <summary>
    /// 다섯개의 int값을 입력받아 LargeST의 스킬 데미지를 출력
    /// </summary>
    /// <param name="dices">스킬에 사용할 다섯개 주사위</param>
    /// <returns></returns>
    public int GetLargeSTPower(int[] dices)
    {
        int sum = 0;
        foreach (int dice in dices)
        {
            //작성필요
        }
        return sum;
    }
    /// <summary>
    /// 다섯개의 int값을 입력받아 Yacht의 스킬 데미지를 출력
    /// </summary>
    /// <param name="dices">스킬에 사용할 다섯개 주사위</param>
    /// <returns></returns>
    public int GetYachtPower(int[] dices)
    {
        int sum = 0;
        foreach (int dice in dices)
        {
            //작성필요
        }
        return sum;
    }
}
