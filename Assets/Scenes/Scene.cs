using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Scene", order = 1)]
public class Scene : ScriptableObject
{
    [TextArea]
    public string sceneDescription;

    public string sceneName;
    public Exit[] exits;

    public bool anyInputExit = false;

    //public string[] sceneObjects;

    //public Dictionary<string, string> objectDescriptions = new Dictionary<string, string>();
    public List<ActionOnObject> actionsOnObjects = new List<ActionOnObject>();
    public ActionOnObject exitScene;

}
