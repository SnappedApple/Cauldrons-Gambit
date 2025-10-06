using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DeckManager deck;
    public TurnManager turnManager;

    [Header("Players")]
    public Hand player1Hand;
    public Hand player2Hand;

    public Player player1;
    public Player player2;

    [Header("Turn Settings")]
    public int turnCount = 0;
    public int maxTurnsBeforeBattle = 5;

    void Start()
    {
        Debug.Log("Starting game!");
        StartTurn();
    }

    public void StartTurn()
    {
        turnCount++;

        deck.SetupButtonForHand(player1Hand, player1Hand.handParent);
        deck.SetupButtonForHand(player2Hand, player2Hand.handParent);

        DrawCards(player1Hand);

        turnManager.StartTurn(); // delegate to TurnManager
    }

    public void DrawCards(Hand hand)
    {
        deck.DrawRandomCard(hand);
    }

    public void CheckGameOver()
    {
        if (player1.currentHealth <= 0)
        {
            Debug.Log("Player 2 wins!");
        }
        else if (player2.currentHealth <= 0)
        {
            Debug.Log("Player 1 wins!");
        }
    }

    
}