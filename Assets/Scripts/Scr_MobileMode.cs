using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;

public class Scr_MobileMode : MonoBehaviour
{
    public static bool isMobile = false;

    private void Start()
    {
        StaticData.isMobile = false;
    }

    public void SetMobileMode()
    {
        isMobile = !isMobile;

        if (isMobile)
        {
            StaticData.isMobile = true;
        }
        else
        {
            StaticData.isMobile = false;
        }
    }  
}
