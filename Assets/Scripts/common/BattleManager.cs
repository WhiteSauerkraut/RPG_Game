/**
 * 创建日期：3/23
 * 创建人：yzy
 * 描述：用于管理战斗系统，战斗方法的集合。单例模式
 **/
public enum BattleState{

}
public class BattleManager
{
    private static BattleManager instance = new BattleManager();
    //私有构造函数
    private BattleManager()
    {
        Init();
    }
    //set get
    public static BattleManager Instance
    {
        get
        {
            return instance;
        }
    }
    //初始化
    public void Init()
    {

    }

    //队友列表
    private Player[] teamates;
    //敌人列表
    private Player[] enemys;
    //队列
    private Player[] que;
    //索引
    private int index;

    //增加队友方法
    public void AddTeamate(string name)
    {

    }
    //增加敌人的方法
    public void AddEnemy(string name )
    {

    }
    //

}