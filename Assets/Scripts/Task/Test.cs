using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    public GameObject taskPanel;
    void OnGUI()
    {
        if (GUILayout.Button("接受任务Task1"))
        {
            TaskManager.Instance.GetTask("Task1");
        }

        if (GUILayout.Button("接受任务Task2"))
        {
            TaskManager.Instance.GetTask("Task2");
        }

        if (GUILayout.Button("接受任务Task3"))
        {
            TaskManager.Instance.GetTask("Task3");
        }

        if (GUILayout.Button("打怪Enemy1"))
        {
            TaskEventArgs e = new TaskEventArgs();
            e.id = "Enemy1";
            e.amount = 1;
            MesManager.Instance.Check(e);
        }

        if (GUILayout.Button("打怪Enemy2"))
        {
            TaskEventArgs e = new TaskEventArgs();
            e.id = "Enemy2";
            e.amount = 1;
            MesManager.Instance.Check(e);
        }

        if (GUILayout.Button("获取物体Item1"))
        {
            TaskEventArgs e = new TaskEventArgs();
            e.id = "Item1";
            e.amount = 1;
            MesManager.Instance.Check(e);
        }

        if (GUILayout.Button("获取物体Item2"))
        {
            TaskEventArgs e = new TaskEventArgs();
            e.id = "Item2";
            e.amount = 1;
            MesManager.Instance.Check(e);
        }

        if (GUILayout.Button("丢弃物体Item1"))
        {
            TaskEventArgs e = new TaskEventArgs();
            e.id = "Item1";
            e.amount = -1;
            MesManager.Instance.Check(e);
        }

        if (GUILayout.Button("丢弃物体Item2"))
        {
            TaskEventArgs e = new TaskEventArgs();
            e.id = "Item2";
            e.amount = -1;
            MesManager.Instance.Check(e);
        }

        if (GUILayout.Button("打开任务面板"))
        {
            taskPanel.SetActive(true);
        }

        if (GUILayout.Button("关闭任务面板"))
        {
            taskPanel.SetActive(false);
        }
    }
}
