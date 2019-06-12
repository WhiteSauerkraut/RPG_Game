using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//主场景的人物状态
public enum PlayerState{
    nomal,
    interact,
    fight
}

//人物的状态
public class PlayerAttribute : MonoBehaviour
{
    public PlayerState state = PlayerState.nomal;
}
