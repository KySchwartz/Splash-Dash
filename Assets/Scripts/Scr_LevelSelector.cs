using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_LevelSelector : MonoBehaviour
{

    public GameObject[] levels;

    // Start is called before the first frame update
    void Start()
    {
        levels[StaticData.levelNum].SetActive(true);
    }
}
