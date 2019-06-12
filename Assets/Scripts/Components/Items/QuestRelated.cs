using UnityEngine;
using System.Collections;

/// <summary>
/// 任务物品类，直接继承自ItemDetail基类即可
/// </summary>
public class QuestRelated : ItemDetail {
    public QuestRelated(int id, string name, ItemType type, ItemQuality quality, string description, int capaticy, int buyPrice, int sellPrice, string sprite) 
        : base(id, name, type, quality, description, capaticy, buyPrice, sellPrice, sprite)
    {

    }
}
