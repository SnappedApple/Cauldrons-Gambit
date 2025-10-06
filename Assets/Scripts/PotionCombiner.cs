using System.Collections.Generic;
using UnityEngine;

public class PotionCombiner : MonoBehaviour
{

    public Card attackPotion;  // assign in inspector
    public Card healPotion;
    public Card defensePotion;
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
            return CreatePotionInstance(attackPotion);
        }
        else if (card1.ingredientType == IngredientType.GreenHerb &&
            card2.ingredientType == IngredientType.GreenHerb)
        {
            return CreatePotionInstance(healPotion);
        }
        else if (card1.ingredientType == IngredientType.IronShroom &&
            card2.ingredientType == IngredientType.IronShroom)
        {
           return CreatePotionInstance(defensePotion);
        }



        // Two Potions of same type and level can make higher-level potion
        if (card1.cardType == CardType.Potion && card2.cardType == CardType.Potion &&
            card1.potionType == card2.potionType && card1.potionLevel == card2.potionLevel)
        {
            return new Card()
            {
                potionType = card1.potionType,
                potionLevel = card1.potionLevel + 1
            };
        }

        // Similar logic for other ingredients (IronShroom -> Defense, Bandage -> Heal) goes here
        return null;
    }
    
    // Helper method to create a new card instance from a template
    private Card CreatePotionInstance(Card template)
    {
        return new Card()
        {
            cardType = CardType.Potion,
            potionType = template.potionType,
            potionLevel = template.potionLevel,
            effectType = template.effectType,
            effectValue = template.effectValue,
            cardName = template.cardName,
            cardSprite = template.cardSprite
        };
    }


}