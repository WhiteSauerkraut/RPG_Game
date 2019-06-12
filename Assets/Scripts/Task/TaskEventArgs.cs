using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// 任务广播消息
/// </summary>
public class TaskEventArgs : EventArgs
{
    // 当前任务的ID
    public string taskID;
    // 发生事件的对象的ID(例如敌人,商品)
    public string id;
    // 数量
    public int amount;
}
