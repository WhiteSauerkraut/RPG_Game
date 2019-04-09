using UnityEngine;
using System.Collections;

public class NormalAtk : MonoBehaviour,Skill
{
    public string skillName;
    public string description;
    public string iconUrl;

    public int goalNum;
    public GameObject[] goals;

    private void Awake()
    {
        goals = new GameObject[goalNum];
    }

    public string GetSKillName()
    {
        return skillName;
    }

    public string GetDescription()
    {
        return description;
    }

    public string GetIconPath()
    {
        return iconUrl;
    }

    public void ChooseGoal()
    {

    }

    public void BeforeUseSkill()
    {

    }
    public void UseSkill()
    {

    }

    public void AfterUseSkill()
    {

    }
}
