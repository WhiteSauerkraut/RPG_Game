using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choose : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SetState(string state)
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (state == "talk")
        {
            player.GetComponent<ChooseNpc>().chooseNPC.GetComponent<InteractEvents>().Talk();
        }

        if (state == "exchange")
        {
            this.gameObject.SetActive(false);
            player.GetComponent<ChooseNpc>().chooseNPC.GetComponent<InteractEvents>().Exchange();
        }

        if (state == "task")
        {

        }

        if (state == "fight")
        {
            player.GetComponent<ChooseNpc>().chooseNPC.GetComponent<InteractEvents>().Fight();
        }

        if (state == "exit")
        {
            this.gameObject.SetActive(false);
            player.GetComponent<PlayerAttribute>().state = PlayerState.nomal;
        }


    }
}
