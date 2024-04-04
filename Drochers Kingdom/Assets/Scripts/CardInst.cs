using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CardInst : MonoBehaviour
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

        for (int i = 101; i < 143; i++)
        {
            BuildingCard example = ScriptableObject.CreateInstance<BuildingCard>();
            example.id = i;
            string path = "Assets/ScriptableObjects/Cards/Buildings/Card_" + i + ".asset";
            AssetDatabase.CreateAsset(example, path);
        }
        
        for (int i = 146; i < 183; i++)
        {
            ParchmentCard example = ScriptableObject.CreateInstance<ParchmentCard>();
            example.id = i;
            example.sprite = Resources.Load<Sprite>( "card_parchment_" + (i-145));
            string path = "Assets/ScriptableObjects/Cards/Parchments/Card_" + i + ".asset";
            AssetDatabase.CreateAsset(example, path);
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
