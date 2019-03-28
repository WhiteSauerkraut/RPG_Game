using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Z))
        {
            SaveManager.GetInstance().Save();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            SaveManager.GetInstance().Load();
        }
    }
}
