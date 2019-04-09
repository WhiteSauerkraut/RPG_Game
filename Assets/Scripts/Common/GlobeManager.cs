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

    public Dictionary<string, Player> playersDictionary;

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
        playersDictionary = new Dictionary<string, Player>();
        Player mainChracter = new Player();
        Debug.Log(mainChracter);
        mainChracter.playerName = "郭靖";
        mainChracter.atk = 20;
        mainChracter.hp = 100;
        mainChracter.modelUrl = "Prefabs/role";
        mainChracter.skills = new string[]{"NormalAtk","NormalAtk", "NormalAtk", "NormalAtk"};

        Player enemy = new Player();
        enemy.playerName = "完颜康";
        enemy.atk = 15;
        enemy.hp = 80;
        enemy.modelUrl = "Prefabs/boss";
        enemy.skills = new string[] { "NormalAtk", "NormalAtk", "NormalAtk", "NormalAtk" };

        PutPlayer("郭靖", mainChracter);
        PutPlayer("完颜康", enemy);

    }

    /**
     * 根据键值取得角色数据
     */
    public Player GetPlayer(string key)
    {
        return playersDictionary[key];
    }

    /**
     * 根据键值放角色数据
     */
    public void PutPlayer(string key, Player player)
    {
        playersDictionary[key] = player;
    }

    /**
     * 开始战斗
     */
    public void StartBattle(string[] teammates, string[] enemys, int index/*场景编号*/)
    {

        GetComponent<BattleManager>().isInit = false;
        //加载场景
        StartCoroutine(LoadScene(teammates, enemys, index));

    }

    //异步加载场景

    IEnumerator LoadScene(string[] teammates, string[] enemys,  int index)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        GameObject loadingWindow = GameObject.Find("Canvas").transform.Find("LoadingWindow").gameObject;
        loadingWindow.SetActive(true);
        loadingWindow.transform.Find("Slider").gameObject.GetComponent<Slider>().value = async.progress / 0.9f;
        async.allowSceneActivation = false;
        StartCoroutine(AllowSceneActivation(1f, async));
        while (!async.isDone)
        {
            loadingWindow.transform.Find("Slider").gameObject.GetComponent<Slider>().value = async.progress/ 0.9f;
            yield return null;
        }
        GetComponent<BattleManager>().Init();
        //加入战斗
        BattleManager battleManager = this.GetComponent<BattleManager>();
        foreach (string teammate in teammates)
        {
            battleManager.AddTeammates(teammate);
        }
        foreach (string enemy in enemys)
        {
            battleManager.AddEnemys(enemy);
        }
    }
    //防止加载动画一闪而过
    IEnumerator AllowSceneActivation(float time, AsyncOperation async)
    {
        yield return new WaitForSeconds(time);
        async.allowSceneActivation = true;
    }

}
