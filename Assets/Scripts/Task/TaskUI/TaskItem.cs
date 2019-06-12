using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// 任务UI类
/// </summary>
public class TaskItem : MonoBehaviour
{
    // 对应的任务逻辑
    public Task task;
    // 任务名称
    public Text taskName;
    // 按钮，点击后显示具体任务信息
    Button btn_show;
    // 记录任务是否完成
    public string str_isFinish = "未完成";

    GameObject process;
    public List<TaskItemProcess> processText = new List<TaskItemProcess>();

    GameObject reward;
    public List<TaskItemReward> rewardText = new List<TaskItemReward>();

    public void Init(TaskEventArgs e)
    {
        task = TaskManager.Instance.dictionary[e.taskID];
        task.taskItem = this;
        taskName.text = task.taskName;

        btn_show = GetComponent<Button>();
        btn_show.onClick.AddListener(Show);
    }

    /**
     * 点击任务项，显示任务描述
     * */
    public void Show()
    {
        GameObject task_dec = GameObject.FindGameObjectWithTag("Task_Interface").transform.Find("Task_description").gameObject;
        task_dec.SetActive(true);
        GameObject process_list = task_dec.transform.Find("process_list/Viewport/Content").gameObject;
        GameObject reward_list = task_dec.transform.Find("reward_list/Viewport/Content").gameObject;
        Text text_dec = task_dec.transform.Find("text_description").gameObject.GetComponent<Text>();
        Text text_QuitTask = task_dec.transform.Find("btn_isFinish").gameObject.GetComponentInChildren<Text>();
        Button btn_quitTask = task_dec.transform.Find("btn_quitTask").GetComponent<Button>();
        Button btn_isFinish = task_dec.transform.Find("btn_isFinish").GetComponent<Button>();

        btn_quitTask.onClick.AddListener(Cancel);
        btn_isFinish.onClick.AddListener(Reward);

        text_dec.text = task.caption;
        text_QuitTask.text = str_isFinish;

        process = Resources.Load("Prefabs/task/Process") as GameObject;
        reward = Resources.Load("Prefabs/task/Reward") as GameObject;

        int len1 = process_list.transform.childCount, len2 = reward_list.transform.childCount;
        // 清除进度、奖励显示信息
        for (int i = 0; i < len1; i++)
        {
            DestroyImmediate(process_list.transform.GetChild(0).gameObject, true);
        }
        for (int i = 0; i < len2; i++)
        {
            DestroyImmediate(reward_list.transform.GetChild(0).gameObject, true);
        }

        // 增加进度信息
        for (int i = 0; i < task.taskConditions.Count; i++)
        {
            GameObject a = Instantiate(process) as GameObject;
            a.transform.SetParent(process_list.transform);

            TaskItemProcess tP = a.GetComponent<TaskItemProcess>();
            processText.Add(tP);

            tP.id = task.taskConditions[i].id;
            tP.now = task.taskConditions[i].nowAmount.ToString();
            tP.target = task.taskConditions[i].targetAmount.ToString();

            Text id = a.transform.Find("ID").GetComponent<Text>();
            Text now = a.transform.Find("Now").GetComponent<Text>();
            Text Target = a.transform.Find("Target").GetComponent<Text>();
            id.text = tP.id;
            now.text = tP.now;
            Target.text = tP.target;
        }

        // 增加奖励信息
        for (int i = 0; i < task.taskRewards.Count; i++)
        {
            GameObject a = Instantiate(reward) as GameObject;
            a.transform.SetParent(reward_list.transform);
            
            TaskItemReward tR = a.GetComponent<TaskItemReward>();
            rewardText.Add(tR);

            tR.id = task.taskRewards[i].id;
            tR.amount = task.taskRewards[i].amount.ToString();
            Text id = a.transform.Find("ID").GetComponent<Text>();
            Text Amount = a.transform.Find("Amount").GetComponent<Text>();
            id.text = tR.id;
            Amount.text = tR.amount;
        }
    }

    /**
     * 删除任务项后，隐藏任务描述信息
     * */
    public void Hide()
    {
        GameObject task_dec = GameObject.FindGameObjectWithTag("Task_Interface").transform.Find("Task_description").gameObject;
        task_dec.SetActive(false);
    }

    /**
     * 修改条件的当前进度
     * */
    public void Modify(string id,int amount)
    {
        for (int i = 0; i < processText.Count; i++)
        {
            if (processText[i].id == id)
                processText[i].now = amount.ToString();
        }
        Show();
    }

    public void Finish(bool isFinish)
    {
        if (isFinish)
            str_isFinish = "完成了";
        else
            str_isFinish = "未完成";
        Show();
    }

    public void Reward()
    {
        if (str_isFinish == "完成了")
        {
            task.Reward();
            Hide();
        }   
    }

    public void Cancel()
    {
        task.Cancel();
        Hide();
    }
}
