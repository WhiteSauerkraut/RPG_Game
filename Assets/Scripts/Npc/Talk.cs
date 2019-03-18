using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void afterTalk();
public class Talk : MonoBehaviour
{
    public string[] TextList;
    public afterTalk AfterTalk;

}
