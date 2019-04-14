using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
/**
 * 创建日期：3/23
 * 创建人：yzy
 * 描述：用于管理战斗系统，战斗方法的集合。
 * 更新日期：3/27
 * 更新人：yzy
 * 描述：绑定在GM，全局。
 **/
public delegate void ATKEvent(GameObject gameObject);

public class BattleManager:MonoBehaviour
{
    public bool isInit = false;

    public GameObject[] enemys;
    public int enemysIndex;
    public Transform enemySets;

    public GameObject[] teammates;
    public int teammatesIndex;
    public Transform teammatesSets;


    public GameObject[] que;
    public int index;
    public int battleCount;

    private GameObject canvas;
    public void Init()
    {
        enemys = new GameObject[4];
        enemysIndex = 0;
        enemySets = GameObject.Find("Sets/Enemys").transform;

        teammates = new GameObject[4];
        teammatesIndex = 0;
        teammatesSets = GameObject.Find("Sets/Teammates").transform;

        que = new GameObject[8];
        index = 0;
        battleCount = 0;
        canvas = GameObject.Find("Canvas");
        canvas.transform.Find("OperationWindow").gameObject.SetActive(true);
        isInit = true;
    }


    public void AddTeammates(string playerName)
    {
        Player player = GetComponent<GlobeManager>().GetPlayer(playerName);
        //实例化
        teammates[teammatesIndex] = (GameObject)Resources.Load(player.M_BasicProperty.M_ModelPath);
        teammates[teammatesIndex] = Instantiate(teammates[teammatesIndex], teammatesSets.GetChild(teammatesIndex));
        teammates[teammatesIndex].name = playerName;
        //添加组件
        PlayerComponent pc = teammates[teammatesIndex].AddComponent<PlayerComponent>();
        pc.Init(player);
        teammates[teammatesIndex].GetComponent<PlayerComponent>().camp = Camp.teammate;

        //添加UI
        GameObject view = (GameObject)Resources.Load("Prefabs/View");
        view = Instantiate(view, canvas.transform.Find("ViewWindow/Teammates"));
        view.GetComponent<ViewScript>().Init(teammates[teammatesIndex]);
        view.transform.localPosition = new Vector2(0, 160 * teammatesIndex);
        //加入战斗队列
        que[battleCount++] = teammates[teammatesIndex];

        teammatesIndex++;

    }

    public void AddEnemys(string playerName)
    {
        Player player = GetComponent<GlobeManager>().GetPlayer(playerName);
        //实例化
        enemys[enemysIndex] = (GameObject)Resources.Load(player.M_BasicProperty.M_ModelPath);
        enemys[enemysIndex].name = playerName;
        enemys[enemysIndex] = Instantiate(enemys[enemysIndex], enemySets.GetChild(enemysIndex));
        //添加组件
        PlayerComponent pc = enemys[enemysIndex].AddComponent<PlayerComponent>();
        pc.Init(player);
        enemys[enemysIndex].GetComponent<PlayerComponent>().camp = Camp.enemy;

        //添加UI
        GameObject view = (GameObject)Resources.Load("Prefabs/View");
        view = Instantiate(view, canvas.transform.Find("ViewWindow/Enemys"));
        view.GetComponent<ViewScript>().Init(enemys[enemysIndex]);
        view.transform.localPosition = new Vector2(0, 160 * enemysIndex);

        //加入战斗队列
        que[battleCount++] = enemys[enemysIndex];

        enemysIndex++;
    }

    public GameObject GetPlayerTurn()
    {
        return que[index];
    }

    public IEnumerator ChooseGoal(int num, GameObject[] goals, Skill skill)
    {
        GameObject explainWindow = canvas.transform.Find("ExplainWindow").gameObject;

        explainWindow.GetComponentInChildren<Text>().text = "请选择" + num.ToString() + "个目标";
        explainWindow.SetActive(true);
        ChoosePlayer cp = GameObject.Find("GlobalManager").GetComponent<ChoosePlayer>();

        int count = 0;
        while (count < num)
        {
            cp.SetFlag(false);

            yield return new WaitUntil(cp.GetFlag);

            goals[count++] = cp.GetChoose();
        }

        int n = canvas.transform.childCount;
        for (int i=0; i<n; i++)
        {
            canvas.transform.GetChild(i).gameObject.SetActive(false);
        }
        canvas.transform.Find("ViewWindow").gameObject.SetActive(true);

        skill.SetFlag(true);
    }

    public IEnumerator MoveTo(GameObject player, Transform goal, Skill skill)
    {
        Animator animator = player.GetComponentInChildren<Animator>();

        player.transform.LookAt(goal);
        animator.SetFloat("speed", 5);
        float tt = 0;
        Vector3 origin = player.transform.position;
        Vector3 end = goal.position;

        while (player.transform.position != goal.position)
        {
            player.transform.position = Vector3.Lerp(origin, end, tt);
            tt += Time.deltaTime;
            yield return null;
        }
        animator.SetFloat("speed", 0);
        skill.SetFlag(true);
    }

    public IEnumerator PhysicalAttack(GameObject player, Skill skill)
    {
        Animator animator = player.GetComponentInChildren<Animator>();
        animator.Play("physicalAttack");
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        //yield return new WaitUntil(() => {return info.IsName("Base Layer.physicalAttack") && info.normalizedTime >= 1.0f; });
        yield return new WaitForSeconds(1.3f);
        animator.Play("idle");
        skill.SetFlag(true);
    }

    public IEnumerator TrunBack(GameObject player, Transform goal, Skill skill)
    {
        Animator animator = player.GetComponentInChildren<Animator>();

        player.transform.LookAt(goal);
        animator.SetFloat("speed", 5);
        float tt = 0;
        Vector3 origin = player.transform.position;
        Vector3 end = goal.position;

        while (player.transform.position != goal.position)
        {
            player.transform.position = Vector3.Lerp(origin, end, tt);
            tt += Time.deltaTime;
            yield return null;
        }
        animator.SetFloat("speed", 0);
        player.transform.localPosition = Vector3.zero;
        player.transform.localRotation = Quaternion.Euler(Vector3.zero);

        skill.SetFlag(true);
    }

    public IEnumerator Defend(GameObject player, Skill skill)
    {
        Animator animator = player.GetComponentInChildren<Animator>();

        animator.Play("defend");
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        //yield return new WaitUntil(() => { return info.IsName("Base Layer.defend") &&info.normalizedTime >= 1.0f; });
        yield return new WaitForSeconds(1f);
        animator.Play("idle");
    }

    public IEnumerator MagicAttack(GameObject player, Skill skill)
    {
        Animator animator = player.GetComponentInChildren<Animator>();
        animator.Play("magicalAttack");
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        //yield return new WaitUntil(() => {return info.IsName("Base Layer.physicalAttack") && info.normalizedTime >= 1.0f; });
        yield return new WaitForSeconds(3f);
        animator.Play("idle");
        skill.SetFlag(true);
    }

    public void NextTurn()
    {
        index = (index + 1) % battleCount;
        GameObject player = GetPlayerTurn();
        if (player.GetComponent<PlayerComponent>().camp == Camp.enemy)
        {
            GameObject.Find("GlobalManager").GetComponent<Fight>().AutoUseSkill();
        }
        else
        {
            canvas.transform.Find("OperationWindow").gameObject.SetActive(true);
        }
    }
    public GameObject GetNextPlayer()
    {
        return que[(index + 1) % battleCount];
    }
}