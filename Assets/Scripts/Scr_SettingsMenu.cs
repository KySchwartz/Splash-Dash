using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Search;
using UnityEngine;

public class Scr_SettingsMenu : MonoBehaviour
{

    public GameObject ResetGameBtn;
    public GameObject MobileBtn;

    bool showButtons = false;

   public void show()
    {
        showButtons = !showButtons;

        if (showButtons )
        {
            ResetGameBtn.SetActive( true );
            MobileBtn.SetActive( true );
        }
        else if ( !showButtons )
        {
            ResetGameBtn.SetActive ( false );
            MobileBtn.SetActive(false );
        }
    }

}
