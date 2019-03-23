using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlayer : MonoBehaviour
{
    public GameObject character;
    public GameObject choose;
    public bool flag = false;
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {

            if (hit.transform.tag == "character")
            {
                character = hit.transform.parent.gameObject;
                character.GetComponentInChildren<cakeslice.Outline>().enabled = true;

            }
            if (character != null && character != hit.transform.parent.gameObject)
            {
                if (character != null)
                {
                    character.GetComponentInChildren<cakeslice.Outline>().enabled = false;
                    character = null;
                }
                else
                {
                    character = null;
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            choose = character;
            if (choose != null)
                flag = true;
        }

    }
}
