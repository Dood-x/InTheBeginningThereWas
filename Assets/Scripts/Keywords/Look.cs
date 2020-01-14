using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InputActions/Look", order = 1)]
public class Look : InputAction
{
    public override void RespondToInput(GameController controller, string[] separateInputWords)
    {
        controller.sceneNavigation.AttemptToChangeScenes(separateInputWords[separateInputWords.Length-1]);
    }
}
