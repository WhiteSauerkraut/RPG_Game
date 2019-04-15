using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 创建日期：4/10
 * 创建人：lyj
 * 描述：技能类——增益技能
 * */

public class GainSkill : MonoBehaviour,Skill
{
    public string skillName = "增强攻击";
    public string description;
    public string iconUrl;
    public bool flag;

    public int goalNum = 0;
    public GameObject[] goals;

    BattleManager bm;

    private void Awake()
    {
        goals = new GameObject[goalNum];
        bm = GameObject.Find("GM").GetComponent<BattleManager>();
    }

    public void AfterUseSkill()
    {
        Debug.Log("增强攻击力完成....");
        SetFlag(true);
    }

    public void BeforeUseSkill()
    {
        Debug.Log("准备增强攻击力...");
        SetFlag(true);
    }

    public void ChooseGoal()
    {
        StartCoroutine(bm.ChooseGoal(goalNum, goals, this));
    }

    public string GetDescription()
    {
        return description;
    }

    public bool GetFlag()
    {
        return flag;
    }

    public string GetIconPath()
    {
        return iconUrl;
    }

    public string GetSKillName()
    {
        return skillName;
    }

    public void SetFlag(bool flag)
    {
        this.flag = flag;
    }

    public void UseSkill()
    {
        StartCoroutine(bm.MagicAttack(gameObject, this));
    }

    IEnumerator WaitTime(float f)
    {
        yield return new WaitForSeconds(f);
        StartCoroutine(bm.Defend(goals[0], this));
    }

    public int GetGoalsNum()
    {
        return goalNum;
    }

    public void SetGoals(GameObject[] goals)
    {
        this.goals = goals;
    }
}
