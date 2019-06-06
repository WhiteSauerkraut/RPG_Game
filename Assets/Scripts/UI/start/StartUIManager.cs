using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 初始界面UI交互控制
/// </summary>
public class StartUIManager : MonoBehaviour
{
    Button btn_restart;
    Button btn_load;
    Button btn_exit;

    // Start is called before the first frame update
    void Start()
    {
        btn_restart = transform.Find("start").GetComponent<Button>();
        btn_load = transform.Find("load").GetComponent<Button>();
        btn_exit = transform.Find("exit").GetComponent<Button>();

        btn_restart.onClick.AddListener(LoadStartScene);
        btn_load.onClick.AddListener(LoadSaveScene);
        btn_exit.onClick.AddListener(ExitScene);
    }

    void LoadStartScene()
    {
        SaveAssist saveAssist = GameObject.Find("GM").GetComponent<SaveAssist>();
        saveAssist.StartCoroutine(saveAssist.LoadScene("mainScene"));
        gameObject.SetActive(false);
    }

    void LoadSaveScene()
    {
        SaveManager.GetInstance().Load();
        gameObject.SetActive(false);
    }

    void ExitScene()
    {
        Debug.Log("退出游戏");
        Application.Quit();
    }
}
