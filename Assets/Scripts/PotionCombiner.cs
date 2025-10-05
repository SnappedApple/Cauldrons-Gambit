using System.Collections.Generic;
using UnityEngine;

public class PotionCombiner : MonoBehaviour
{
    // Combine two ingredients to make a potion
    public Card CombineIngredients(Card card1, Card card2)
    {
        if (card1.cardType != CardType.Ingredient || card2.cardType != CardType.Ingredient)
        {
            Debug.Log("Both cards must be ingredients!");
            return null;
        }

        // Example: Two Red Hot Chili Peppers make Attack Potion 1
        if (card1.ingredientType == IngredientType.RedHotChiliPepper &&
            card2.ingredientType == IngredientType.RedHotChiliPepper)
        {
            return new Card("Attack Potion 1", CardType.Potion)
            {
                potionType = PotionType.Attack,
                potionLevel = 1
            };
        }

        // Two Potions of same type and level can make higher-level potion
        if (card1.cardType == CardType.Potion && card2.cardType == CardType.Potion &&
            card1.potionType == card2.potionType && card1.potionLevel == card2.potionLevel)
        {
            return new Card($"{card1.potionType} Potion {card1.potionLevel + 1}", CardType.Potion)
            {
                potionType = card1.potionType,
                potionLevel = card1.potionLevel + 1
            };
        }

        // Similar logic for other ingredients (IronShroom -> Defense, Bandage -> Heal) goes here
        return null;
    }
}