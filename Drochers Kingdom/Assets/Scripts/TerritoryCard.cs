using UnityEngine;

[CreateAssetMenu(menuName = "Card/Territory Card", fileName = "TerritoryCard")]
public class TerritoryCard : Card
{
    [SerializeField] public Vector2 coordinates;

    public Vector2 Coordinates => coordinates;
}