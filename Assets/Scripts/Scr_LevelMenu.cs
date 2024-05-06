using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scr_LevelMenu : MonoBehaviour
{
    public int numOfLevels = 2;

    public TMP_Text levelName;

    public Image levelPreview;

    public Sprite[] levelImages;


    // Start is called before the first frame update
    void Start()
    {
        // Select the first level option automatically is nothing is changed
        StaticData.levelNum = 0;

        // State the number of levels avaliable
        numOfLevels = 2;

        updateMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void rightBtn()
    {
        if (StaticData.levelNum < numOfLevels - 1)
        {
            StaticData.levelNum++;
        }
        updateMenu();
    }

    public void leftBtn()
    {
        if (StaticData.levelNum > 0)
        {
            StaticData.levelNum--;
        }
        updateMenu();
    }

    private void updateMenu()
    {
        if (StaticData.levelNum == 0)
        {
            levelName.text = "Crystal Cove";
        }
        else if (StaticData.levelNum == 1)
        {
            levelName.text = "Bubbly Bay";
        }
        else if (StaticData.levelNum == 2)
        {
            levelName.text = "Splash Islands";
        }

        levelPreview.sprite = levelImages[StaticData.levelNum];
        levelPreview.preserveAspect = true;
    }
}
