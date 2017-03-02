using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;


public class MakeLevelConfig
{
    [MenuItem("Assets/Create/Level List")]
    public static LevelConfigList Create()
    {
        LevelConfigList asset = ScriptableObject.CreateInstance<LevelConfigList>();

        AssetDatabase.CreateAsset(asset, "Assets/Scene/LevelConfig.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}
