using UnityEngine;
using System.Collections;

/// <summary>
/// 任务奖励物品
/// </summary>
public class TaskReward
{
    // 奖励id
    public string id;
    // 奖励数量
    public int amount = 0;

    public TaskReward(string id, int amount)
    {
        this.id = id;
        this.amount = amount;
    }
}
