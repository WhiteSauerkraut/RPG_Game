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
        if(_instance == null)
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
        LoadPlayers();    
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

        Dictionary<string, Player> players = GlobeManager.GetInstance().Players;
        foreach(string key in players.Keys)
        {
            SavePlayer(players[key]);
            Debug.Log("Save " + key);
        }
    }

    /**
     * 加载全部角色的信息
     */
    private void LoadPlayers()
    {
        DirectoryInfo dir = new DirectoryInfo(savePlayerPath);
        FileInfo[] files = dir.GetFiles();

        Dictionary<string, Player> players = GlobeManager.GetInstance().Players;

        foreach (FileInfo file in files)
        {
            Player player = LoadPlayer(file.FullName);
            string key = Path.GetFileNameWithoutExtension(file.Name);
            players[key] = player;
        }
    }
}
