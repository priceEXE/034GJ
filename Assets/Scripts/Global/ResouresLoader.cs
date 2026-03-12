using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResouresLoader
{
    private static ResouresLoader instance = null;
    public static ResouresLoader Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new ResouresLoader();
                Initialize();
            }
            return instance;
        }
    }
    private static Dictionary<string, Sprite> textures; 
    private static Dictionary<string, AudioClip> audios;

    private static void Initialize()
    {
        textures = new Dictionary<string, Sprite>();
        audios = new Dictionary<string, AudioClip>();
        foreach (var item in Config.infoPath)
        {
            if(item.Value.spritePath == null)  continue;
            textures.Add(item.Key, Resources.Load<Sprite>(item.Value.spritePath));
        }
        foreach (var item in Config.infoPath)
        {
            if(item.Value.audioPath == null)  continue;
            audios.Add(item.Key, Resources.Load<AudioClip>(item.Value.audioPath));
        }
    }

    public Sprite GetTexture(string key)
    {
        if (textures.ContainsKey(key))
        {
            return textures[key];
        }
        else
        {
            Debug.LogError("Texture not found: " + key);
            return null;
        }
    }

    public AudioClip GetAudio(string key)
    {
        if (audios.ContainsKey(key))
        {
            return audios[key];
        }
        else
        {
            Debug.LogError("Audio not found: " + key);
            return null;
        }
    }
}
