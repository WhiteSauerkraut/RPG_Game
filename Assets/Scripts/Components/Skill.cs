/**
 * 创建日期：3/18
 * 创建人：lyj
 * 描述：组件类——技能类
 **/

public interface Skill
{
    // 技能名称
    string GetSKillName();

    // 技能描述
    string GetDescription();

    // 技能图标
    string GetIconPath();

    void UseSkill();

    void ChooseGoal();

    void BeforeUseSkill();

    void AfterUseSkill();

    void SetFlag(bool flag);

    bool GetFlag();

}
