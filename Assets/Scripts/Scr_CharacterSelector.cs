using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CharacterSelector : MonoBehaviour
{
    public GameObject[] playerCharacters;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacters[StaticData.playerNum].SetActive(true);
    }
}
