using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InputActions/LookInside", order = 1)]
public class LookInside : InputAction
{
    public override void RespondToInput(GameController controller, string objectKeyword)
    {
        controller.sceneNavigation.AttemptToChangeScenes(objectKeyword);
    }
}
