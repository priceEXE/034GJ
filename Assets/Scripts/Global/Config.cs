using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay;
public class Config
{
    public static Dictionary<string,NodeInfo> infoPath = new Dictionary<string, NodeInfo>()
    {
        {GraphicStyle.Circle.ToString(), new NodeInfo { spritePath = "Sprites/Circle", audioPath = "Audio/Circle" }},
        {GraphicStyle.Circle.ToString() + GraphicStyle.Triangle.ToString(), new NodeInfo { spritePath = "Sprites/Circle_Triangle", audioPath = "Audio/Circle_Triangle" }},
    };
}

public struct NodeInfo
{
    public string spritePath;
    public string audioPath;

}
    