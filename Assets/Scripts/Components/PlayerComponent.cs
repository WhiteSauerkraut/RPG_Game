/**
 * 创建日期：3/18
 * 创建人：lyj
 * 描述：角色类
 **/
using UnityEngine;
public class PlayerComponent:MonoBehaviour
{
    public int hp;
    public int atk;
    public string[] skills;
    public string modelUrl;
    public string playerName;
    public void Init(Player player)
    {
        hp = player.atk;
        atk = player.atk;
        skills = player.skills;
        modelUrl = player.modelUrl;
        playerName = player.playerName;

        foreach (string skill in skills)
        {
            UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(this.gameObject, "Assets/Scripts/Player/Player.cs (20,13)", skill);
        }
    }

}
