using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 创建日期：4/26
 * 创建人：LYJ
 * 描述：背包界面切换
**/

public class BagSwitch : MonoBehaviour
{
    Button btn_item;
    Button btn_taskitem;
    GameObject bagslot;
    GameObject taskslot;

    // Start is called before the first frame update
    void Start()
    {
        btn_item = transform.Find("btn_item").gameObject.GetComponent<Button>();
        btn_taskitem = transform.Find("btn_taskitem").gameObject.GetComponent<Button>();
        bagslot = transform.Find("bagslot").gameObject;
        taskslot = transform.Find("taskslot").gameObject;

        btn_item.onClick.AddListener(delegate ()
        {
            Hide(taskslot);
            Show(bagslot);
        });

        btn_taskitem.onClick.AddListener(delegate ()
        {
            Hide(bagslot);
            Show(taskslot);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
