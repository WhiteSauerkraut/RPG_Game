using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/**
 * 创建日期：3/20
 * 创建人：lyj
 * 描述：全局管理类，用于管理游戏的全局信息
 * 注意：管理类使用的是“懒汉式”的单例模式
 * 更新日期：3/25
 * 更新人：yzy
 * 描述：增加了开始战斗的函数
 **/

public class GlobeManager : MonoBehaviour
{
    public Item[] Items { get; }

    public Dictionary<string, Player> Players;

    /**
     * 加载到下一场景
     */
    private void Awake()
    {
        DontDestroyOnLoad(this);
        Init();
    }

    /**
     * 初始化全局管理类
     */
    private void Init()
    {
        Players = new Dictionary<string, Player>();
        Player role = new Player();
        
        role.M_BasicProperty.M_IconPath = "";
        role.M_BasicProperty.M_ModelPath = "Prefabs/role";
        role.M_BasicProperty.M_Name = "郭靖";
        role.M_BasicProperty.M_Sex = Sex.Man;
        role.M_BasicProperty.M_Level = 1;

        role.M_BasicProperty.M_Race = Race.Human;
        role.M_BattelProperty.M_CurrentHp = 100;
        role.M_BattelProperty.M_CurrentMp = 100;
        role.M_BattelProperty.M_MaxHp = 100;
        role.M_BattelProperty.M_MaxHp = 100;
        role.M_BattelProperty.M_Atk = 10;
        role.M_BattelProperty.M_Def = 10;
        role.M_BattelProperty.M_Mgk = 5;
        role.M_BattelProperty.M_Rgs = 5;
        role.M_BattelProperty.M_Spd = 10;
        role.M_BattelProperty.M_State = State.Normal;

        Player boss = new Player();

        boss.M_BasicProperty.M_IconPath = "";
        boss.M_BasicProperty.M_ModelPath = "Prefabs/boss";
        boss.M_BasicProperty.M_Name = "完颜康";
        boss.M_BasicProperty.M_Sex = Sex.Man;
        boss.M_BasicProperty.M_Level = 1;
        boss.M_BasicProperty.M_Race = Race.Tao;

        boss.M_BattelProperty.M_CurrentHp = 100;
        boss.M_BattelProperty.M_CurrentMp = 100;
        boss.M_BattelProperty.M_MaxHp = 100;
        boss.M_BattelProperty.M_MaxHp = 100;
        boss.M_BattelProperty.M_Atk = 10;
        boss.M_BattelProperty.M_Def = 10;
        boss.M_BattelProperty.M_Mgk = 5;
        boss.M_BattelProperty.M_Rgs = 5;
        boss.M_BattelProperty.M_Spd = 10;
        boss.M_BattelProperty.M_State = State.Normal;

        PutPlayer(role.M_BasicProperty.M_Name, role);
        PutPlayer(boss.M_BasicProperty.M_Name, boss);
    }

    /**
     * 取得全局管理类实例
     */
    public static GlobeManager GetInstance()
    {
        GlobeManager globeManager = GameObject.Find("GM").GetComponent<GlobeManager>();
        return globeManager;
    }

    /**
     * 根据键值取得角色数据
     */
    public Player GetPlayer(string key)
    {
        return Players[key];
    }

    /**
     * 根据键值放角色数据
     */
    public void PutPlayer(string key, Player player)
    {
        Players.Add(key, player);
    }

    /**
     * 开始战斗
     */
    public void StartBattle(string[] teammates, string[] enemys, int index/*场景编号*/)
    {
        //加入战斗
        BattleManager battleManager = this.GetComponent<BattleManager>();
        foreach (string teammate in teammates)
        {
            battleManager.AddTeamate(teammate);
        }
        foreach (string enemy in enemys)
        {
            battleManager.AddEnemy(enemy);
        }


        //加载场景
        StartCoroutine(LoadScene(index));

    }

    //异步加载场景

    IEnumerator LoadScene(int index)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        GameObject loadingWindow = GameObject.Find("Canvas").transform.Find("LoadingWindow").gameObject;
        loadingWindow.SetActive(true);
        loadingWindow.transform.Find("Slider").gameObject.GetComponent<Slider>().value = async.progress / 0.9f;
        async.allowSceneActivation = false;
        StartCoroutine(AllowSceneActivation(1f, async));
        if (!async.isDone)
        {
            loadingWindow.transform.Find("Slider").gameObject.GetComponent<Slider>().value = async.progress/ 0.9f;
            yield return null;
        }
        else
        {
            GetComponent<BattleManager>().Init();
        }

    }
    //防止加载动画一闪而过
    IEnumerator AllowSceneActivation(float time, AsyncOperation async)
    {
        yield return new WaitForSeconds(time);
        async.allowSceneActivation = true;
    }
}
