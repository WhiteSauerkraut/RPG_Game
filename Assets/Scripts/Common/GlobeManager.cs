﻿using System.Collections;
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

    public Dictionary<string, Player> Players { get; }

    private static readonly GlobeManager instance = null;

    static GlobeManager()
    {
        instance = new GlobeManager();
    }

    /**
     * 初始化全局管理类
     */
    private void Init()
    {
        Player role = new Player();
        
        role.M_BasicProperty.M_IconUrl = "";
        role.M_BasicProperty.M_ModelUrl = "Prefabs/role";
        role.M_BasicProperty.M_Name = "郭靖";
        role.M_BasicProperty.M_Sex = Sex.Man;
        role.M_BasicProperty.M_Level = 1;

        role.M_BasicProperty.M_Race = Race.Human;
        role.M_BattelProperty.M_CurrentHp = 100;
        role.M_BattelProperty.M_CurrentMp = 100;
        role.M_BattelProperty.M_MaxHp = 100;
        role.M_BattelProperty.M_MaxHp = 100;
        role.M_BattelProperty.M_Physical_Attack = 10;
        role.M_BattelProperty.M_Physical_Defense = 10;
        role.M_BattelProperty.M_Magic_Attack = 5;
        role.M_BattelProperty.M_Magic_Defense = 5;
        role.M_BattelProperty.M_Speed = 10;
        role.M_BattelProperty.M_State = State.Normal;

        Player boss = new Player();

        boss.M_BasicProperty.M_IconUrl = "";
        boss.M_BasicProperty.M_ModelUrl = "Prefabs/boss";
        boss.M_BasicProperty.M_Name = "完颜康";
        boss.M_BasicProperty.M_Sex = Sex.Man;
        boss.M_BasicProperty.M_Level = 1;
        boss.M_BasicProperty.M_Race = Race.Tao;

        boss.M_BattelProperty.M_CurrentHp = 100;
        boss.M_BattelProperty.M_CurrentMp = 100;
        boss.M_BattelProperty.M_MaxHp = 100;
        boss.M_BattelProperty.M_MaxHp = 100;
        boss.M_BattelProperty.M_Physical_Attack = 10;
        boss.M_BattelProperty.M_Physical_Defense = 10;
        boss.M_BattelProperty.M_Magic_Attack = 5;
        boss.M_BattelProperty.M_Magic_Defense = 5;
        boss.M_BattelProperty.M_Speed = 10;
        boss.M_BattelProperty.M_State = State.Normal;

        PutPlayer(role.M_BasicProperty.M_Name, role);
        PutPlayer(boss.M_BasicProperty.M_Name, boss);
    }

    /**
     * 取得全局管理类实例
     */
    public static GlobeManager GetInstance()
    {
        return instance;
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
        BattleManager battleManager = BattleManager.Instance;
        foreach (string teammate in teammates)
        {
            battleManager.AddTeamate(teammate);
        }
        foreach (string enemy in enemys)
        {
            battleManager.AddEnemy(enemy);
        }

        //初始化数值

        battleManager.Init();

        //加载场景
        StartCoroutine(LoadScene(index));

    }

    //异步加载场景

    IEnumerator LoadScene(int index)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        Debug.Log(async);
        GameObject loadingWindow = GameObject.Find("Canvas").transform.Find("LoadingWindow").gameObject;
        loadingWindow.transform.Find("Slider").gameObject.GetComponent<Slider>().value = async.progress / 0.9f;
        if (!async.isDone)
        {
            loadingWindow.transform.Find("Slider").gameObject.GetComponent<Slider>().value = async.progress/ 0.9f;
            yield return null;
        }

        yield return new WaitForSeconds(1);

    }
}
