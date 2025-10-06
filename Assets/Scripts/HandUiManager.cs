using UnityEngine;
using UnityEngine.UI;

public class HandUIManager : MonoBehaviour
{
    public Hand playerHand;
    public GameObject cardPrefab;
    public Transform handPanel;
    public CardSelectionManager selectionManager;

    public CardSpriteManager spriteManager;

    public void RefreshHand()
    {
        Debug.Log("Refreshing hand: " + playerHand.handCards.Count + " cards"); // <-- check how many cards are in the hand
        // Clear existing UI
        foreach (Transform child in handPanel)
            Destroy(child.gameObject);

        // Recreate cards visually
        foreach (Card card in playerHand.handCards)
        {
            Debug.Log("Instantiating card: " + card.cardName); // <-- see which card is being added
            GameObject cardObj = Instantiate(cardPrefab, handPanel);
            CardUI cardUI = cardObj.GetComponent<CardUI>();
            cardUI.SetCard(card, card.cardSprite); 

            // Optional: hook up click events
            Button cardButton = cardObj.GetComponent<Button>();
            if (cardButton != null)
            {
                cardButton.onClick.AddListener(() =>
                    selectionManager.SelectCard(cardUI));
            }
        }
    }
}