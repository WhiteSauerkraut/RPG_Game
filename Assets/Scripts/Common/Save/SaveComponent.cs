using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 创建日期：4/15
 * 创建人：lyj
 * 描述：临时组件类，添加到新场景对象并设置角色位置、背包
 **/

public class SaveComponent : MonoBehaviour
{
    private bool isSetPlayerTransfrom = false;

    // Update is called once per frame
    void Update()
    {
        if (!isSetPlayerTransfrom)
        {
            isSetPlayerTransfrom = true;
            LoadPlayerTransform();
            Destroy(this.gameObject.GetComponent<SaveComponent>());
        }
    }

    void LoadPlayerTransform()
    {
        GameObject player = GameObject.Find("郭靖");
        MyTransform myTransform = GameObject.Find("GM").GetComponent<GlobeManager>().GetPlayer("郭靖").M_BasicProperty.M_Transform;

        player.transform.position = new Vector3(myTransform.Pos_x, myTransform.Pos_y, myTransform.Pos_z);
        player.transform.rotation = Quaternion.Euler(myTransform.R_x, myTransform.R_y, myTransform.R_z);
        player.transform.localScale = new Vector3(myTransform.S_x, myTransform.S_y, myTransform.S_z);
    }
}
