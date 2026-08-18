using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class S_Fisher : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] SO_Stats stats;
    public bool IsFishing {get; private set;}

    private (string name, string tier) fish;
    
    void Start()
    {
        
    }

    public (string name, string tier) FishAction( List<(string nameID, int tier)> fishPool)
    {
        StartCoroutine(Fishing(fishPool));
        return fish;
    }
    public IEnumerator Fishing(List<(string nameID, int tier)> fishPool)
    {
        IsFishing = true;
        yield return new WaitForSeconds(stats.fishSpeed);
        fish = GetRandomFish();
        IsFishing = false;
    }

    public (string name, string tier) GetRandomFish()
    {
        (string name, string tier) randomFish = new();
        return randomFish;
    }

}
