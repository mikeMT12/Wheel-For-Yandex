﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBoundary : MonoBehaviour
{
    public static float leftSide = -3.5f;
    public static float rightSide = 3.5f;
    public float intrnalLeft;
    public float intarnalRight;

    void Update()
    {
        intrnalLeft = leftSide;
        intarnalRight = rightSide;
    }
}
