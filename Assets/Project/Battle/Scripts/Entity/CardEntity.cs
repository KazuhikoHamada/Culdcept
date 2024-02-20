using System;

[Serializable]
public sealed class CardEntity
{
    /// <summary>
    /// 名前
    /// </summary>
    public string Name;
    /// <summary>
    /// 土地の属性
    /// </summary>
    public AttributeType AttributeType;
    /// <summary>
    /// レア度
    /// </summary>
    public RereType RereType;
    /// <summary>
    /// コスト
    /// </summary>
    public int Cost;
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
    public AttributeType LimitAttributeType;
    /// <summary>
    /// 能力名
    /// </summary>
    public string AbilityName;
}
