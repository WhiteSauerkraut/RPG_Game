using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 任务列表面板类
/// </summary>
public class TaskPanel : MonoSingletion<TaskPanel> {
    // id,taskItem
    public Dictionary<string, TaskItem> dictionary = new Dictionary<string, TaskItem>();
    // 内容
    GameObject content;
    // 列表项
    Object item;
    
    void Start()
    {
        content = transform.Find("Viewport/Content").gameObject;
        item = Resources.Load("Prefabs/task/task_item", typeof(GameObject)); ;
        
        TaskManager.Instance.getEvent += AddItem;
        TaskManager.Instance.rewardEvent += RemoveItem;
        TaskManager.Instance.cancelEvent += RemoveItem;
    }

    /**
     * 添加列表项
     * */
    public void AddItem(System.Object sender, TaskEventArgs e)
    {
        GameObject a = Instantiate(item) as GameObject;
        a.transform.SetParent(content.transform);
        TaskItem t = a.GetComponent<TaskItem>();
        dictionary.Add(e.taskID,t);
        t.Init(e);
    }

    /**
     * 移除列表项
     * */
    public void RemoveItem(System.Object sender, TaskEventArgs e)
    {
        if (dictionary.ContainsKey(e.taskID))
        {
            TaskItem t = dictionary[e.taskID];
            dictionary.Remove(e.taskID);
            Destroy(t.gameObject);
        }      
    }
}
