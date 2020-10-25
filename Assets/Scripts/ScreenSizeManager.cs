using static System.Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSizeManager : MonoBehaviour
{
    private GridLayoutGroup grid;
    private RectTransform rect;
    private float screenWidth = 0;
    private float screenHeight = 0;
    private void Awake() {
        grid = GetComponent<GridLayoutGroup>();
        rect = GetComponent<RectTransform>();
        // AdjustScreenSize();
    }
    private void OnEnable() {
        
    }

    private void Update() {
        // if(Screen.width != screenWidth || Screen.height != screenHeight){
        //     if(AdjustScreenSize()) {
        //         screenWidth = Screen.width;
        //         screenHeight = Screen.height;
        //     }
        // }
    }

    private bool AdjustScreenSize() {
        Debug.Log($"Screen size is {screenWidth}x{screenHeight}");
        
        int childCount = transform.childCount;
        if(childCount == 0) {
            Debug.Log($"Child count is 0. Not adjusting screen size.");
            return false;
        }
        Debug.Log($"Adjusting screen size because child count is {childCount}");
        int rows = (int)System.Math.Ceiling((double)childCount / grid.constraintCount);
        float newCellWidth = (rect.rect.width - (grid.constraintCount - 1) * grid.spacing.x) / grid.constraintCount;
        float newCellHeight = (rect.rect.height - (rows - 1) * grid.spacing.y) / rows;
        Debug.Log($"Setting cell size to {newCellWidth}x{newCellHeight}");
        grid.cellSize = new Vector2(newCellWidth, newCellHeight);
        return true;
    }
}
