using UnityEngine;

public enum Turn { Player1, Player2 }

public class TurnManager : MonoBehaviour
{
    public Turn currentTurn = Turn.Player1;

    public Hand player1Hand;
    public Hand player2Hand;
    public HandUIManager handUIManager;

    public Transform cameraPlayer1Position;
    public Transform cameraPlayer2Position;
    public Camera mainCamera;

    public void StartTurn()
    {
        if (currentTurn == Turn.Player1)
        {
            handUIManager.playerHand = player1Hand;
            handUIManager.RefreshHandUI();
            mainCamera.transform.position = cameraPlayer1Position.position;
        }
        else
        {
            handUIManager.playerHand = player2Hand;
            handUIManager.RefreshHandUI();
            mainCamera.transform.position = cameraPlayer2Position.position;
        }
    }

    public void EndTurn()
    {
        currentTurn = currentTurn == Turn.Player1 ? Turn.Player2 : Turn.Player1;
        StartTurn();
    }
}