using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scr_EndDistance : MonoBehaviour
{
    public Scr_Distance Distance;
    public TMP_Text DistanceText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DistanceText.text = "Distance: " + Distance.distance.ToString("0.0000");
    }

}
