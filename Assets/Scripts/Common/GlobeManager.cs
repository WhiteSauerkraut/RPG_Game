using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 创建日期：3/20
 * 创建人：lyj
 * 描述：全局管理类，用于管理游戏的全局信息
 * 注意：管理类使用的是“懒汉式”的单例模式
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
        role.M_BasicProperty.M_ModelUrl = "";
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
        boss.M_BasicProperty.M_ModelUrl = "";
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
}
