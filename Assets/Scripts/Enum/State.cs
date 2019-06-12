using System.ComponentModel;

/**
* 创建日期：3/15
* 创建人：lyj
* 描述：枚举类——人物状态类
* */

public enum State
{
    [Description("正常")]
    Normal,
    [Description("灼伤")]
    Burn,
    [Description("冰冻")]
    Frozen,
    [Description("麻痹")] 
    Paralysis,
    [Description("中毒")]
    Poisoning,
    [Description("睡眠")]
    Sleep,
    [Description("混乱")] 
    Confusion,
    [Description("害怕")] 
    Scared,
    [Description("诅咒")]
    Curse,
    [Description("濒死")]
    SuddenDeath,
    [Description("死亡")]
    Death,
}