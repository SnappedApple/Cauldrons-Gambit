using UnityEngine;

public class CardSpriteManager : MonoBehaviour
{
    public Sprite attackSprite;
    public Sprite healSprite;
    public Sprite shieldSprite;

    public Sprite GetSpriteForType(EffectType type)
    {
        switch(type)
        {
            case EffectType.Attack: return attackSprite;
            case EffectType.Heal: return healSprite;
            case EffectType.Shield: return shieldSprite;
            default: return null;
        }
    }
}