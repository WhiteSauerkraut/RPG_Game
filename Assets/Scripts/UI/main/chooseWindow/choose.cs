using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choose : MonoBehaviour
{
    public GameObject player;
    public void SetState(string state)
    {

        if (state == "talk")
        {
            player.GetComponent<ChooseNpc>().chooseNPC.GetComponent<InteractEvents>().Talk();
        }

        if (state == "exchange")
        {

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
