﻿using System.Collections;
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


    // Start is called before the first frame update
    void Start()
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

        for(int i = 0; i < 5; i++)
        {
            SetClickListener(menuButtons[i], interfaces[i]);
        }
    }

    void SetClickListener(Button button, GameObject gameObject)
    {
        button.onClick.AddListener(delegate ()
        {
            if(gameObject.activeInHierarchy == false)
            {
                gameObject.SetActive(true);
            }
            foreach(GameObject obj in interfaces)
            {
                if(obj.transform != gameObject.transform)
                {
                    obj.SetActive(false);
                }
            }
        });
    }
}
