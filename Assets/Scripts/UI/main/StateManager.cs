using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManater : MonoBehaviour
{
    public PlayerAttribute playerAttribute;
    public GameObject UI;
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerAttribute.state)
        {
            case PlayerState.nomal:
                UI.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case PlayerState.interact:
                UI.transform.GetChild(0).gameObject.SetActive(true);
                break;
        }
    }
}
