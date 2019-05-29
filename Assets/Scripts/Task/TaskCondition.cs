using System.Collections;
using System;

public class TaskCondition
{
    // 条件id
    public string id;
    // 当前进度
    public int nowAmount;
    // 目标进度
    public int targetAmount;
    // 记录是否满足条件
    public bool isFinish = false;

    public TaskCondition(string id, int nowAmount, int targetAmount)
    {
        this.id = id;
        this.nowAmount = nowAmount;
        this.targetAmount = targetAmount;
    }
}
