using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public sealed class PlayerView : MonoBehaviour
{
    [SerializeField] List<Color> _playerColorList;
    [SerializeField] SpriteRenderer _spriteRenderer;

    [NonSerialized] public PlayerType PlayerType;
    [NonSerialized] public List<CardEntity> CardList = new List<CardEntity>();
    [NonSerialized] public PlayerEntity PlayerEntity = new PlayerEntity();
    [NonSerialized] public LandView CurrentLandView;
    [NonSerialized] public LandView NextLandView;

    private int _playerNumber;

    public int PlayerNumber
    {
        get { return _playerNumber; }
        set
        {
            _playerNumber = value;
            _spriteRenderer.color = _playerColorList[_playerNumber];
        }
    }

    public Vector2 Position { get { return transform.position; } set { transform.position = value; } }

    public async UniTask MoveAsync(int diceValue, CancellationToken token)
    {
        for (int i = 0; i < diceValue; i++)
        {
            var nextLandView = CurrentLandView.NextLandView;
            CurrentLandView = nextLandView;
            Position = nextLandView.Position;

            await UniTask.Delay(1000, cancellationToken: token);
        }
    }
}
