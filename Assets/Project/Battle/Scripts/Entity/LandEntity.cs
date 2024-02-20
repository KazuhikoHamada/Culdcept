using System;

[Serializable]
public sealed class LandEntity
{
    /// <summary>
    /// 土地の属性
    /// </summary>
    public AttributeType AttributeType;
    /// <summary>
    /// 価値
    /// </summary>
    public int Value;
    /// <summary>
    /// 通行料
    /// </summary>
    public int Toll;
    /// <summary>
    /// 土地のグループ
    /// </summary>
    public LandGroup LandGroup;
}
