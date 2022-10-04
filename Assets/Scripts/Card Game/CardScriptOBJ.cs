using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/NewCard", order = 1)]
public class CardScriptOBJ : ScriptableObject
{
    public string CardName;
    public int Damage;
    public int Defence;
    public int Health;
}
