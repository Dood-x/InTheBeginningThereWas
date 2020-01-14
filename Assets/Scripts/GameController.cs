using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text displayText;
    [HideInInspector]
    public SceneNavigation sceneNavigation;
    [HideInInspector]
    public List<string> interactionDescriptionInRoom = new List<string>();

    public InputAction[] inputActions;
    List<string> actionLog = new List<string>();
    // Start is called before the first frame update
    void Awake()
    {
        sceneNavigation = GetComponent<SceneNavigation>();
    }

    void Start()
    {
        DisplaySceneText();
        DisplayLoggedText();
    }

    public void DisplayLoggedText()
    {
        string logText = string.Join("\n", actionLog.ToArray());

        displayText.text = logText;
    }

    public void DisplaySceneText()
    {
        ClearCollectionForNewScene();
        
        UnpackScene();

        string joinedInteacrionDescriptions = string.Join("\n", interactionDescriptionInRoom.ToArray());

        string combinedText = sceneNavigation.currentScene.sceneDescription + "\n" + joinedInteacrionDescriptions;
        LogStringWithReturn(combinedText);
    }

    void UnpackScene()
    {
        sceneNavigation.UnpackExitsInScene();
    }

    void ClearCollectionForNewScene()
    {
        interactionDescriptionInRoom.Clear();
        sceneNavigation.ClearExits();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
