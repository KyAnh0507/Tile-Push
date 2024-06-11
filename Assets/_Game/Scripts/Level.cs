using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform tf;
    public GameObject column;
    public List<Column> columnPlayer = new List<Column>();
    public List<Column> columnComputer = new List<Column>();
    public int numberTile;
    public int numberColumn;

    public void OnInit()
    {
        for (int i = 0; i < numberColumn; i++)
        {
            GameObject go = Instantiate(column, tf);
            if (numberColumn%2 == 0)
            {
                go.transform.localPosition = Vector3.zero + new Vector3((-numberColumn / 2 + 0.7f) + 0.25f + i * 0.7f, -1.35f, 0);
            }
            else
            {
                go.transform.localPosition = Vector3.zero + new Vector3((-numberColumn / 2) + 0.25f + i * 0.7f, -1.35f, 0);
            }
            columnPlayer.Add(go.GetComponent<Column>());
        }
        for (int i = 0; i < numberColumn; i++)
        {
            GameObject go = Instantiate(column, tf);
            go.transform.localRotation = Quaternion.Euler(0, 0, 180f);
            if (numberColumn % 2 == 0)
            {
                go.transform.localPosition = Vector3.zero + new Vector3((-numberColumn / 2 + 0.7f) + 0.25f + i * 0.7f, 1.35f, 0);
            }
            else
            {
                go.transform.localPosition = Vector3.zero + new Vector3((-numberColumn / 2) + 0.25f + i * 0.7f, 1.35f, 0);
            }
            columnComputer.Add(go.GetComponent<Column>());
        }
        foreach (Column c in columnPlayer)
        {
            c.OnInit(numberTile);
        }

        foreach (Column c in columnComputer)
        {
            c.OnInit(numberTile);
        }
        RandomColor();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomColor()
    {
        int[] colors = new int[numberTile*numberColumn];
        int[] c = new int[numberColumn];
        for(int i = 0; i < numberTile*numberColumn; i++)
        {
            while (true)
            {
                int ran = Random.Range(0, numberColumn);
                if (c[ran] >= numberTile)
                {
                    continue;
                }
                else
                {
                    c[ran]++;
                    colors[i] = ran;
                    break;
                }
            }
        }
        int d = 0;
        for (int i = 0;i < numberColumn; i++)
        {
            for (int j = 0; j < numberTile; j++)
            {
                columnPlayer[i].tiles[j].tileType = colors[d];
                d++;
            }
        }
    }
}
