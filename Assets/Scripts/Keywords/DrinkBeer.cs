using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InputActions/DrinkBeer", order = 1)]
public class DrinkBeer : InputAction
{
    public override void RespondToInput(GameController controller, string objectKeyword)
    {
        controller.sceneNavigation.AttemptToChangeScenes(objectKeyword);
    }
}
