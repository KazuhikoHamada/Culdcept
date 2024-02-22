using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

public sealed class DealCardView : MonoBehaviour
{
    [Inject] CardInfo _cardInfo;


    [SerializeField] RectTransform _cardsRectTransform;
    [SerializeField] CardView _cardViewPrefab;
    //[SerializeField] int _dealCardCount;

    public bool Visible { get { return gameObject.activeSelf; } set { gameObject.SetActive(value); } }

    private readonly CardType[] CardTypes = { CardType.Fire, CardType.Water, CardType.Soil, CardType.Wind, };
    private readonly CardType[] OtherCardTypes = { CardType.None, CardType.Weapon, CardType.Armor, CardType.Scroll };

    public void DealCard()
    {
        foreach (var cardType in CardTypes)
        {
            var list = _cardInfo.List.Where(n => n.CardType == cardType).ToArray();

            if (list.Count() <= 0)
            {
                Debug.LogError($"CardType:{cardType}");
            }

            var cardEntity = list[Random.Range(0, list.Count())];

            AddCard(cardEntity);
        }

        List<CardEntity> otherCardList = new List<CardEntity>();

        foreach (var cardType in OtherCardTypes)
        {
            otherCardList.AddRange(_cardInfo.List.Where(n => n.CardType == cardType).ToList());
        }

        AddCard(otherCardList[Random.Range(0, otherCardList.Count())]);
    }

    void AddCard(CardEntity cardEntityt)
    {
        var cardView = Instantiate<CardView>(_cardViewPrefab, _cardsRectTransform);
        cardView.SetText(cardEntityt.AbilityName);
    }
}
