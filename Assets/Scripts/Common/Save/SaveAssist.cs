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
    * 读取并更新人物位置(需调用新场景的对象更新)
    * */
    private void LoadPlayerTransform()
    {
        GameObject.Find("Directional Light").AddComponent<SaveComponent>();
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
     * 异步加载场景
     * */
    IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        yield return new WaitForEndOfFrame();     
        async.allowSceneActivation = false;
        StartCoroutine(AllowSceneActivation(1f, async));    
        while (!async.isDone)
        {
            yield return null;
        }
        GameObject loadingWindow = GameObject.Find("Canvas").transform.Find("LoadingWindow").gameObject;
        loadingWindow.SetActive(true);
        loadingWindow.transform.Find("Slider").gameObject.GetComponent<Slider>().value = async.progress / 0.9f;
        LoadPlayerTransform();
        while(GameObject.Find("Directional Light").GetComponent<SaveComponent>() != null)
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        loadingWindow.SetActive(false);
    }

    IEnumerator AllowSceneActivation(float time, AsyncOperation async)
    {
        yield return new WaitForSeconds(time);
        async.allowSceneActivation = true;
    }
}
