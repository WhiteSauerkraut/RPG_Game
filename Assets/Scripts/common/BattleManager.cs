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

public class BattleManager:MonoBehaviour
{
    //队友列表
    private List<Player> teammates;
    //敌人列表
    private List<Player> enemys;
    //队列
    private Player[] que;
    //索引
    private int index=0;
    //战斗数量统计
    private int count=0;
    //战斗状态
    public BattleState battleState;
    //UI
    private GameObject canvas;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        teammates = new List<Player>();
        enemys = new List<Player>();
    }
    //初始化
    public void Init()
    {
        que = new Player[8];
        //初始化位置，并加入战斗队列
        index = 0;
        int teammateSetIndex = 0;
        int enemySetIndex = 0;
        Transform teammateSets = GameObject.Find("Sets/Teammates").transform;
        Transform enemySets = GameObject.Find("Sets/Enemys").transform;

        foreach (Player teammate in teammates)
        {
            GameObject player = (GameObject)Resources.Load(teammate.M_BasicProperty.M_ModelPath);
            player.name = teammate.M_BasicProperty.M_Name;
            InitSet(player, teammateSets.GetChild(teammateSetIndex++));
            AddToQue(teammate);
        }

        foreach (Player enemy in enemys)
        {
            GameObject player = (GameObject)Resources.Load(enemy.M_BasicProperty.M_ModelPath);
            player.name = enemy.M_BasicProperty.M_Name;
            InitSet(player, enemySets.GetChild(enemySetIndex++));
            AddToQue(enemy);
        }
        index = 0;
        battleState = BattleState.prepare;
        canvas = GameObject.Find("Canvas");
    }
    private void InitSet(GameObject _player, Transform set)
    {
        Instantiate(_player, set);
        _player.transform.localPosition = Vector3.zero;
    }

    //增加队友方法
    public void AddTeamate(string name)
    {
        GlobeManager gm = GlobeManager.GetInstance();
        teammates.Add(gm.GetPlayer(name));
        count++;
    }
    //增加敌人的方法
    public void AddEnemy(string name)
    {
        GlobeManager gm = GlobeManager.GetInstance();
        enemys.Add(gm.GetPlayer(name));
        count++;
    }
    //加入队列的方法
    private void AddToQue(Player player)
    {
        que[index] = player;
        MoveFront(index);
        index++;
    }
    //优先队列的实现方法
    private void MoveFront(int i)
    {
        while(i != 0 && que[i].M_BattelProperty.M_Spd > que[i - 1].M_BattelProperty.M_Spd)
        {
            Player tmp = que[i];
            que[i] = que[i - 1];
            que[i - 1] = tmp;
        }
    }
    private void Start()
    {

    }
    private void Update()
    {


    }


}