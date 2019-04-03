using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 创建日期：3/19
 * 创建人：LYJ
 * 描述：人物界面管理类，用于切换装备栏和属性栏
**/

public class SwitchInterface : MonoBehaviour
{
    private Button button_Right;
    private Button button_Left;
    private GameObject equipment_Interface;
    private GameObject property_Interface;

    // Start is called before the first frame update
    void Start()
    {
        button_Right = transform.Find("Equipment_Interface/Button_Right").gameObject.GetComponent<Button>();
        button_Left = transform.Find("Property_Interface/Button_Left").gameObject.GetComponent<Button>();
        equipment_Interface = transform.Find("Equipment_Interface").gameObject;
        property_Interface = transform.Find("Property_Interface").gameObject;

        button_Right.onClick.AddListener(SetButton_Right_Listener);
        button_Left.onClick.AddListener(SetButton_Left_Listener);
    }

    void SetButton_Right_Listener()
    {
        equipment_Interface.SetActive(false);
        property_Interface.SetActive(true);
    }

    void SetButton_Left_Listener()
    {
        equipment_Interface.SetActive(true);
        property_Interface.SetActive(false);
    }
}
