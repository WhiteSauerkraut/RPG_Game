/**
 * 创建日期：3/15
 * 创建人：lyj
 * 描述：组件类——战斗属性
 **/

public class BattleProperty
{
    // 当前生命值
    private int m_CurrentHp;
    public int M_CurrentHp
    {
        get { return m_CurrentHp; }
        set
        {
            if(value >= 0)
            {
                m_CurrentHp = value > M_MaxHp ? M_MaxHp : value;
            }
            else
            {
                m_CurrentHp = 0;
            }
        }
    }

    // 当前法力值
    private int m_currentMp;
    public int M_CurrentMp
    {
        get { return m_currentMp; }
        set
        {
            if (value >= 0)
            {
                m_currentMp = value > M_MaxMp ? M_MaxMp : value;
            }
            else
            {
                m_currentMp = 0;
            }
        }
    }

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
