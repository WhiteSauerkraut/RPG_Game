using UnityEngine;
using System.Collections;

public class NormalAtk : MonoBehaviour,Skill
{
    public string skillName = "普通攻击";
    public string description;
    public string iconUrl;
    public bool flag;

    public int goalNum = 1;
    public GameObject[] goals;

    BattleManager bm;
    private void Awake()
    {
        goals = new GameObject[goalNum];
        bm = GameObject.Find("GM").GetComponent<BattleManager>();
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
        StartCoroutine(bm.ChooseGoal(goalNum, goals,this));
    }

    public void BeforeUseSkill()
    {
        Debug.Log(goals[0]);
        Transform goal = goals[0].transform.parent.Find("atkPosition");
        StartCoroutine(bm.MoveTo(gameObject, goal, this));
    }
    public void UseSkill()
    {
        StartCoroutine(bm.PhysicalAttack(gameObject,this));
        StartCoroutine(WaitTime(0.5f));

    }

    public void AfterUseSkill()
    {
        Transform goal = transform.parent;
        StartCoroutine(bm.TrunBack(gameObject, goal, this));
    }

    public void SetFlag(bool flag)
    {
        this.flag = flag;
    }

    public bool GetFlag()
    {
        return flag;
    }

    IEnumerator WaitTime(float f)
    {
        yield return new WaitForSeconds(f);
        StartCoroutine(bm.Defend(goals[0], this));
        foreach (GameObject player in goals)
        {
            Debug.Log("hello!");
            player.GetComponent<PlayerComponent>().beDamaged(this.gameObject.GetComponent<PlayerComponent>().M_BattleProperty.M_Atk);
        }
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
