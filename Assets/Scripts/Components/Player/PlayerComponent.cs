/**
 * 创建日期：3/18
 * 创建人：lyj
 * 描述：角色类
 **/
using UnityEngine;
public class PlayerComponent:MonoBehaviour
{
    public BasicProperty M_BasicProperty { get; set; }

    public BattelProperty M_BattelProperty { get; set; }

    public Equipment[] M_Equipments { get; set; }

    public string[] M_Skills { get; set; }

    public void Init(Player player)
    {
        M_BasicProperty = player.M_BasicProperty;
        M_BattelProperty = player.M_BattelProperty;
        M_Equipments = player.M_Equipments;
        M_Skills = player.M_Skills;
        
        foreach (string skill in M_Skills)
        {
            UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(this.gameObject, "Assets/Scripts/Player/Player.cs (20,13)", skill);
        }
    }
    public Camp camp;

    public void beDamaged(int damage)
    {
        M_BattelProperty.M_CurrentHp -= damage;
    }
}
