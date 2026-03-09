using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;
public class Config
{
    public static Dictionary<string,NodeInfo> prefabsPath = new Dictionary<string, NodeInfo>()
    {
        {GraphicStyle.None.ToString() + GraphicStyle.None.ToString() + GraphicStyle.None.ToString(), new NodeInfo { PrefabPath = null, AudioPath = null }},
        {GraphicStyle.Circle.ToString(), new NodeInfo { PrefabPath = "Prefabs/Tester", AudioPath = "Audio/Tester" }},
    };
}

public struct NodeInfo
{
    public string PrefabPath;
    public string AudioPath;

}
    