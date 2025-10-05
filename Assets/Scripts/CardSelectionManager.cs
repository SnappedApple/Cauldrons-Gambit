using UnityEngine;

public class CardSelectionManager : MonoBehaviour
{
    public Hand playerHand;
    public Player playerStats;
    public Player enemyStats;

    private Card selectedCard;

    public void SelectCard(CardUI cardUI)
    {
        selectedCard = cardUI.GetCard();
        Debug.Log("Selected card: " + selectedCard.cardName);
    }

    public void PlaySelectedCard()
    {
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

        playerHand.RemoveCard(selectedCard);
        selectedCard = null;
    }
}