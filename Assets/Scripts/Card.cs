using UnityEngine;

public enum CardType { Ingredient, Potion }
public enum IngredientType { RedHotChiliPepper, IronShroom, GreenHerb }
public enum PotionType { Attack, Defense, Heal }
public enum EffectType { Damage, Heal, Shield, None, Attack }

[CreateAssetMenu(fileName = "NewCard", menuName = "Cards/Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public CardType cardType;

    // Ingredient info
    public IngredientType ingredientType;

    // Potion info
    public PotionType potionType;
    public int potionLevel; // e.g., Potion 1, 2, 3

    // Effect info
    public EffectType effectType;
    public int effectValue;

    public Sprite cardSprite; // assign in Inspector
}