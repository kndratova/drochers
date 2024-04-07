using Management;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
    public class Field : MonoBehaviour
    {
        [SerializeField] private FieldCell[] cells;
        [SerializeField] private GameObject bunnyPrefab;
        public static readonly UnityEvent<Player, Vector2> TerritorySet = new();
        public static readonly UnityEvent<FieldCell> cellSelected = new();
        public Text cellInfoText;
        [SerializeField] private GameObject buildingPrefab;
        
        
        private FieldCell _selectedCell;

        private void Start()
        {
            cellSelected.AddListener(DisplayCellInfo);
            TerritorySet.AddListener(SetTerritory);
            CardStack.CardStackSelected.AddListener(HideField);
        }

        public void Build(BuildingSO building)
        {
            Instantiate(buildingPrefab, _selectedCell.transform.parent).GetComponent<Image>().sprite = building.Sprite;
        }

        private void DisplayCellInfo(FieldCell cell)
        {
            _selectedCell = cell;
            char column = (char)('A' + (int)cell.cell.Coordinates.x - 1);
            int row = (int)cell.cell.Coordinates.y;
            string cellInfo = $"{column}{row}";
            cellInfoText.text = "Cell: " + cellInfo;
        }

        private void HideField(CardStack _)
        {
            gameObject.SetActive(false);
        }

        private void SetTerritory(Player player, Vector2 coordinates)
        {
            foreach (var cell in cells)
            {
                if (cell.cell.Coordinates == coordinates)
                {
                    Instantiate(bunnyPrefab, cell.transform.parent).GetComponent<Image>().color = player.playerColor;
                    cell.image.color = player.playerColor;
                }
            }
        }
    }
}
