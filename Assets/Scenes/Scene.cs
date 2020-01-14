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
}
