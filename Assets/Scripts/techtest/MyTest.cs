using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTest : Skill
{
    public override void Use(params Player[] players)
    {
        // 使用技能对象
        Player sourcePlayer = players[0];
        // 技能使用目标
        Player targetPlayer = players[1];

        // 判断蓝量是否足够
        if(sourcePlayer.M_BattelProperty.M_CurrentMp >= M_ConsumeMp)
        {
            targetPlayer.M_BattelProperty.M_State = State.Normal;
            sourcePlayer.M_BattelProperty.M_CurrentMp -= M_ConsumeMp;
        }
    }
}
