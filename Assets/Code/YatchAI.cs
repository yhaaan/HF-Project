using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YatchAI : MonoBehaviour
{
    public List<bool> usableSkills = new List<bool> {true, true, true, true, true, true, true, true, true, true, true, true};
    public List<int> diceNums = new List<int> {1,1,1,1,1};
    public List<bool> rerollDices = new List<bool> {true, true, true, true, true};
    public int rerollChance = 2;
    void Awake()
    {

    }
    // Start is called before the first frame update
    void OnMouseDown()
    {
        Debug.Log(GetRerollEV(usableSkills, diceNums, rerollDices,rerollChance));
    }
/// <summary>
/// 리롤에 대한 점수 기대값을 반환하는 함수
/// </summary>
/// <param name="usableSkills">사용가능한 스킬 목록</param>
/// <param name="diceNums">현재 주사위 숫자</param>
/// <param name="rerollDices">리롤할 주사위</param>
/// <param name="rerollChance">남은 리롤 횟수</param>
/// <returns></returns>
    private float GetRerollEV(List<bool> usableSkills, List<int> diceNums, List<bool> rerollDices, int rerollChance)
    {
        float EVSum = 0;
        for(int skillNum = 0; skillNum < usableSkills.Count; skillNum++)
        {
            if(usableSkills[skillNum] == false)
            {
                continue;
            }
            EVSum += GetSkillEV(skillNum, usableSkills, diceNums, rerollDices, rerollChance);
        }
        return EVSum;
    }

    private float GetSkillEV(int skillNum, List<bool> usableSkills, List<int> diceNums, List<bool> rerollDices, int rerollChance)
    {
        if(skillNum == 0)
        {
            
        } else if (skillNum == 1)
        {
            
        } else if (skillNum == 2)
        {
            
        } else if (skillNum == 3)
        {
            
        } else if (skillNum == 4)
        {
            
        } else if (skillNum == 5)
        {
            
        } else if (skillNum == 6)
        {
            
        } else if (skillNum == 7)
        {
            
        } else if (skillNum == 8)
        {
            
        } else if (skillNum == 9)
        {
            
        } else if (skillNum == 10)
        {
            
        } else if (skillNum == 11)
        {
            
        }
        return 1;
    }
}
