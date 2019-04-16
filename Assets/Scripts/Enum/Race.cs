using System.ComponentModel;
/**
* 创建日期：3/15
* 创建人：lyj
* 描述：枚举类——种族
* */
public enum Race
{
    [Description("道")]
    Tao,

    [Description("魔")]
    Devil,

    [Description("佛")]
    Buddha,

    [Description("人")]
    Human,

    [Description("兽")]
    Orcish,
}