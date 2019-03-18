using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    nomal,
    interact
}
public class PlayerAttribute : MonoBehaviour
{
    public PlayerState state = PlayerState.nomal;
}
