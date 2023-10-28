using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    [SerializeField] private Vector2Int _gridSize;
    public TileData tileData;
    private void Start()
    {
        GridSystem.instance.GenerateGridSystem(_gridSize.x, _gridSize.y);
    }
}