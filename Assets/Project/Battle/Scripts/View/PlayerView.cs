using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerView : MonoBehaviour
{
    [SerializeField] int _playerNumber;
    [SerializeField] PlayerType _playerType;
    [SerializeField] List<Color> _playerColorList;
    [SerializeField] SpriteRenderer _spriteRenderer;

    [NonSerialized] public List<CardEntity> CardList = new List<CardEntity>();
    [NonSerialized] public PlayerEntity PlayerEntity = new PlayerEntity();



}
