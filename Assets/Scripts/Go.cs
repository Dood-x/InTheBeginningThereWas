using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InputActions/Go", order = 1)]
public class Go : InputAction
{
    public override void RespondToInput(GameController controller, string[] separateInputWords)
    {
        controller.sceneNavigation.AttemptToChangeScenes(separateInputWords[1]);
    }
}
