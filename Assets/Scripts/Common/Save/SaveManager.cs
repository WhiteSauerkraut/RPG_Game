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

    // 存储任务信息目录
    private string saveTaskPath = Application.persistentDataPath + "/Save/Task";

    // 存储游戏数据
    private string saveGameDataPath = Application.persistentDataPath + "/Save/GameData";

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

        SaveAssist saveAssist = GameObject.Find("GM").GetComponent<SaveAssist>();
        saveAssist.SaveGameDataFromScene();
        SavePlayersToFile();
        SaveTasksToFile();
        SaveGameDataToFile();
        InventroyManager.Instance.SaveInventory();
    }

    /*
     * 读档函数
     */
    public void Load()
    {
        Debug.Log("Load 调用.......");
        SaveAssist saveAssist = GameObject.Find("GM").GetComponent<SaveAssist>();
        if (SaveHelper.IsDirectoryExists(savePlayerPath))
        {
            LoadPlayersFromFile();
        }
        if(SaveHelper.IsDirectoryExists(saveTaskPath))
        {
            LoadTasksFromFile();
        }
        if(SaveHelper.IsDirectoryExists(saveGameDataPath))
        {
            LoadGameDataFromFile();
            saveAssist.LoadGameDataToScene();
        }  
    }

    /**
     * 删除存档
     * */
    public void Delete()
    {
        Debug.Log("Delete 调用.......");
        SaveHelper.DeleteFolder(savePath);
    }

    /**
     * 存储游戏数据信息
     * */
    public void SaveGameDataToFile()
    {
        if (!SaveHelper.IsDirectoryExists(saveGameDataPath))
        {
            SaveHelper.CreateDirectory(saveGameDataPath);
        }
        string fileName = saveGameDataPath + "/" +  "GameData.sav";
        SaveData saveData = GameObject.Find("GM").GetComponent<GlobeManager>().M_SaveData;
        SaveHelper.SetData(fileName, saveData);
    }

    /**
     * 从文件读取游戏数据信息
     * */
    public void LoadGameDataFromFile()
    {
        DirectoryInfo dir = new DirectoryInfo(saveGameDataPath);
        FileInfo[] files = dir.GetFiles();
        if(files.Length > 0)
        {
            SaveData saveData = (SaveData)SaveHelper.GetData(files[0].FullName, typeof(SaveData));
            GameObject.Find("GM").GetComponent<GlobeManager>().M_SaveData = saveData;
        }          
    }

    /*
     * 存储人物信息
     */
    private void SavePlayerToFile(Player player)
    {
        string fileName = savePlayerPath + "/" + player.M_BasicProperty.M_Name + ".sav";
        SaveHelper.SetData(fileName, player);
    }

    /*
     * 读取人物信息
     */
    private Player LoadPlayerFromFile(string fileName)
    {
        Player player = (Player)SaveHelper.GetData(fileName, typeof(Player));
        return player;
    }

    /*
     * 存储全部角色的信息到文件
     */
    private void SavePlayersToFile()
    {
        if (!SaveHelper.IsDirectoryExists(savePlayerPath))
        {
            SaveHelper.CreateDirectory(savePlayerPath);
        }

        Dictionary<string, Player> players = GameObject.Find("GM").GetComponent<GlobeManager>().playersDictionary;
        foreach (string key in players.Keys)
        {
            SavePlayerToFile(players[key]);
        }
    }

    /**
     * 从文件加载全部角色的信息
     */
    private void LoadPlayersFromFile()
    {
        DirectoryInfo dir = new DirectoryInfo(savePlayerPath);
        FileInfo[] files = dir.GetFiles();

        Dictionary<string, Player> players = GameObject.Find("GM").GetComponent<GlobeManager>().playersDictionary;

        foreach (FileInfo file in files)
        {
            Player player = LoadPlayerFromFile(file.FullName);
            string key = Path.GetFileNameWithoutExtension(file.Name);
            players[key] = player;
        }
    }



    /*
     * 存储任务信息
     */
    private void SaveTaskToFile(SaveTask task)
    {
        string fileName = saveTaskPath + "/" + task.taskID + ".sav";
        SaveHelper.SetData(fileName, task);
    }

    /*
     * 读取任务信息
     */
    private SaveTask LoadTaskFromFile(string fileName)
    {
        SaveTask task = (SaveTask)SaveHelper.GetData(fileName, typeof(SaveTask));
        return task;
    }

    /*
     * 存储全部任务的信息到文件
     */
    private void SaveTasksToFile()
    {
        if (!SaveHelper.IsDirectoryExists(saveTaskPath))
        {
            SaveHelper.CreateDirectory(saveTaskPath);
        }

        Dictionary<string, Task> tasks = TaskManager.Instance.dictionary;
        foreach (string key in tasks.Keys)
        {
            Task task = tasks[key];
            SaveTask saveTask = new SaveTask(task.taskID);
            SaveTaskToFile(saveTask);
        }
    }

    /**
     * 从文件加载全部任务的信息
     */
    private void LoadTasksFromFile()
    {
        DirectoryInfo dir = new DirectoryInfo(saveTaskPath);
        FileInfo[] files = dir.GetFiles();

        foreach (FileInfo file in files)
        {
            SaveTask task = LoadTaskFromFile(file.FullName);
            //string key = Path.GetFileNameWithoutExtension(file.Name);
            //tasks[key] = new Task(task.taskID);
            TaskManager.Instance.GetTask(task.taskID);
        }
    }

    /**
     * 存档不存在时，初始化数据并生成存档文件
     * */
    public void InitData()
    {
        Debug.Log("初始化数据.......");

        Player role = new Player();

        role.M_BasicProperty.M_IconPath = "";
        role.M_BasicProperty.M_ModelPath = "Prefabs/role";
        role.M_BasicProperty.M_Name = "郭靖";
        role.M_Skills = new string[] { "NormalAtk", "GainSkill", "NormalAtk", "NormalAtk" };
        role.M_BasicProperty.M_Sex = Sex.Man;
        role.M_BasicProperty.M_Level = 1;

        role.M_BasicProperty.M_Race = Race.Human;     
        role.M_BattleProperty.M_MaxHp = 100;
        role.M_BattleProperty.M_MaxMp = 30;
        role.M_BattleProperty.M_CurrentHp = 100;
        role.M_BattleProperty.M_CurrentMp = 30;
        role.M_BattleProperty.M_Atk = 25;
        role.M_BattleProperty.M_Def = 20;
        role.M_BattleProperty.M_Mgk = 25;
        role.M_BattleProperty.M_Rgs = 15;
        role.M_BattleProperty.M_Spd = 10;
        role.M_BattleProperty.M_State = State.Normal;

        Player boss = new Player();

        boss.M_BasicProperty.M_IconPath = "";
        boss.M_BasicProperty.M_ModelPath = "Prefabs/boss";
        boss.M_BasicProperty.M_Name = "完颜康";
        boss.M_Skills = new string[] { "NormalAtk", "NormalAtk", "NormalAtk", "NormalAtk" };
        boss.M_BasicProperty.M_Sex = Sex.Man;
        boss.M_BasicProperty.M_Level = 1;
        boss.M_BasicProperty.M_Race = Race.Tao;

        boss.M_BattleProperty.M_MaxHp = 100;
        boss.M_BattleProperty.M_MaxMp = 30;
        boss.M_BattleProperty.M_CurrentHp = 100;
        boss.M_BattleProperty.M_CurrentMp = 30;
        boss.M_BattleProperty.M_Atk = 25;
        boss.M_BattleProperty.M_Def = 15;
        boss.M_BattleProperty.M_Mgk = 20;
        boss.M_BattleProperty.M_Rgs = 10;
        boss.M_BattleProperty.M_Spd = 8;
        boss.M_BattleProperty.M_State = State.Normal;

        GameObject.Find("GM").GetComponent<GlobeManager>().PutPlayer(role.M_BasicProperty.M_Name, role);
        GameObject.Find("GM").GetComponent<GlobeManager>().PutPlayer(boss.M_BasicProperty.M_Name, boss);
    }
}
