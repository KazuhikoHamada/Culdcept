using System;
using System.Collections.Generic;

[Serializable]
public sealed class CardEntity
{
    /// <summary>
    /// 名前
    /// </summary>
    public string Name;
    /// <summary>
    /// カードの種類
    /// </summary>
    public CardType CardType;
    /// <summary>
    /// レア度
    /// </summary>
    public RereType RereType;
    /// <summary>
    /// コスト
    /// </summary>
    public int Cost;
    /// <summary>
    /// 追加コスト
    /// </summary>
    public List<AdditionCostType> AdditionCostTypes;
    /// <summary>
    /// ST
    /// </summary>
    public int St;
    /// <summary>
    /// HP
    /// </summary>
    public int Hp;
    /// <summary>
    /// 配置制限
    /// </summary>
    public List<LimitAttributeType> LimitAttributeTypes;
    /// <summary>
    /// 能力名
    /// </summary>
    public string AbilityName;
}
