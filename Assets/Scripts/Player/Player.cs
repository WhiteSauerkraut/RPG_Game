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
    public BattelProperty M_BattelProperty { get; set; }

    // 角色装备
    public Equipment[] M_Equipments { get; set; }

    // 角色技能
    public Skill[] M_Skills { get; set; }

    // 构造函数初始化
    public Player()
    {
        M_BasicProperty = new BasicProperty();
        M_BattelProperty = new BattelProperty();
        M_Equipments = new Equipment[6];
        M_Skills = new Skill[4];
    }

    // 角色普通攻击
    public void Attack(Player player)
    {

    }

    // 角色释放技能
    public void ReleaseSkill(int index)
    {

    }

    // 角色使用物品
    public void UseItem(Player player)
    {

    }

    // 角色选择防御
    public void Defense()
    {

    }

    // 角色增加技能
    public void AddSkill(Skill skill)
    {
        int i = 0;
        for(; i < M_Skills.Length; i++)
        {
            if(M_Skills[i] == null)
            {
                M_Skills[i] = skill;
            }
        }
        if(i == M_Skills.Length)
        {
            // 执行UI交互，选择替代技能
        }
    }

    // 穿戴装备
    public void WearEquipment(Equipment equipment)
    {

    }

    // 移除装备
    public void RemoveEquipment(Equipment equipment)
    {

    }
}
