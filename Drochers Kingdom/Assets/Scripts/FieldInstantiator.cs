using System;
using System.Collections;
using System.Collections.Generic;
using Field;
using UnityEngine;

public class FieldInstantiator : MonoBehaviour
{
    [SerializeField] private FieldCellSO[] cells;
    [SerializeField] private GameObject cellPrefab;

    [ContextMenu("Start")]
    private void Start()
    {
        foreach (var cell in cells)
        {
            Instantiate(cellPrefab, transform.position * cell.Coordinates, Quaternion.identity, transform).GetComponentInChildren<FieldCell>().Construct(cell);
        }
    }
}
