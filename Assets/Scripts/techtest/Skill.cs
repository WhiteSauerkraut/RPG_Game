using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public Transform set;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(Use());
            Debug.Log(1);
        }
    }
    IEnumerator Use()
    {
        Debug.Log("start");
        GameObject.Find("GlobalManager").GetComponent<ChoosePlayer>().flag = false;
        yield return new WaitUntil(()=>GameObject.Find("GlobalManager").GetComponent<ChoosePlayer>().flag);

        GameObject enemy = GameObject.Find("GlobalManager").GetComponent<ChoosePlayer>().choose;
        GameObject.Find("GlobalManager").GetComponent<ChoosePlayer>().flag = false;
        GameObject player = set.GetChild(0).gameObject;
        Animator a = player.GetComponentInChildren<Animator>();
        Vector3 end = enemy.transform.parent.GetChild(0).position;
        Vector3 from = player.transform.position;

        float tt = 0;
        player.transform.LookAt(end);
        while (player.transform.position != end)
        {
            player.transform.position = Vector3.Lerp(from, end, tt);
            tt += Time.deltaTime;
            a.SetFloat("speed", 5);
            yield return null;
        }
        a.Play("attack1");

        yield return new WaitForSeconds(1);

        player.transform.LookAt(from);
        a.Play("run");
        tt = 0;
        while (player.transform.position != from)
        {
            player.transform.position = Vector3.Lerp(end, from, tt);
            tt += Time.deltaTime;
            a.SetFloat("speed", 5);
            yield return null;
        }
        player.transform.localPosition = Vector3.zero;
        player.transform.localRotation = Quaternion.Euler(Vector3.zero);
        a.SetFloat("speed", 0);
    }
}
