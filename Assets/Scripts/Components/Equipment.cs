/**
 * 创建日期：3/15
 * 创建人：lyj
 * 描述：组件类——装备类，继承自物品类
 **/

public class Equipment : Item
{
    // 装备部位
    public EquipmentPart M_EquipmentPart { get; set; }

    // 装备品级
    public EquipmentGrade M_EquipmentGrade { get; set; }

    // 装备稀有度
    public EquipmentRarity M_EquipmentRarity { get; set; }

    // Hp加成
    public int M_Add_Hp { get; set; }

    // Mp加成
    public int M_Add_Mp { get; set; }

    // 物攻加成
    public int M_Add_Atk { get; set; }

    // 法攻加成
    public int M_Add_Mgk { get; set; }

    // 物防加成
    public int M_Add_Def { get; set; }

    // 法防加成
    public int M_Add_Rgs { get; set; }

    // 速度加成
    public int M_Add_Spd { get; set; }

}
