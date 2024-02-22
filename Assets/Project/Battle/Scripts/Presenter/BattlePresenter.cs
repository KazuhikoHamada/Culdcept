using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using System.Linq;
using R3;

public class BattlePresenter : MonoBehaviour
{
    [Inject] readonly BattleView _battleView;
    [Inject] readonly DealCardView _dealCardView;

    void Start()
    {
        _battleView.OnDealCard.Subscribe(n => 
        {
            _dealCardView.Visible = true;
            _dealCardView.DealCard();
        }).AddTo(this);
    }
}
