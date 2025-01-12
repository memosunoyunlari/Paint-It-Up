﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatioSetter : MonoBehaviour
{
    //for the functional windows build
    void Start()
    {
        SetRatio(9, 16);
    }
    void SetRatio(float w, float h)
    {
        if ((((float)Screen.width) / ((float)Screen.height)) > w / h)
        {
            Screen.SetResolution((int)(((float)Screen.height) * (w / h)), Screen.height, true);
        }
        else
        {
            Screen.SetResolution(Screen.width, (int)(((float)Screen.width) * (h / w)), true);
        }
    }
}
