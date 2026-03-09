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
    private static Dictionary<string, GameObject> prefabs; 
    private static Dictionary<string, AudioClip> audios;

    private static void Initialize()
    {
        prefabs = new Dictionary<string, GameObject>();
        audios = new Dictionary<string, AudioClip>();
        foreach (var item in Config.prefabsPath)
        {
            if(item.Value.PrefabPath == null)  continue;
            prefabs.Add(item.Key, Resources.Load<GameObject>(item.Value.PrefabPath));
        }
        foreach (var item in Config.prefabsPath)
        {
            if(item.Value.AudioPath == null)  continue;
            audios.Add(item.Key, Resources.Load<AudioClip>(item.Value.AudioPath));
        }
    }

    public GameObject GetPrefab(string key)
    {
        if (prefabs.ContainsKey(key))
        {
            return prefabs[key];
        }
        else
        {
            Debug.LogError("Prefab not found: " + key);
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
