using System.Collections;
using System.Collections.Generic;
using Field;
using UnityEditor;
using UnityEngine;

public class SOInstatiator : MonoBehaviour
{
    [ContextMenu("Generate Cards SO")]
    private void CreateCardPrefabs()
    {

        /*int counter = 1;
        for (char j = 'a'; j < 'k'; j++)
        {
            int raw = 1;
            for (int i = 1; i < 11; i++)
            {
                TerritoryCard example = ScriptableObject.CreateInstance<TerritoryCard>();
                example.id = counter;
                example.coordinates = new Vector2(raw, i); 
                example.sprite = Resources.Load<Sprite>( "card_"+j+"_" +i);
                string path = "Assets/ScriptableObjects/Cards/Territory/Card_" + counter + ".asset";
                AssetDatabase.CreateAsset(example, path);
                raw++;
                counter++;
            }
        }*/

        /*for (int i = 101; i < 143; i++)
        {
            BuildingCardSO example = ScriptableObject.CreateInstance<BuildingCardSO>();
            example.id = i;
            string path = "Assets/ScriptableObjects/Cards/Buildings/Card_" + i + ".asset";
            AssetDatabase.CreateAsset(example, path);
        }
        
        for (int i = 146; i < 183; i++)
        {
            ParchmentCardSO example = ScriptableObject.CreateInstance<ParchmentCardSO>();
            example.id = i;
            example.sprite = Resources.Load<Sprite>( "card_parchment_" + (i-145));
            string path = "Assets/ScriptableObjects/Cards/Parchments/Card_" + i + ".asset";
            AssetDatabase.CreateAsset(example, path);
        }
        */
        /*var counter = 1;
        for (char i = 'a'; i < 'k'; i++)
        {
            for (int j = 1; j < 11; j++)
            {
                FieldCellSO example = ScriptableObject.CreateInstance<FieldCellSO>();
                example.coordinates = new Vector2(i, j);
                example.sprite = Resources.Load<Sprite>( "field_" + i + "_" + j);
                string path = "Assets/ScriptableObjects/Field_" + i + "_" + j+ ".asset";
                AssetDatabase.CreateAsset(example, path);
                counter++;
            }
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();*/
    }
}
