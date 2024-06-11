using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : Singleton<GamePlay>
{
    public List<Color> colors;
    public Tile currentTile;
    public GameObject tileGO;
    public LayerMask tileLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = Instantiate(tileGO);
        go.transform.position = Vector3.zero;
        currentTile = go.GetComponent<Tile>();
        currentTile.tileType = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 inputMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D col = Physics2D.OverlapPoint(inputMouse, tileLayerMask);
            Debug.Log(col);
            Tile t = Cache.GetTile(col);
            currentTile = t.column.ChangeTile(currentTile);
        }
    }
}
