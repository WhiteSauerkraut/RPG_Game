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

    private static readonly GlobeManager instance = new GlobeManager();

    private GlobeManager()
    {
        Init();
    }

    /**
     * 初始化全局管理类
     */
    private void Init()
    {

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
}
