using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTransform : MonoBehaviour
{
    GameObject player;
    GameObject enemy;
    public Transform playerTransform;
    public Transform enemyTransform;
    private void Awake()
    {
        player = GameObject.Find("player");
        enemy = GameObject.Find("boss");
        player.transform.parent = playerTransform;
        player.transform.localPosition = Vector3.zero;
        enemy.transform.parent = enemyTransform;
        enemy.transform.localPosition = Vector3.zero;
        player.transform.GetChild(0).gameObject.SetActive(false);
    }
}
