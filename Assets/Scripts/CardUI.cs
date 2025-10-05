using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI effectText;
    public Image icon;

    private Card card;

    public void SetCard(Card newCard)
    {
        card = newCard;
        nameText.text = card.cardName;
        effectText.text = card.effectType != EffectType.None ? card.effectType + " " + card.effectValue : "";
        // Optionally set icon.sprite here if you have card images
    }

    public Card GetCard()
    {
        return card;
    }
}