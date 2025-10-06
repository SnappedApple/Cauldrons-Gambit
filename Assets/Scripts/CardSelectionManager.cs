using UnityEngine;

public class CardSelectionManager : MonoBehaviour
{
    public Hand playerHand;
    public HandUIManager player1UI;
    public HandUIManager player2UI;
    public Player playerStats;
    public Player enemyStats;
    public PotionCombiner combiner;

    private Card firstSelectedCard;
    private Card secondSelectedCard;
    private CardUI firstSelectedUI; // track which UI element was clicked

    void Update()
    {
        // Deselect first card with Backspace
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (firstSelectedCard != null)
            {
                Debug.Log("Deselected card: " + firstSelectedCard.cardName);
                firstSelectedCard = null;
                firstSelectedUI = null;
            }
        }
    }

    public void SelectCard(CardUI cardUI)
    {
        Card clickedCard = cardUI.GetCard();
        Debug.Log("Clicked card: " + clickedCard.cardName);

        // Prevent selecting the same UI element twice
        if (firstSelectedUI == cardUI)
        {
            Debug.Log("Cannot select the same card UI twice.");
            return;
        }

        if (firstSelectedCard == null)
        {
            firstSelectedCard = clickedCard;
            firstSelectedUI = cardUI;
            Debug.Log("First card selected: " + firstSelectedCard.cardName);
            return;
        }

        // Second card selection
        secondSelectedCard = clickedCard;
        Debug.Log("Second card selected: " + secondSelectedCard.cardName);

        TryCombine();
    }

    void TryCombine()
    {
        if (combiner == null)
        {
            Debug.LogError("PotionCombiner is not assigned!");
            return;
        }

        if (firstSelectedCard == null || secondSelectedCard == null)
        {
            Debug.LogWarning("Cannot combine: one of the selected cards is null.");
            return;
        }

        Card result = combiner.CombineIngredients(firstSelectedCard, secondSelectedCard);

        if (result != null)
        {
            Debug.Log("Potion created: " + result.potionType + " level " + result.potionLevel);

            playerHand.RemoveCard(firstSelectedCard);
            playerHand.RemoveCard(secondSelectedCard);

            playerHand.AddCard(result);

            player1UI.RefreshHand();
            player2UI.RefreshHand();
        }
        else
        {
            Debug.Log("Cannot combine these two cards!");
        }

        firstSelectedCard = null;
        secondSelectedCard = null;
    }

  //  [System.Obsolete]
    public void PlaySelectedCard(CardUI cardUI)
    {
        Card selectedCard = cardUI.GetCard();
        if (selectedCard == null) return;

        switch (selectedCard.effectType)
        {
            case EffectType.Attack:
                enemyStats.TakeDamage(selectedCard.effectValue);
                break;
            case EffectType.Heal:
                playerStats.Heal(selectedCard.effectValue);
                break;
            case EffectType.Shield:
                playerStats.AddShield(selectedCard.effectValue);
                break;
        }

        // Remove card from hand
        playerHand.RemoveCard(selectedCard);
        player1UI.RefreshHand();
        player2UI.RefreshHand();

        // Check if someone lost
        FindFirstObjectByType<GameManager>().CheckGameOver();

        // End turn automatically
        FindFirstObjectByType<TurnManager>().EndTurn();
    }
}