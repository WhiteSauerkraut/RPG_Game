using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choose : MonoBehaviour
{
    public void setState(string state)
    {

        if (state == "talk")
            this.transform.parent.gameObject.GetComponent<InteractManager>().interactState = InteractState.talk;
        if (state == "exchange")
            this.transform.parent.gameObject.GetComponent<InteractManager>().interactState = InteractState.exchange;
        if (state == "task")
            this.transform.parent.gameObject.GetComponent<InteractManager>().interactState = InteractState.task;
        if (state == "fight")
            this.transform.parent.gameObject.GetComponent<InteractManager>().interactState = InteractState.fight;
        if (state == "exit")
            this.transform.parent.gameObject.GetComponent<InteractManager>().interactState = InteractState.exit;

    }
}
