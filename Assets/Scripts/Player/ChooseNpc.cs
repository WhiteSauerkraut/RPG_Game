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
        if (chooseNPC != null && Input.GetKeyDown(KeyCode.F))
        {
            this.GetComponent<PlayerAttribute>().state = PlayerState.interact;
            interactWindow.transform.Find("ChooseWindow").gameObject.SetActive(true);
        }
    }
    //当NPC进入触发器时，选择该NPC
    private void OnTriggerEnter(Collider other)
    {

        if (chooseNPC == null && other.gameObject.tag == "NPC")
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
