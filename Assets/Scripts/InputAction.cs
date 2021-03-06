﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputAction : ScriptableObject
{
    public int priority;
    public string[] keyWord;
    public abstract void RespondToInput(GameController controller, string objectKeyword);
}
