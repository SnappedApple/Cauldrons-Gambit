using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hand : MonoBehaviour
{
    public List<Card> handCards = new List<Card>();

    // Add a card to the hand
    public void AddCard(Card card)
    {
        handCards.Add(card);
    }

    // Remove a card from the hand
    public void RemoveCard(Card card)
    {
        handCards.Remove(card);
    }
}