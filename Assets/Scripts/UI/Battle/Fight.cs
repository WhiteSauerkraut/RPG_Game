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
        Debug.Log("done" + skill.GetSKillName());
        canvas.transform.Find("OperationWindow").gameObject.SetActive(true);
    }
}
