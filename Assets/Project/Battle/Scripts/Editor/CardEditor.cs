using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

[CustomEditor(typeof(CardInfo))]
public class CardEditor : Editor
{
    const string SheetId = "1yJKamoBnqjUXLyYroL0e5MW3TAFyKnFOcvQ8BAJAq-0";
    const string SheetName = "Card";
    const string Url = "https://docs.google.com/spreadsheets/d/" + SheetId + "/gviz/tq?tqx=out:csv&sheet=" + SheetName;

    bool _isLoad = false;

    public override void OnInspectorGUI()
    {
        if (!_isLoad && GUILayout.Button("更新"))
        {
            SendWebRequest().Forget();
        }

        base.OnInspectorGUI();
    }


    async UniTask SendWebRequest()
    {
        _isLoad = true;

        using (UnityWebRequest req = UnityWebRequest.Get(Url)) //UnityWebRequest型オブジェクト
        {
            var response = await req.SendWebRequest(); //URLにリクエストを送る

            if (response.isDone) //成功した場合
            {
                //Debug.Log( response.downloadHandler.text);

                UpdateCardData((CardInfo)target, response.downloadHandler.text);
            }
            else                            //失敗した場合
            {
                Debug.Log("error");
            }
        }

        _isLoad = false;
    }


    void UpdateCardData(CardInfo card, string data)
    {
        string[] rows = data.Split(new[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);

        List<CardEntity> list = new List<CardEntity>();

        int rowIndex = 1;

        foreach (string row in rows)
        {
            if (rowIndex++ == 1) continue;

            int cellIndex = 0;
            string[] cells = row.Split(new[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);//一行ずつの情報を1セルずつ配列に格納

            var cardEntity = new CardEntity();
            cardEntity.Name = $"{rowIndex}";

            foreach (string cell in cells)
            {
                string trimCell = cell.Trim('"'); //セルの文字列からダブルクォーテーションを除去

                switch (cellIndex)
                {
                    case 0:
                        cardEntity.DisplayName = trimCell;
                        break;
                    case 1:
                        switch (trimCell)
                        {
                            case "無":
                                cardEntity.CardType = CardType.None;
                                break;
                            case "火":
                                cardEntity.CardType = CardType.Fire;
                                break;
                            case "水":
                                cardEntity.CardType = CardType.Water;
                                break;
                            case "地":
                                cardEntity.CardType = CardType.Soil;
                                break;
                            case "風":
                                cardEntity.CardType = CardType.Wind;
                                break;
                            case "巻":
                                cardEntity.CardType = CardType.Scroll;
                                break;
                            case "道":
                                cardEntity.CardType = CardType.Tool;
                                break;
                            case "武":
                                cardEntity.CardType = CardType.Weapon;
                                break;
                            case "防":
                                cardEntity.CardType = CardType.Armor;
                                break;
                            default:
                                cardEntity = null;
                                break;
                        }
                        break;
                    case 2:
                        switch (trimCell)
                        {
                            case "N":
                                cardEntity.RereType = RereType.N;
                                break;
                            case "R":
                                cardEntity.RereType = RereType.R;
                                break;
                            case "S":
                                cardEntity.RereType = RereType.S;
                                break;
                            case "E":
                                cardEntity.RereType = RereType.E;
                                break;
                            default:
                                cardEntity = null;
                                break;
                        }
                        break;
                    case 3:
                        cardEntity.Cost = int.Parse(trimCell);
                        break;
                    case 4:
                        if (!string.IsNullOrWhiteSpace(trimCell))
                        {
                            List<string> strings = new List<string>();
                            for (int i = 0; i < trimCell.Length; i++)
                            {
                                strings.Add(trimCell.Substring(i, 1));
                            }
                            List<AdditionCostType> additionCostTypeList = new List<AdditionCostType>();
                            foreach (string s in strings)
                            {
                                switch (s)
                                {
                                    case "火":
                                        additionCostTypeList.Add(AdditionCostType.Fire);
                                        break;
                                    case "水":
                                        additionCostTypeList.Add(AdditionCostType.Water);
                                        break;
                                    case "地":
                                        additionCostTypeList.Add(AdditionCostType.Soil);
                                        break;
                                    case "風":
                                        additionCostTypeList.Add(AdditionCostType.Wind);
                                        break;
                                    case "C":
                                        additionCostTypeList.Add(AdditionCostType.Card);
                                        break;
                                }
                            }
                            cardEntity.AdditionCostTypes = additionCostTypeList;
                        }
                        break;
                    case 5:
                        cardEntity.St = string.IsNullOrWhiteSpace(trimCell) ? 0 : int.Parse(trimCell);
                        break;
                    case 6:
                        cardEntity.Hp = string.IsNullOrWhiteSpace(trimCell) ? 0 : int.Parse(trimCell);
                        break;
                    case 7:
                        if (!string.IsNullOrWhiteSpace(trimCell))
                        {
                            List<string> strings = new List<string>();
                            for (int i = 0; i < trimCell.Length; i++)
                            {
                                strings.Add(trimCell.Substring(i, 1));
                            }
                            List<LimitAttributeType> limitAttributeTypes = new List<LimitAttributeType>();
                            foreach (string s in strings)
                            {
                                switch (s)
                                {
                                    case "火":
                                        limitAttributeTypes.Add(LimitAttributeType.Fire);
                                        break;
                                    case "水":
                                        limitAttributeTypes.Add(LimitAttributeType.Water);
                                        break;
                                    case "土":
                                        limitAttributeTypes.Add(LimitAttributeType.Soil);
                                        break;
                                    case "風":
                                        limitAttributeTypes.Add(LimitAttributeType.Wind);
                                        break;
                                }
                            }
                            cardEntity.LimitAttributeTypes = limitAttributeTypes;
                        }
                        break;
                    case 9:
                        cardEntity.AbilityName = trimCell;
                        break;
                }

                if (cardEntity == null) break;

                cellIndex++;
            }

            if (cardEntity != null)
            {
                list.Add(cardEntity);
            }
        }

        card.List = list;

        EditorUtility.SetDirty(card);
        AssetDatabase.SaveAssets();
    }
}
