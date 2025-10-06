using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hand : MonoBehaviour
{
    public List<Card> handCards = new List<Card>();
    public Transform handParent;     // Assign in Inspector: UI panel for this hand
    public GameObject cardPrefab;    // Assign in Inspector: card prefab

    // Add a card to the hand
    public void AddCard(Card card)
    {
        if (card == null) return;

        handCards.Add(card);

        // Automatically create card UI
        if (cardPrefab != null && handParent != null)
        {
            GameObject cardGO = Instantiate(cardPrefab, handParent);
            CardUI cardUI = cardGO.GetComponent<CardUI>();
            if (cardUI != null)
                cardUI.SetCard(card, card.cardSprite);
        }
    }

    // Remove a card from the hand
    public void RemoveCard(Card card)
    {
        if (!handCards.Contains(card)) return;

        handCards.Remove(card);

        // Remove the UI element
        foreach (Transform child in handParent)
        {
            CardUI cardUI = child.GetComponent<CardUI>();
            if (cardUI != null && cardUI.GetCard() == card)
            {
                Destroy(child.gameObject);
                break;
            }
        }
    }
}
