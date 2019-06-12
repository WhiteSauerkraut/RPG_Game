using UnityEngine;
using System.Collections;
/// <summary>
/// 任务道具背包类
/// </summary>
public class TaskInventroy : Inventroy
{
    //单例模式
    private static TaskInventroy _instance;
    public static TaskInventroy Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.Find("Canvas").transform.Find("MenuUI/Interfaces/Bag_Interface/taskslot").GetComponent<TaskInventroy>();
            }
            return _instance;
        }
    }
    public override void Start()
    {
        base.Start();
    }
}
