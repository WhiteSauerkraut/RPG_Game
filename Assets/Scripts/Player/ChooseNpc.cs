using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseNpc : MonoBehaviour
{
    public GameObject chooseNPC;

    private void Update()
    {
        if (chooseNPC != null && Input.GetKeyDown(KeyCode.F))
        {
            this.GetComponent<PlayerAttribute>().state = PlayerState.interact;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (chooseNPC == null && other.gameObject.tag == "NPC")
        {

            chooseNPC = other.gameObject;
            chooseNPC.GetComponentInChildren<cakeslice.Outline>().enabled = true;
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
