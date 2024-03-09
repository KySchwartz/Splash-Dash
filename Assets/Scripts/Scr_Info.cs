using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Info : MonoBehaviour
{

    [SerializeField] GameObject infoScreen;
    public void displayInfo()
    {
        infoScreen.SetActive(true);
    }

    public void hideInfo() 
    {
        infoScreen.SetActive(false);
    }
}
