using System;
using UnityEngine;

[Serializable]
public sealed class LandSpriteView
{
    [SerializeField] LandType _landType;
    [SerializeField] Sprite _sprite;

    public LandType LandType => _landType;
    public Sprite Sprite => _sprite;
}
