using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;


public class MakeConfig
{
    [MenuItem("Assets/Create/Config/Level Config")]
    public static LevelConfigList CreateLevelConfig()
    {
        LevelConfigList asset = ScriptableObject.CreateInstance<LevelConfigList>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/Config/LevelConfig.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }


    [MenuItem("Assets/Create/Config/UI Config")]
    public static UIConfigList CreateUIConfig()
    {
        UIConfigList asset = ScriptableObject.CreateInstance<UIConfigList>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/Config/UIConfig.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}
