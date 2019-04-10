using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/**
 * 创建日期：3/27
 * 创建人：lyj
 * 描述：存档管理类，使用单例模式
 **/

public class SaveManager
{
    // 存储文件根目录
    private string savePath = Application.persistentDataPath + "/Save";

    // 存储人物信息目录
    private string savePlayerPath = Application.persistentDataPath + "/Save/Player";

    private static SaveManager _instance;

    private SaveManager() { }

    public static SaveManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new SaveManager();
        }
        return _instance;
    }

    /**
     * 存档函数
     **/
    public void Save()
    {
        Debug.Log("Save 调用.......");
        SavePlayers();
    }

    /*
     * 读档函数
     */
    public void Load()
    {
        Debug.Log("Load 调用.......");
        if (!SaveHelper.IsDirectoryExists(savePlayerPath))
        {
            Debug.Log("初始化数据.......");
            InitData();
            Save();
        }
        LoadPlayers();
    }

    /**
     * 删除存档
     * */
    public void Delete()
    {
        Debug.Log("Delete 调用.......");
        SaveHelper.DeleteFolder(savePath);
    }

    /*
     * 存储人物信息
     */
    private void SavePlayer(Player player)
    {
        string fileName = savePlayerPath + "/" + player.M_BasicProperty.M_Name + ".sav";
        SaveHelper.SetData(fileName, player);
    }

    /*
     * 读取人物信息
     */
    private Player LoadPlayer(string fileName)
    {
        Player player = (Player)SaveHelper.GetData(fileName, typeof(Player));
        return player;
    }

    /*
     * 存储全部角色的信息
     */
    private void SavePlayers()
    {
        if (!SaveHelper.IsDirectoryExists(savePlayerPath))
        {
            SaveHelper.CreateDirectory(savePlayerPath);
        }

        Dictionary<string, Player> players = GameObject.Find("GM").GetComponent<GlobeManager>().playersDictionary;
        foreach (string key in players.Keys)
        {
            SavePlayer(players[key]);
        }
    }

    /**
     * 加载全部角色的信息
     */
    private void LoadPlayers()
    {
        DirectoryInfo dir = new DirectoryInfo(savePlayerPath);
        FileInfo[] files = dir.GetFiles();

        Dictionary<string, Player> players = GameObject.Find("GM").GetComponent<GlobeManager>().playersDictionary;

        foreach (FileInfo file in files)
        {
            Player player = LoadPlayer(file.FullName);
            string key = Path.GetFileNameWithoutExtension(file.Name);
            players[key] = player;
        }
    }

    /**
     * 存档不存在时，初始化数据并生成存档文件
     * */
    private void InitData()
    {
        Player role = new Player();

        role.M_BasicProperty.M_IconPath = "";
        role.M_BasicProperty.M_ModelPath = "Prefabs/role";
        role.M_BasicProperty.M_Name = "郭靖";
        role.M_Skills = new string[] { "NormalAtk", "GainSkill", "NormalAtk", "NormalAtk" };
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
        boss.M_Skills = new string[] { "NormalAtk", "NormalAtk", "NormalAtk", "NormalAtk" };
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

        GameObject.Find("GM").GetComponent<GlobeManager>().PutPlayer(role.M_BasicProperty.M_Name, role);
        GameObject.Find("GM").GetComponent<GlobeManager>().PutPlayer(boss.M_BasicProperty.M_Name, boss);
    }
}
