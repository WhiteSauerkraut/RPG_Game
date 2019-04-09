using System.Collections.Generic;
using UnityEngine;
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

//        GameObject.Find("Canvas/OperationWindow").SetActive(true);
        isInit = true;
    }


    public void AddTeammates(string playerName)
    {
        Player player = GetComponent<GlobeManager>().GetPlayer(playerName);
        //实例化
        teammates[teammatesIndex] = (GameObject)Resources.Load(player.modelUrl);
        teammates[teammatesIndex] = Instantiate(teammates[teammatesIndex], teammatesSets.GetChild(teammatesIndex));
        teammates[teammatesIndex].name = playerName;
        //添加组件
        PlayerComponent pc = teammates[teammatesIndex].AddComponent<PlayerComponent>();
        pc.Init(player);

        //加入战斗队列
        que[battleCount++] = teammates[teammatesIndex];

        teammatesIndex++;

    }

    public void AddEnemys(string playerName)
    {
        Player player = GetComponent<GlobeManager>().GetPlayer(playerName);
        //实例化
        enemys[enemysIndex] = (GameObject)Resources.Load(player.modelUrl);
        enemys[enemysIndex].name = playerName;
        enemys[enemysIndex] = Instantiate(enemys[enemysIndex], enemySets.GetChild(enemysIndex));
        //添加组件
        PlayerComponent pc = enemys[enemysIndex].AddComponent<PlayerComponent>();
        pc.Init(player);

        //加入战斗队列
        que[battleCount++] = enemys[enemysIndex];

        enemysIndex++;
    }

    public GameObject GetPlayerTurn()
    {
        return que[index];
    }
}