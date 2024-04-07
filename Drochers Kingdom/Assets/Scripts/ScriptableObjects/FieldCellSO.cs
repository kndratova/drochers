using UnityEngine;

namespace ScriptableObjects
{
    public class FieldCellSO : ScriptableObject
    {
        [SerializeField] private Vector2 coordinates;
        [SerializeField] private Sprite sprite;
        [SerializeField] private BuildingSO[] availableItems;
        
        public Vector2 Coordinates => coordinates;
        public Sprite Sprite => sprite;
        public BuildingSO[] AvailableItems =>  availableItems;
    }
}
