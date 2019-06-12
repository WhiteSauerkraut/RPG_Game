/**
 * 创建日期：3/18
 * 创建人：lyj
 * 描述：角色类
 **/

public class Player
{
    // 角色基础属性
    public BasicProperty M_BasicProperty { get; set; }

    // 角色战斗属性
    public BattleProperty M_BattleProperty { get; set; }

    // 角色装备
    public string[] M_Equipments { get; set; }

    // 角色技能
    public string[] M_Skills { get; set; }

    // 构造函数初始化
    public Player()
    {
        M_BasicProperty = new BasicProperty();
        M_BattleProperty = new BattleProperty();
        M_Equipments = new string[11];
        M_Skills = new string[4];
    }
}