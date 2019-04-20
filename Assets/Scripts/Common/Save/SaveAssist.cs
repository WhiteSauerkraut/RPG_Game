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
        StartCoroutine(LoadScene(saveData.CurSceneName));
    }

    /**
     * 异步加载场景跟存储的人物位置
     * */
    IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        yield return new WaitForEndOfFrame();
        while (!async.isDone)
        {
            yield return null;
        }
        GameObject loadingWindow = GameObject.Find("Canvas").transform.Find("LoadingWindow").gameObject;
        loadingWindow.SetActive(true);
        GameObject player = GameObject.Find("郭靖");
        player.AddComponent<SaveComponent>();
        while (player.GetComponent<SaveComponent>() != null)
        {
            yield return null;
        }
        StartCoroutine(AllowLoadingWindowHide(0.5f, loadingWindow));
        // 重新加载场景后，需要初始化InventroyManager的变量
        InventroyManager.Instance.Start();
    }

    IEnumerator AllowLoadingWindowHide(float time, GameObject loadingWindow)
    {
        yield return new WaitForSeconds(time);
        loadingWindow.SetActive(false);
    }
}
