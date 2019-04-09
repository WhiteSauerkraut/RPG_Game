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
    private GameObject mainInterface;

    // Start is called before the first frame update
    void Start()
    {
        mainInterface = transform.Find("MenuUI").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if(mainInterface.activeInHierarchy == true)
            {
                mainInterface.SetActive(false);
            }
            else
            {
                mainInterface.SetActive(true);
            }
        }
    }
}
