using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.AudioSettings;
using UnityEngine.EventSystems;

public class Scr_Mobile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject MobileControls;
    public bool buttonPressed;

    private void Start()
    {
    if (StaticData.isMobile)
        {
            MobileControls.SetActive(true);
        }
    else
        {
            MobileControls.SetActive(false); 
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }
}
