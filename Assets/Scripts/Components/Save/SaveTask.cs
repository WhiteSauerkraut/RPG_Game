using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 任务存储组件
/// </summary>

public class SaveTask
{
    // 任务ID
    public string taskID;
    // 任务名字
    public string taskName;
    // 任务描述   
    public string caption;
    public List<TaskCondition> taskConditions;
    public List<TaskReward> taskRewards;

    public SaveTask(string taskID, string taskName, string caption, List<TaskCondition> taskConditions, List<TaskReward> taskRewards)
    {
        this.taskID = taskID;
        this.taskName = taskName;
        this.taskConditions = taskConditions;
        this.taskRewards = taskRewards;
    }
}
