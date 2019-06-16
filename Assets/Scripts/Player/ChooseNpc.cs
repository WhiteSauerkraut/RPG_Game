using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseNpc : MonoBehaviour
{

    public GameObject chooseNPC;
    public GameObject interactWindow;

    void Start()
    {
        interactWindow = GameObject.FindGameObjectWithTag("Canvas").transform.Find("InteractSystem").gameObject;
    }

    private void Update()
    {
        //当触发器选择到NPC时，按F与NPC交互
        if (chooseNPC != null && Input.GetKeyDown(KeyCode.F) && chooseNPC.gameObject.tag == "NPC")
        {
            this.GetComponent<PlayerAttribute>().state = PlayerState.interact;
            interactWindow.transform.Find("ChooseWindow").gameObject.SetActive(true);
        }
        else if(chooseNPC != null && Input.GetKeyDown(KeyCode.F) && chooseNPC.gameObject.tag == "MyNPC")
        {
            this.GetComponent<PlayerAttribute>().state = PlayerState.interact;
            if(chooseNPC.GetComponent<ItemShopper>() != null)
            {
                chooseNPC.GetComponent<ItemShopper>().Talk();
            }
            else if(chooseNPC.GetComponent<GuideDZ>() != null)
            {
                chooseNPC.GetComponent<GuideDZ>().Talk();
            }
            else if (chooseNPC.GetComponent<GiveWq>() != null)
            {
                chooseNPC.GetComponent<GiveWq>().Talk();
            }
            else if (chooseNPC.GetComponent<TaskWoman>() != null)
            {
                chooseNPC.GetComponent<TaskWoman>().Talk();
            }
            else if (chooseNPC.GetComponent<FightMan>() != null)
            {
                chooseNPC.GetComponent<FightMan>().Talk();
            }
            else if (chooseNPC.GetComponent<ladyTalk>() != null)
            {
                chooseNPC.GetComponent<ladyTalk>().Talk();
            }
        }
    }
    //当NPC进入触发器时，选择该NPC
    private void OnTriggerEnter(Collider other)
    {

        if (chooseNPC == null && (other.gameObject.tag == "NPC" || other.gameObject.tag == "MyNPC"))
        {

            chooseNPC = other.gameObject;
            chooseNPC.transform.GetChild(0).GetComponentInChildren<cakeslice.Outline>().enabled = true;
        }
    }
    //当NPC离开触发器时，将chooseNPC置为空
    private void OnTriggerExit(Collider other)
    {
        if (chooseNPC != null && other.gameObject == chooseNPC)
        {
            chooseNPC.GetComponentInChildren<cakeslice.Outline>().enabled = false;
            chooseNPC = null;
        }
    }
}
