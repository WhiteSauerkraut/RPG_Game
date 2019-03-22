using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    GameObject enemy;
    public Transform set1;
    public Transform set2;
    void Start()
    {
        player = (GameObject)Resources.Load("Prefabs/role");
        enemy = (GameObject)Resources.Load("Prefabs/boss");
        Init(player, set1);
        Init(enemy, set2);
        
    }
    void Init(GameObject _player, Transform set)
    {
        Instantiate(_player,set);
        _player.transform.localPosition = Vector3.zero;
    }
}
