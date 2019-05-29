using UnityEngine;
using System.Collections;
using System;

public class MesManager : MonoSingletion<MesManager> {

    public event EventHandler<TaskEventArgs> checkEvent;

    // 引发消息检查事件
    public void Check(TaskEventArgs e)
    {
        checkEvent(this,e);
    }
}
