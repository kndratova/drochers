using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class BuildingSO : ScriptableObject
{
    [SerializeField] private string description;
    [SerializeField] private Sprite sprite;

    public string Description => description;
    public Sprite Sprite => sprite;
}
