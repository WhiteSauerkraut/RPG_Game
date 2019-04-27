using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 创建日期：3/19
 * 创建人：LYJ
 * 描述：主界面UI显示控制类，用于控制菜单UI的显示
**/

public class MainUIShowControl : MonoBehaviour
{
    private GameObject main_btn;
    private GameObject interfaces;

    // Start is called before the first frame update
    void Start()
    {
        main_btn = transform.Find("menuButtons").gameObject;
        interfaces = transform.Find("Interfaces").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            gameObject.SendMessage("HidePanels");
            if(main_btn.activeInHierarchy == true)
            {
                main_btn.SetActive(false);
                interfaces.SetActive(false);
            }
            else
            {
                main_btn.SetActive(true);
                interfaces.SetActive(true);
            }
        }
    }
}
