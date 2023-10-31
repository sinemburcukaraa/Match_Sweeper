using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Sirenix.OdinInspector;

public class TileManager : MonoBehaviour
{
    public static TileManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public bool IsTileOver()//tile = kapal�  item=a��k resimli
    {//ekranda tile var m� bak�l�r varsa false d�ner
        for (int j = 0; j < GridSystem.instance.tiles.Count; j++)
        {
            Tile tile = GridSystem.instance.tiles[j];
            if (tile.isActive == false)
            {
                return false;
            }
        }
        return true;
    }
}
