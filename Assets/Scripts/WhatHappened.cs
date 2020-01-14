using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InputActions/WhatHappened", order = 1)]
public class WhatHappened : InputAction
{
    public override void RespondToInput(GameController controller, string[] separateInputWords)
    {
        controller.sceneNavigation.AttemptToChangeScenes(separateInputWords[1]);
    }
}
