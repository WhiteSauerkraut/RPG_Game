﻿/**
 * 创建日期：3/15
 * 创建人：lyj
 * 描述：组件类——基础属性
 * */
using UnityEngine;

public class BasicProperty
{
    // 人物头像路径
    public string M_IconPath { get; set; }

    // 人物模型
    public string M_ModelPath { get; set; }

    // 名字
    public string M_Name { get; set; }

    // 性别
    public Sex M_Sex { get; set; }

    // 等级
    public int M_Level { get; set; }

    // 经验
    public int M_Experience { get; set; }

    // 种族
    public Race M_Race { get; set; }

    // 人物位置
    public MyTransform M_Transform;

    public BasicProperty()
    {
        M_Transform = new MyTransform();
    }
}
