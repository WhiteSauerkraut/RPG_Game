using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 创建日期：4/16
 * 创建人：LYJ
 * 描述：设置界面UI管理类
**/

public class SettingUIManager : MonoBehaviour
{
    // 设置按钮
    private Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        buttons = new Button[5];

        buttons[0] = transform.Find("SaveGame").gameObject.GetComponent<Button>();
        buttons[1] = transform.Find("LoadGame").gameObject.GetComponent<Button>();
        buttons[2] = transform.Find("ReturnGame").gameObject.GetComponent<Button>();
        buttons[3] = transform.Find("ReturnLogin").gameObject.GetComponent<Button>();
        buttons[4] = transform.Find("QuitGame").gameObject.GetComponent<Button>();

        SetSaveGameBtnListener();
        SetLoadGameBtnListener();
    }

    void SetSaveGameBtnListener()
    {
        buttons[0].onClick.AddListener(delegate ()
        {
            SaveManager.GetInstance().Save();
        });
    }

    void SetLoadGameBtnListener()
    {
        buttons[1].onClick.AddListener(delegate ()
        {
            SaveManager.GetInstance().Load();
        });
    }
}
