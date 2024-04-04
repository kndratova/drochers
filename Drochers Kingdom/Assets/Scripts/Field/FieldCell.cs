using System.Linq;
using Field;
using UnityEngine;
using UnityEngine.UI;

public class FieldCell : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private FieldCellSO cell;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
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

    private void OnMouseEnter()
    {
        if (_spriteRenderer.color != Color.clear) return;
        _spriteRenderer.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        if (_spriteRenderer.color != Color.yellow) return;
        _spriteRenderer.color = Color.clear;
    }

    private void OnMouseDown()
    {
        Debug.Log("Down");
        _spriteRenderer.color = Color.green;
    }
}
