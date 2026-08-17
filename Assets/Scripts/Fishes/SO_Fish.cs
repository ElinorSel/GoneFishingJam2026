using UnityEngine;
// Use the CreateAssetMenu attribute to allow creating instances of this ScriptableObject from the Unity Editor.
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Fish", order = 1)]
public class SO_Fish : ScriptableObject
{
    public string nameID; 
    public int[] tier;
    public int[] difficulty;
    public float[] passiveIncome;
    public int[] rarity;

    public GameObject[] Prefabs;
}

