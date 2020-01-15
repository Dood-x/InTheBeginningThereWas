using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        if(sceneChangeNoun == "" && currentScene.anyInputExit)
        {
            Scene[] values = new Scene[exitDictionary.Values.Count];
            exitDictionary.Values.CopyTo(values, 0);
            currentScene = values[0];
            controller.LogStringWithReturn("");
            controller.DisplaySceneText();
            return;
        }

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

    public bool ExecuteActionOnObject(InputAction action, string objectKeyword)
    {
        foreach (ActionOnObject aoo in currentScene.actionsOnObjects)
        {
            if(action == aoo.action)
            {
                for(int i =0; i < aoo.keywordObject.Length; i++)
                {
                    if(objectKeyword == aoo.keywordObject[i])
                    {
                        controller.LogStringWithReturn(aoo.resultDescription);
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
