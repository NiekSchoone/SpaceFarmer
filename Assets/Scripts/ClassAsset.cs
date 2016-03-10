using UnityEngine;
using UnityEditor;

public class ClassAsset
{
    [MenuItem("Assets/Create/New plant asset")]
    public static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<PlantAsset>();
    }
}