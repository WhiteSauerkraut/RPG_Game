using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * 创建日期：4/15
 * 创建人：lyj
 * 描述：逃跑按钮响应动作
 **/

public class EscapeButtonClick : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    /**
     * 点击事件
     * */
    private void OnClick()
    {
        GameObject.Find("GM").GetComponent<SaveAssist>().LoadGameDataToScene();
    }
}
