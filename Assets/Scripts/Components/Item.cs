/**
 * 创建日期：3/20
 * 创建人：lyj
 * 描述：组件类——物品超类
 **/

public abstract class Item
{
    // 名称
    public string M_Name { get; set; }

    // 描述
    public string M_Desription { get; set; }

    // 图标路径
    public string M_IconPath { get; set; }

    // 出售价格
    public string M_Price { get; set; }

    /**
     * 物品使用虚方法
     */
    //public abstract void Use();
}
