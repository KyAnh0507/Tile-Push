using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Column : MonoBehaviour
{
    public Transform tf;
    public List<Tile> tiles = new List<Tile>();
    public int tileType;
    public int numberTile;
    public GameObject tileGO;
    public bool isPlayer;
    public void OnInit(int numberTile)
    {
        this.numberTile = numberTile;
        for (int i = 0; i < numberTile; i++) 
        {
            GameObject go = Instantiate(tileGO, tf);
            go.transform.localPosition = Vector3.zero - new Vector3(0, 0.9f*i, 0);
            go.GetComponent<Tile>().OnInit(this);
            tiles.Add(go.GetComponent<Tile>());
        }
    }

    public Tile ChangeTile(Tile t)
    {
        Tile tmp = tiles[tiles.Count - 1];
        for (int i = tiles.Count - 1; i > 0; i--)
        {
            tiles[i] = tiles[i - 1];
        }
        tiles[0] = t;
        t.tf.SetParent(tf);
        t.column = this;
        for (int i = 0; i < numberTile; i++)
        {
            tiles[i].tf.DOLocalMove(new Vector3(0, -0.9f * i, 0), 1f);
        }
        tmp.tf.SetParent(null);
        tmp.tf.DOMove(Vector3.zero, 1f);
        tmp.column = null;
        if (tmp.tileType != -1)
        {
            tmp.Flip();
        }
        return tmp;
    }
}
