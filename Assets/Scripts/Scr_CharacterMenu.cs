using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scr_CharacterMenu : MonoBehaviour
{
    public int numOfCharacters = 9;

    public TMP_Text characterName;

    public Image characterPreview;

    public Sprite[] characterImages;


    // Start is called before the first frame update
    void Start()
    {
        // Select the first player option automatically
        StaticData.playerNum = 0;

        // State the number of characters avaliable
        numOfCharacters = 9;

        updateMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rightBtn()
    {
        if (StaticData.playerNum < numOfCharacters-1)
        {
            StaticData.playerNum++;
        }
        updateMenu();
    }

    public void leftBtn()
    {
        if (StaticData.playerNum > 0)
        {
            StaticData.playerNum--;
        }
        updateMenu();
    }

    private void updateMenu()
    {
        if (StaticData.playerNum == 0)
        {
            characterName.text = "Dash Dolphin";
        }
        else if (StaticData.playerNum == 1)
        {
            characterName.text = "Tommy Turtle";
        }
        else if (StaticData.playerNum == 2)
        {
            characterName.text = "Sally Sealion";
        }
        else if (StaticData.playerNum == 3)
        {
            characterName.text = "Olly Octapus";
        }
        else if (StaticData.playerNum == 4)
        {
            characterName.text = "Polly Pufferfish";
        }
        else if (StaticData.playerNum == 5)
        {
            characterName.text = "Zippy Seahorse";
        }
        else if (StaticData.playerNum == 6)
        {
            characterName.text = "Simon Shark";
        }
        else if (StaticData.playerNum == 7)
        {
            characterName.text = "Rayla Ray";
        }
        else if (StaticData.playerNum == 8)
        {
            characterName.text = "Walter Whale";
        }

        characterPreview.sprite = characterImages[StaticData.playerNum];
        characterPreview.preserveAspect = true;
    }
}
