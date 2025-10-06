using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    public List<Card> possibleCards; // All possible cards
    public GameObject cardPrefab;     // UI prefab for cards

    private Button deckButton;

    void Awake()
    {
        deckButton = GetComponent<Button>();
    }

    // Call this method to set which hand this deck button should draw for
    public void SetupButtonForHand(Hand hand, Transform handParent)
    {
        if (deckButton != null)
        {
            deckButton.onClick.RemoveAllListeners(); // remove old listeners
            deckButton.onClick.AddListener(() => DrawRandomCard(hand));
        }
    }

    // Draw a card for the given hand and parent
    public void DrawRandomCard(Hand hand)
{
    if (possibleCards.Count == 0)
    {
        Debug.LogWarning("No cards available in deck!");
        return;
    }

    // Pick a random card from your ScriptableObject assets
    int randomIndex = Random.Range(0, possibleCards.Count);
    Card drawnCard = possibleCards[randomIndex]; // <-- use the asset directly

    // Add to hand data
    hand.AddCard(drawnCard);

    // UI
    if (hand.handParent != null && hand.cardPrefab != null)
    {
        GameObject cardGO = Instantiate(hand.cardPrefab, hand.handParent);
        CardUI cardUI = cardGO.GetComponent<CardUI>();
        if (cardUI != null)
            cardUI.SetCard(drawnCard, drawnCard.cardSprite); // now it won't be null
    }

    Debug.Log("Player drew card: " + drawnCard.cardName);
}
}