using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Transform tf;
    public SpriteRenderer spriteRenderer;
    public int tileType;
    public bool canFlip = true;
    public Column column;
    public void OnInit(Column column)
    {
        this.column = column;
    }

    public void Flip()
    {
        if (canFlip)
        {
            canFlip = false;
            spriteRenderer.color = GamePlay.Instance.colors[tileType];
        }
    }
}
