﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InputActions/DrinkWhiskey", order = 1)]
public class DrinkWhiskey : InputAction
{
    public override void RespondToInput(GameController controller, string objectKeyword)
    {
        controller.sceneNavigation.AttemptToChangeScenes(objectKeyword);
    }
}
