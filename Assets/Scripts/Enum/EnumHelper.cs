using System;
using System.ComponentModel;
using System.Reflection;

/**
* 创建日期：4/16
* 创建人：lyj
* 描述：枚举工具类
* */
public class EnumHelper
{
    /**
     * 获取枚举属性的中文描述符
     * */
    public static string GetEnumDescription(Enum enumValue)
    {
        string value = enumValue.ToString();
        FieldInfo field = enumValue.GetType().GetField(value);
        object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (objs == null || objs.Length == 0)
            return value;
        DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
        return descriptionAttribute.Description;
    }
}
