using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    GameObject canvas;
    BattleManager bm;
    private void Awake()
    {
        bm = GameObject.Find("GM").GetComponent<BattleManager>();
        canvas = GameObject.Find("Canvas");
    }
    public void UseSkill(int i)
    {
        GameObject player = bm.GetPlayerTurn();
        Skill skill = player.GetComponents<Skill>()[i];
        StartCoroutine(UseSkill(skill));

    }
    IEnumerator UseSkill(Skill skill)
    {
        skill.SetFlag(false);
        skill.ChooseGoal();
        yield return new WaitUntil(skill.GetFlag);

        skill.SetFlag(false);
        skill.BeforeUseSkill();
        yield return new WaitUntil(skill.GetFlag);

        skill.SetFlag(false);
        skill.UseSkill();
        yield return new WaitUntil(skill.GetFlag);
        skill.SetFlag(false);
        skill.AfterUseSkill();
        yield return new WaitUntil(skill.GetFlag);

        bm.NextTurn();
    }
    public void AutoUseSkill()
    {
        GameObject player = bm.GetPlayerTurn();
        int i = Random.Range(0, 4);
        Skill skill = player.GetComponents<Skill>()[i];
        StartCoroutine(AutoUseSkill(skill, player));
    }

    IEnumerator AutoUseSkill(Skill skill, GameObject player)
    {
        GameObject[] goals;
        Transform sets;

        if (player.GetComponent<PlayerComponent>().camp == Camp.enemy)
        {
            sets = GameObject.Find("Sets/Teammates").transform;
        }
        else
        {
            sets = GameObject.Find("sets/Enemys").transform;
        }

        int num = skill.GetGoalsNum();
        goals = new GameObject[num];
        bool[] flags = new bool[num];
        for (int i = 0; i < num; i++)
        {
            flags[i] = false;
        }

        for (int i = 0; i < num; i++)
        {
            int n = Random.Range(0, num);
            while (flags[n])
            {
                n = (n + 1) % num;
            }
            goals[i] = sets.gameObject.GetComponentsInChildren<PlayerComponent>()[n].gameObject;

        }

        skill.SetGoals(goals);

        skill.SetFlag(false);
        skill.BeforeUseSkill();
        yield return new WaitUntil(skill.GetFlag);

        skill.SetFlag(false);
        skill.UseSkill();
        yield return new WaitUntil(skill.GetFlag);

        skill.SetFlag(false);
        skill.AfterUseSkill();
        yield return new WaitUntil(skill.GetFlag);

        if (bm.GetNextPlayer().GetComponent<PlayerComponent>().camp == Camp.teammate)
            canvas.transform.Find("OperationWindow").gameObject.SetActive(true);
        bm.NextTurn();
    }
}
