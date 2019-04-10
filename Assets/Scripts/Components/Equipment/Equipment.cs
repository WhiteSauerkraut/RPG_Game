/**
 * 创建日期：3/15
 * 创建人：lyj
 * 描述：组件类——装备类，继承自物品类
 **/

public class Equipment : Item
{
    // 装备部位
    public EquipmentPart M_EquipmentPart { get; set; }

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

    /**
     * 装备的装备方法
     */
    public override void Use()
    {
        Player player = new Player();

        /**
         * 卸下已穿戴的装备
         */
        if(player.M_Equipments[(int)M_EquipmentPart] != null)
        {
            player.M_Equipments[(int)M_EquipmentPart].Remove();
        }

        SetPlayerProperty(player, 1);
    }

    /**
     * 装备的卸下方法
     */
    public void Remove()
    {
        Player player = new Player();

        SetPlayerProperty(player, -1);
    }

    /**
     * 装备属性设置方法
     */
    private void SetPlayerProperty(Player player, int opertation)
    {
        player.M_BattelProperty.M_MaxHp += M_Add_Hp * opertation;
        player.M_BattelProperty.M_MaxMp += M_Add_Mp * opertation;
        player.M_BattelProperty.M_CurrentHp += M_Add_Mp * opertation;
        player.M_BattelProperty.M_CurrentMp += M_Add_Mp * opertation;
        player.M_BattelProperty.M_Atk += M_Add_Atk * opertation;
        player.M_BattelProperty.M_Def += M_Add_Def * opertation;
        player.M_BattelProperty.M_Mgk += M_Add_Mgk * opertation;
        player.M_BattelProperty.M_Rgs += M_Add_Rgs * opertation;
        player.M_BattelProperty.M_Spd += M_Add_Spd * opertation;
    }
}
