﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InputActions/Question", order = 1)]
public class Question : InputAction
{
    public override void RespondToInput(GameController controller, string objectKeyword)
    {
        controller.sceneNavigation.AttemptToChangeScenes(objectKeyword);
    }
}
