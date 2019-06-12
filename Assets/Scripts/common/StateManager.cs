using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public GameObject player;
    public GameObject UI;

    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("Canvas");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (player.GetComponent<PlayerAttribute>().state)
        {
            case PlayerState.nomal:
                UI.transform.GetChild(0).gameObject.SetActive(false);
                player.transform.GetChild(0).GetChild(0).gameObject.GetComponent<CameraFollow>().enabled = true;
                break;
            case PlayerState.interact:
                UI.transform.GetChild(0).gameObject.SetActive(true);
                player.transform.GetChild(0).GetChild(0).LookAt(player.GetComponent<ChooseNpc>().chooseNPC.transform);
                player.transform.GetChild(0).GetChild(0).gameObject.GetComponent<CameraFollow>().enabled = false;
                break;
        }
    }
}
