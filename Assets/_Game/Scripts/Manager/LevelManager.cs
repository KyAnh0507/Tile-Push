using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public List<Level> levels = new List<Level>();
    public Level currentLevel;
    public int indexLevel;

    // Start is called before the first frame update
    void Start()
    {
        LoadLevel(0);
    }

    public void LoadLevel(int level)
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }
        currentLevel = Instantiate(levels[indexLevel]);
        currentLevel.OnInit();
    }
}
