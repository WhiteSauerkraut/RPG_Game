using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCanvasManager : MonoBehaviour
{
    BattleState battleState;
    private void Start()
    {
        battleState = GameObject.Find("GM").GetComponent<BattleManager>().battleState;
        int n = this.transform.childCount;
        for (int i=0; i<n; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
        StartCoroutine(Prepare());
    }
    IEnumerator Prepare()
    {
        this.transform.GetChild(0).gameObject.SetActive(true); 
        yield return new WaitForSeconds(2);
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(true);
    }
    private void Update()
    {

    }

}
