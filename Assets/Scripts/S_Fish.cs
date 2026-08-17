using UnityEngine;

public class S_Fish : MonoBehaviour
{
    [SerializeField] string nameID; 
    [SerializeField] int tier;
    [SerializeField] int difficulty;
    [SerializeField] float passiveIncome;
    [SerializeField] int rarity;


    public float PassiveIncome => passiveIncome;
    public int Tier => tier;
    public string NameID => nameID;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
