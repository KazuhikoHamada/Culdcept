using TMPro;
using UnityEngine;

public class CardView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    public void SetText(string text)
    {
        _text.text = text;
    }
}
