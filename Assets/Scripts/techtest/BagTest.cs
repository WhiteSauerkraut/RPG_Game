﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// 模拟主角类
/// </summary>
public class BagTest : MonoBehaviour
{
    
	// Use this for initialization
	void Start(){ }
	
	// Update is called once per frame
	void Update () {
        //按G键随机得到一个物品
        if (Input.GetKeyDown(KeyCode.G))
        {
            int id = Random.Range(1, 19);
            Knapscak.Instance.StoreItem(id);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            InventroyManager.Instance.SaveInventory();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            InventroyManager.Instance.LoadInventory();

        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            SaveManager.GetInstance().Save();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SaveManager.GetInstance().Load();
        }
    }
}
