using System.Linq;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class FieldCell : MonoBehaviour
    {
        [SerializeField] public Image image;
        [SerializeField] public FieldCellSO cell;
        private SpriteRenderer _spriteRenderer;
        private Color _initialColor;
        private Field _field;

        private void Start()
        {
            _field = GetComponentInParent<Field>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.enabled = true;
            _spriteRenderer.color = Color.clear;
        }
    
        private void CheckBuildAbility(BuildingSO building)
        {
            if (cell.AvailableItems.Contains(building)) _spriteRenderer.color = Color.green;
        }

        public void Construct(FieldCellSO fieldCell)
        {
            cell = fieldCell;
            image.sprite = cell.Sprite;
        }
    
        private void OnMouseDown()
        {
            _initialColor = image.color;
            image.color = Color.grey;
            Field.cellSelected.Invoke(this);
        }

        private void OnMouseUp()
        {
            image.color = _initialColor;
        }
    }
}
