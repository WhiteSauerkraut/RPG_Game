using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * 创建日期：4/15
 * 创建人：lyj
 * 描述：存储辅助动作类，挂载在GM上
 **/

public class SaveAssist : MonoBehaviour
{
    bool isLoad = false;

    /**
     * 存储人物位置
     * */
    private void SavePlayerTransform()
    {
        MyTransform myTransform = GameObject.Find("GM").GetComponent<GlobeManager>().GetPlayer("郭靖").M_BasicProperty.M_Transform;
        GameObject player = GameObject.Find("郭靖");

        myTransform.Pos_x = player.GetComponent<Transform>().position.x;
        myTransform.Pos_y = player.GetComponent<Transform>().position.y;
        myTransform.Pos_z = player.GetComponent<Transform>().position.z;

        myTransform.R_x = player.GetComponent<Transform>().localEulerAngles.x;
        myTransform.R_y = player.GetComponent<Transform>().localEulerAngles.y;
        myTransform.R_z = player.GetComponent<Transform>().localEulerAngles.z;

        myTransform.S_x = player.GetComponent<Transform>().localScale.x;
        myTransform.S_y = player.GetComponent<Transform>().localScale.x;
        myTransform.S_z = player.GetComponent<Transform>().localScale.x;
    }

    /**
     * 存储场景中的游戏数据
     * */
    public void SaveGameDataFromScene()
    {
        Debug.Log("Save To Global...");
        SavePlayerTransform();
        SaveData saveData = GameObject.Find("GM").GetComponent<GlobeManager>().M_SaveData;
        saveData.CurSceneName = SceneManager.GetActiveScene().name;
    }

    /**
     * 加载数据到场景中
     * */
    public void LoadGameDataToScene()
    {
        Debug.Log("Load From Global...");
        SaveData saveData = GameObject.Find("GM").GetComponent<GlobeManager>().M_SaveData;
        StartCoroutine(LoadSceneAndData(saveData.CurSceneName));
    }

    /**
     * 从战斗场景返回主场景
     * */
    public void ReturnToScene()
    {
        Debug.Log("Return to Scene...");

        // 解除Canvas父子关系，防止Canvas被销毁
        GameObject.Find("RootCanvas").transform.DetachChildren();
        GameObject.FindGameObjectWithTag("Canvas").gameObject.GetComponent<CanvasDontDestroy>().Awake();
        
        SaveData saveData = GameObject.Find("GM").GetComponent<GlobeManager>().M_SaveData;
        StartCoroutine(ReturnScene(saveData.CurSceneName));
    }

    /**
     * 异步返回场景,加载人物位置
     * */
    public IEnumerator ReturnScene(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        GameObject loadingWindow = GameObject.FindGameObjectWithTag("Canvas").transform.Find("LoadingWindow").gameObject;
        loadingWindow.SetActive(true);
        loadingWindow.transform.Find("Slider").gameObject.GetComponent<Slider>().value = async.progress / 0.9f;
        async.allowSceneActivation = false;
        StartCoroutine(AllowSceneActivation(1f, async));
        while (!async.isDone)
        {
            loadingWindow.transform.Find("Slider").gameObject.GetComponent<Slider>().value = async.progress / 0.9f;
            yield return null;
        }

        // 设置角色位置
        GameObject player = GameObject.Find("郭靖");
        player.AddComponent<SaveComponent>();
        while (player.GetComponent<SaveComponent>() != null)
        {
            yield return null;
        }
        StartCoroutine(AllowLoadingWindowHide(0.5f, loadingWindow));

        isLoad = true;
    }

    /**
     * 异步加载场景
     * */
    public IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        GameObject loadingWindow = GameObject.FindGameObjectWithTag("Canvas").transform.Find("LoadingWindow").gameObject;
        loadingWindow.SetActive(true);
        loadingWindow.transform.Find("Slider").gameObject.GetComponent<Slider>().value = async.progress / 0.9f;
        async.allowSceneActivation = false;
        StartCoroutine(AllowSceneActivation(1f, async));
        while (!async.isDone)
        {
            loadingWindow.transform.Find("Slider").gameObject.GetComponent<Slider>().value = async.progress / 0.9f;
            yield return null;
        }

        StartCoroutine(AllowLoadingWindowHide(0.5f, loadingWindow));
        isLoad = true;
    }

    /**
     * 异步加载场景，加载存储游戏数据
     * */
    IEnumerator LoadSceneAndData(string sceneName)
    {
        isLoad = false;
        StartCoroutine(ReturnScene(sceneName));

        yield return new WaitUntil(GetIsLoad);

        // 重新加载场景后，需要初始化变量
        InventroyManager.Instance.Start();
        TradeManager.Instance.Start();

        // 从文件加载背包数据
        InventroyManager.Instance.LoadInventory();
    }

    IEnumerator AllowLoadingWindowHide(float time, GameObject loadingWindow)
    {
        yield return new WaitForSeconds(time);
        loadingWindow.SetActive(false);
    }

    IEnumerator AllowSceneActivation(float time, AsyncOperation async)
    {
        yield return new WaitForSeconds(time);
        async.allowSceneActivation = true;
    }

    bool GetIsLoad()
    {
        return isLoad;
    }
}
