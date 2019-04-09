/**
 * 创建日期：3/18
 * 创建人：lyj
 * 描述：组件类——技能类
 **/

public abstract class Skill
{
    // 技能名称
    public string M_Name { get; set; }

    // 技能描述
    public string M_Desription { get; set; }

    // 技能图标
    public string M_IconPath { get; set; }

    // 技能耗蓝
    public int M_ConsumeMp { get; set; }

    // 技能使用
    public abstract void Use(params Player[] players);
    
}
