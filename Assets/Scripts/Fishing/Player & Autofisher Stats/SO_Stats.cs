using UnityEngine;
// Use the CreateAssetMenu attribute to allow creating instances of this ScriptableObject from the Unity Editor.
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Stats", order = 1)]
public class SO_Stats : ScriptableObject
{
    public string nameID; 
    public int luck;
    public float fishSpeed;
    public int skill;

    public GameObject Prefab;
}

