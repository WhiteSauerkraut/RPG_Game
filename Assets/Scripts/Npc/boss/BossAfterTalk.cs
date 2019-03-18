using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAfterTalk : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<Talk>().AfterTalk = AfterTalk;
    }

    private void AfterTalk()
    {
        Debug.Log("After Talk!");
    }
}
