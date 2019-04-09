using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWindows : MonoBehaviour
{
    public void ShowSkillWindow()
    {
        BattleManager bm = GameObject.Find("GM").GetComponent<BattleManager>();
        GameObject skillWindow = transform.parent.Find("SkillWindow").gameObject;
        GameObject player = bm.GetPlayerTurn();

        Skill[] skills = player.GetComponents<Skill>();
        for (int i=0; i < skills.Length; i++)
        {
            skillWindow.transform.GetChild(i).gameObject.GetComponentInChildren<Text>().text = skills[i].GetSKillName();
            Debug.Log(skills[i]);
        }

        skillWindow.SetActive(true);
    }
}
