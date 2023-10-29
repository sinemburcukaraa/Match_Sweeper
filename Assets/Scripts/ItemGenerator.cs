using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
public class ItemGenerator : MonoBehaviour
{
    public List<TileItem> allItem = new List<TileItem>();
    public int itemCount;
    public int gridSizeX, gridSizeY;
    public TileData tileData;
    public static ItemGenerator Instance;

    int tilesToOpenCount;
    int randomTile;
    private void Awake()
    {
        Instance = this;

    }
    private IEnumerator Start()//Start Fonksiyonu 2 frame geciktirildi. Bu sayede di�er startlar ile cakismasi onlendi.
    {
        yield return null;
        yield return null;

        gridSizeX = LevelManager.instance.currentLevelSettings._gridSize.x;
        gridSizeY = LevelManager.instance.currentLevelSettings._gridSize.y;
        tileData = LevelManager.instance.currentLevelSettings.tileData;
        tilesToOpenCount = LevelManager.instance.currentLevelSettings.tilesToOpen.Count;
        randomTile = starttile();
        Generate();

    }
    public void Generate()//6*10=60 , 60/4 =15 , 60%4=0
    {
        itemCount = gridSizeX * gridSizeY;
        int mod = itemCount % 4;
        int result = itemCount / 4;
        if (mod == 0)
        {
            AddTileItem(result, 4, 0);
        }
        else if (mod == 2)
        {
            AddTileItem(result, 4, 0);
            AddTileItem(result + 1, 2, result);

        }
    }
    int pairMatchControl = 0;
    int index; int itemLenght;

    public int starttile()
    {
        int rand = UnityEngine.Random.Range(0, tilesToOpenCount);//3
        Debug.Log(tilesToOpenCount);
        return rand;
    }
    public string getRandomItem()
    {
        if (allItem.Count > 0)
        {
            Debug.Log(randomTile);
            if (pairMatchControl != randomTile)
            {
                index = UnityEngine.Random.Range(0, allItem.Count);
                itemLenght = allItem[index].count;
                allItem[index].count--;
                pairMatchControl++;

                if (CheckAllItem(index, itemLenght))
                    return allItem[index].id;
                else return getRandomItem();

            }
            else
            {
                itemLenght = allItem[index].count;
                allItem[index].count--;
                pairMatchControl++;

                if (CheckAllItem(index, itemLenght))
                    return allItem[index].id;
                else return getRandomItem();
            }



        }
        return null;

    }
    public bool CheckAllItem(int index, int itemCount)
    {
        if (itemCount > 0) return true;
        else if (itemCount == 0) allItem.RemoveAt(index);
        return false;
    }
    public Sprite SearchSprite(string index)
    {
        foreach (var item in tileData.items)
        {
            if (item.id == index)
            {
                return item.sprite;
            }
        }
        return null;
    }
    private void AddTileItem(int result, int count, int startIndex)
    {
        for (int i = startIndex; i < result; i++)
        {
            TileItem newItem = new TileItem();
            newItem.id = tileData.items[i].id;
            newItem.count = count;
            allItem.Add(newItem);
        }
    }
}
[Serializable]
public class TileItem
{
    public string id;
    public int count;
}