using UnityEngine;

public enum CardType { Ingredient, Potion }
public enum IngredientType { RedHotChiliPepper, IronShroom, Bandage }
public enum PotionType { Attack, Defense, Heal }
public enum EffectType { Damage, Heal, Shield, None, Attack } // or whatever types your game needs

[System.Serializable]
public class Card
{
    public string cardName;
    public CardType cardType;

    // Ingredient info
    public IngredientType ingredientType;

    // Potion info
    public PotionType potionType;
    public int potionLevel; // e.g., Potion 1, 2, 3

    // Effect info (used in gameplay)
    public EffectType effectType;
    public int effectValue;

    public Card(string name, CardType type)
    {
        cardName = name;
        cardType = type;
    }
}