using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DeckManager deck;
    public Hand player1Hand, player2Hand;
    public Player player1Stats, player2Stats;
    public int turnCount = 0;
    public int maxTurnsBeforeBattle = 5;

    void Start()
    {
        deck.Shuffle();
        StartTurn();
    }

    void StartTurn()
    {
        turnCount++;
        DrawCards(player1Hand);
        DrawCards(player2Hand);

        if(turnCount >= maxTurnsBeforeBattle)
        {
            BattlePhase();
            turnCount = 0;
        }
    }

    void DrawCards(Hand hand)
    {
        for(int i=0; i<1; i++) // 1 card per turn
        {
            Card c = deck.DrawCard();
            if(c != null) hand.AddCard(c);
        }
    }

    void BattlePhase()
    {
        Debug.Log("Battle phase! Apply potions from hands.");
        // Implement turn-based or simultaneous application of potions here
    }
}