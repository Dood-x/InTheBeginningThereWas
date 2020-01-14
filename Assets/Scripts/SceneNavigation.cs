using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNavigation : MonoBehaviour
{
    public Scene currentScene;

    Dictionary<string, Scene> exitDictionary = new Dictionary<string, Scene>();

    GameController controller;
    void Awake()
    {
        controller = GetComponent<GameController>();
    } 

    public void UnpackExitsInScene()
    {
        for (int i = 0; i < currentScene.exits.Length; i++)
        {
            for(int j = 0; j < currentScene.exits[i].keyString.Length; j++)
            {
                exitDictionary.Add(currentScene.exits[i].keyString[j], currentScene.exits[i].valueScene);
                controller.interactionDescriptionInRoom.Add(currentScene.exits[i].exitDescription);
            }
        }
    }

    public void AttemptToChangeScenes(string sceneChangeNoun)
    {
        if(exitDictionary.ContainsKey(sceneChangeNoun))
        {
            currentScene = exitDictionary[sceneChangeNoun];
            controller.LogStringWithReturn("");
            controller.DisplaySceneText();
        }
        else
        {
            controller.LogStringWithReturn("Nothing Happens.");
        }
    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
