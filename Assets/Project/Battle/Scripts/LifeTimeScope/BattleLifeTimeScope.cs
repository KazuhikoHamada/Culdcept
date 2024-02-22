using UnityEngine;
using VContainer;
using VContainer.Unity;

public class BattleLifeTimeScope : LifetimeScope
{
    [SerializeField] BattleView _battleView;
    [SerializeField] BattlePresenter _battlePresenter;
    [SerializeField] DealCardView _dealCardView;
    [SerializeField] CardInfo _cardInfo;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(_battleView);
        builder.RegisterComponent(_battlePresenter);
        builder.RegisterComponent(_dealCardView);
        builder.RegisterComponent(_cardInfo);
    }
}
