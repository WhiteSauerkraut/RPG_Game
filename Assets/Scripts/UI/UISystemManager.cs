using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystemManager : MonoBehaviour
{
    public PlayerAttribute playerAttribute;
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerAttribute.state)
        {
            case PlayerState.nomal:
                this.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case PlayerState.interact:
                this.transform.GetChild(0).gameObject.SetActive(true);
                break;
        }
    }
}
