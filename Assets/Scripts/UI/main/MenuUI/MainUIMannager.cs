using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 创建日期：3/19
 * 创建人：LYJ
 * 描述：主界面UI管理类，用于管理菜单按钮的交互
**/

public class MainUIMannager : MonoBehaviour
{
    // 菜单按钮
    private Button[] menuButtons;

    // 按钮响应界面
    private GameObject[] interfaces;

    void Awake()
    {
        menuButtons = new Button[5];
        interfaces = new GameObject[5];

        menuButtons[0] = transform.Find("menuButtons/Button_Character").gameObject.GetComponent<Button>();
        menuButtons[1] = transform.Find("menuButtons/Button_Task").gameObject.GetComponent<Button>();
        menuButtons[2] = transform.Find("menuButtons/Button_Bag").gameObject.GetComponent<Button>();
        menuButtons[3] = transform.Find("menuButtons/Button_Skill").gameObject.GetComponent<Button>();
        menuButtons[4] = transform.Find("menuButtons/Button_Setting").gameObject.GetComponent<Button>();

        interfaces[0] = transform.Find("Interfaces/Character_Interface").gameObject;
        interfaces[1] = transform.Find("Interfaces/Task_Interface").gameObject;
        interfaces[2] = transform.Find("Interfaces/Bag_Interface").gameObject;
        interfaces[3] = transform.Find("Interfaces/Skill_Interface").gameObject;
        interfaces[4] = transform.Find("Interfaces/Setting_Interface").gameObject;

        SetClickListener();
    }

    // Start is called before the first frame update
    void Start()
    {
        HidePanels();
    }

    void SetClickListener()
    {
        menuButtons[0].onClick.AddListener(delegate ()
        {
            Hide(interfaces[1]);
            Hide(interfaces[3]);
            Hide(interfaces[4]);
            Show(interfaces[0]);
        });

        menuButtons[1].onClick.AddListener(delegate ()
        {
            Hide(interfaces[0]);
            Hide(interfaces[2]);
            Hide(interfaces[3]);
            Hide(interfaces[4]);
            Show(interfaces[1]);
        });

        menuButtons[2].onClick.AddListener(delegate ()
        {
            Hide(interfaces[1]);
            Hide(interfaces[3]);
            Hide(interfaces[4]);
            Show(interfaces[2]);
        });

        menuButtons[3].onClick.AddListener(delegate ()
        {
            Hide(interfaces[0]);
            Hide(interfaces[1]);
            Hide(interfaces[2]);
            Hide(interfaces[4]);
            Show(interfaces[3]);
        });

        menuButtons[4].onClick.AddListener(delegate ()
        {
            Hide(interfaces[0]);
            Hide(interfaces[1]);
            Hide(interfaces[2]);
            Hide(interfaces[3]);
            Show(interfaces[4]);
        });
    }

    /**
     * 面板的显示方法：面板显示时为可交互状态
     * */
    public void Show(GameObject gameObject)
    {
        CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
    }

    /**
     * 面板的隐藏方法：面板隐藏后为不可交互状态
     * */
    public void Hide(GameObject gameObject)
    {
        CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;
    }

    /**
     * 隐藏全部面板
     * */
    public void HidePanels()
    {
        foreach (GameObject obj in interfaces)
        {
            Hide(obj);
        }
    }
}
