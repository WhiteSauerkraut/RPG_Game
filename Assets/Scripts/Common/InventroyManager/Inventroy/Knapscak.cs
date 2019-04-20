using UnityEngine;
using System.Collections;

/// <summary>
/// 背包类，继承自存货类Inventroy
/// </summary>
public class Knapscak : Inventroy {
 
    private static Knapscak _instance;
    public static Knapscak Instance {
        get
        {
            if(_instance == null)
                _instance = GameObject.Find("Canvas").transform.Find("MenuUI/Interfaces/Bag_Interface/bagslot").GetComponent<Knapscak>();
            return _instance;
        }
    }

    public override void Start()
    {
        base.Start();
    }

}