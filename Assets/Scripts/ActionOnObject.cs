﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ActionOnObject
{
    public InputAction action;
    public string[] keywordObject;
    [TextArea]
    public string resultDescription;
}
