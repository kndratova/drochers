using UnityEngine;

public class Card : ScriptableObject
{
    [SerializeField] public int id;
    [SerializeField] public Sprite sprite;
    [SerializeField] public string description;
    
    public Sprite Sprite => sprite;
    public string Description => description;
    public int Id => id;
}
