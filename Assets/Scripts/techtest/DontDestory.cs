using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestory : MonoBehaviour
{
    public GameObject[] player;
    public GameObject[] enemy;
    // Start is called before the first frame update
    private void Start()
    {
        foreach( GameObject obj in player)
        {
            DontDestroyOnLoad(obj);
        }
        foreach (GameObject obj in enemy)
        {
            DontDestroyOnLoad(obj);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene(1);
        }
    }
}
