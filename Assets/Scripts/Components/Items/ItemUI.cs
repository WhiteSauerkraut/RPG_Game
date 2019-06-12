using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * 物品脚本类（挂载在每个物体上）
 * */

public class ItemUI : MonoBehaviour
{
    // 物品具体信息
    public ItemDetail ItemDetail { get; private set; }
    // 物品数量
    public int Amount { get; private  set; }
    public int GetAmount()
    {
        return Amount;
    }

    // item的Image组件
    private Image itemImage;
    // item的显示数量的组件
    private Text amountText;
    // 目标缩放大小
    private float targetScale = 1f;
    // 动画缩放设置
    private Vector3 animationScale = new Vector3(1.4f, 1.4f, 1.4f);
    // 动画平滑过渡时间
    private float smothing = 4f;

    void Awake()
    {
        itemImage = this.GetComponent<Image>();
        amountText = this.GetComponentInChildren<Text>();
    }

    void Update()
    {
        // 设置物品缩放动画
        if (this.transform.localScale.x != targetScale)
        {
            float scaleTemp = Mathf.Lerp(this.transform.localScale.x, targetScale, smothing*Time.deltaTime);
            this.transform.localScale = new Vector3(scaleTemp, scaleTemp, scaleTemp);
            if (Mathf.Abs(transform.localScale.x-targetScale) < 0.02f)
            {
                this.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
            }
        }
    }

    /**
     * 更新item的UI显示
     * */
    public void SetItem(ItemDetail item, int amount = 1)
    {
        this.transform.localScale = this.animationScale;

        this.ItemDetail = item;
        this.Amount = amount;
        this.itemImage.sprite = Resources.Load<Sprite>(item.m_IconUrl); 
        if (this.Amount > 1)
        {
            this.amountText.text = Amount.ToString();
        }
        else
        {
            this.amountText.text = "";
        }
    }

    /**
     * 添加Item数量
     * */
    public void AddItemAmount(int num = 1)
    {
        this.transform.localScale = this.animationScale;

        this.Amount += num;
        if (this.Amount> 1)
        {
            this.amountText.text = Amount.ToString();
        }
        else
        {
            this.amountText.text = "";
        }
    }

    /**
     * 设置item数量
     * */
    public void SetAmount(int amount) {
        this.transform.localScale = this.animationScale;
        
        this.Amount = amount;
        if (this.Amount > 1)
        {
            this.amountText.text = Amount.ToString();
        }
        else
        {
            this.amountText.text = "";
        }
    }

    /**
     * 减少物品数量
     * */
    public void RemoveItemAmount(int amount = 1) 
    {
        this.transform.localScale = this.animationScale;

        this.Amount -= amount;
        if (this.Amount > 1)
        {
            this.amountText.text = Amount.ToString();
        }
        else
        {
            this.amountText.text = "";
        }
    }

    /**
     * 显示物品
     * */
    public void Show() {
        gameObject.SetActive(true);
    }

    /**
     * 隐藏物品
     * */
    public void Hide() {
        gameObject.SetActive(false);
    }

    /**
     * 设置物品位置
     * */
    public void SetLocalPosition(Vector3 position)
    {
        this.transform.localPosition = position;
    }

    /**
     * 出入物品交换物品信息
     * */
    public void Exchange(ItemUI itemUI) 
    {
        ItemDetail itemTemp = itemUI.ItemDetail;
        int amountTemp = itemUI.Amount;
        itemUI.SetItem(this.ItemDetail, this.Amount);
        this.SetItem(itemTemp, amountTemp);
    }
}
