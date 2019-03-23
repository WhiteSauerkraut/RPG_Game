using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseNpc : MonoBehaviour
{
    public GameObject chooseNPC;
    public GameObject interactWindow;
    private void Update()
    {
        if (chooseNPC != null && Input.GetKeyDown(KeyCode.F))
        {
            this.GetComponent<PlayerAttribute>().state = PlayerState.interact;
            interactWindow.transform.Find("ChooseWindow").gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (chooseNPC == null && other.gameObject.tag == "NPC")
        {

            chooseNPC = other.gameObject;
            chooseNPC.transform.GetChild(0).GetComponentInChildren<cakeslice.Outline>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (chooseNPC != null && other.gameObject == chooseNPC)
        {
            chooseNPC.GetComponentInChildren<cakeslice.Outline>().enabled = false;
            chooseNPC = null;
        }
    }
}
