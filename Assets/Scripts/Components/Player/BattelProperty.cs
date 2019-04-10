/**
 * 创建日期：3/15
 * 创建人：lyj
 * 描述：组件类——战斗属性
 **/

public class BattelProperty
{
    
    // 当前生命值
    public int M_CurrentHp { get; set; }

    // 当前法力值
    public int M_CurrentMp { get; set; }

    // 最大生命值
    public int M_MaxHp { get; set; }

    // 最大法力值
    public int M_MaxMp { get; set; }

    // 物理攻击力
    public int M_Atk { get; set; }

    // 物理防御力
    public int M_Def { get; set; }

    // 法术攻击力
    public int M_Mgk { get; set; }

    // 法术防御力
    public int M_Rgs { get; set; }

    // 速度
    public int M_Spd { get; set; }

    // 状态
    public State M_State { get; set; }

}
