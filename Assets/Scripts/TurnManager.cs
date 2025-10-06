using UnityEngine;
using Unity.Cinemachine;

public enum Turn { Player1, Player2 }

public class TurnManager : MonoBehaviour
{
    public Turn currentTurn = Turn.Player1;

    [Header("Cameras")]
   // public CinemachineCamera player1Cam;
   // public CinemachineCamera player2Cam;

    [Header("UI")]
    public HandUIManager player1UI;
    public HandUIManager player2UI;

    [Header("Hands")]
    public Hand player1Hand;
    public Hand player2Hand;
    public GameManager gameManager;

    public void StartTurn()
    {
        Debug.Log("🎯 Starting " + currentTurn + "'s turn");

        if (currentTurn == Turn.Player1)
        {
            //player1Cam.Priority = 10;
           // player2Cam.Priority = 0;

            player1UI.playerHand = player1Hand;
            player1UI.RefreshHand();
        }
        else
        {
          //  player1Cam.Priority = 0;
           // player2Cam.Priority = 10;

            player2UI.playerHand = player2Hand;
            player2UI.RefreshHand();
        }
    }

    public void newTurn()
    {
        Debug.Log("🎯 Starting " + currentTurn + "'s turn");

        if (currentTurn == Turn.Player1)
        {
            gameManager.DrawCards(player1Hand);
            player1UI.playerHand = player1Hand;
            player1UI.RefreshHand();
        }
        else
        {
            gameManager.DrawCards(player2Hand);
            player2UI.playerHand = player2Hand;
            player2UI.RefreshHand();
        }
    }

    public void EndTurn()
    {
        // Switch turns
        currentTurn = (currentTurn == Turn.Player1) ? Turn.Player2 : Turn.Player1;
        Debug.Log("Switching turn to " + currentTurn);
        newTurn();
    }

    void Update()
{
    // Only allow the current player to end their turn
    if (Input.GetKeyDown(KeyCode.Return))
    {
        EndTurn();
    }
}
}