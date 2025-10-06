using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Image icon; // assign this to the same Image component
    public Button playButton; // assign this in Inspector
    private Card card;
    private CardSelectionManager selectionManager;

   // [System.Obsolete]
    private void Awake()
    {
        // Find the manager in scene (or assign in Inspector)
        selectionManager = FindFirstObjectByType<CardSelectionManager>();

        if (playButton != null)
        {
            playButton.onClick.AddListener(() =>
            {
                selectionManager.PlaySelectedCard(this);
            });
        }
    }

    public void SetCard(Card newCard, Sprite iconSprite = null)
    {
        card = newCard;

        if (icon != null && iconSprite != null)
            icon.sprite = iconSprite;
    }

    public Card GetCard()
    {
        return card;
    }
}