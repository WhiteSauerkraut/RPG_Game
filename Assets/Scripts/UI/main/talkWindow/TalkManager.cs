using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public delegate void Next();
public class TalkManager : MonoBehaviour
{
    public string[] texts;
    public int index = 0;
    public GameObject player;

    public Next next;
    public void Show(string[] texts,Next next)
    {
        index = 0;
        this.next = next;
        this.texts = texts;
        this.transform.GetChild(0).gameObject.GetComponent<Text>().text = texts[index];
        this.gameObject.SetActive(true);
    }

    void Close()
    {
        index = 0;
        this.next = null;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (index < texts.Length)
            this.transform.GetChild(0).gameObject.GetComponent<Text>().text = texts[index];
        if (Input.GetKeyDown(KeyCode.F)){
            index++;
        }
        if (index < texts.Length-1)
        {
            //show button as next
            this.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "NEXT";
        }
        else if (index == texts.Length-1)
        {
            //show button as finsh
            this.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "FINISH";
        }
        else
        {
            next();
            Close();
        }

    }
    public void AddIndex()
    {
        index++;
    }
}
