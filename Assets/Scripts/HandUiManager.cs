using UnityEngine;
using UnityEngine.UI;

public class HandUIManager : MonoBehaviour
{
    public Hand playerHand;
    public GameObject cardPrefab;
    public Transform handPanel;

    public void RefreshHandUI()
    {
        foreach (Transform child in handPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (Card card in playerHand.handCards)
        {
            GameObject cardGO = Instantiate(cardPrefab, handPanel);
            CardUI cardUI = cardGO.GetComponent<CardUI>();
            cardUI.SetCard(card);
        }
    }
}