using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Rendering;
using System;

public class S_Fisher : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] SO_Stats stats;
    public bool IsFishing {get; private set;}

    public SO_Stats Stats => stats;


    private (string name, int tier) fish;
    private S_FishPoolData _fishPool;

    public void SetStats(SO_Stats value)
    {
        stats = value;
    }
    
    public (string name, int tier) FishActionTest()
    {
        
        //StartCoroutine(Fishing());
        return fish;
    }

    public IEnumerator FishAction(Action<(string name, int tier)> callback, S_FishPoolData fishPool)
    {
        _fishPool = fishPool;
        IsFishing = true;
        fish = GetRandomFish();
        
        yield return new WaitForSeconds(stats.fishSpeed);
        //int tier = GetRandomDifficultyTier();
        IsFishing = false;
        // Send the data back through the callback
        callback?.Invoke(fish);
        
    }

    public (string name, int tier) GetRandomFish()
    {
        int random = UnityEngine.Random.Range(0,_fishPool.ApprovedDifficultyPool.Count);
        (string name, int tier) randomFish = _fishPool.ApprovedDifficultyPool[random];

        //luck reroll if applicaple
        //each luck lvl allows for 1 additional reroll for a better TIER fish (tier not difficulty)
        for(int i = 0; i < stats.luck; i++)
        {
            (string name, int tier) newRandomFish = new();
            random = UnityEngine.Random.Range(0,_fishPool.ApprovedDifficultyPool.Count);
            newRandomFish = _fishPool.ApprovedDifficultyPool[random];

            if(newRandomFish.tier > randomFish.tier)
            {
                randomFish = newRandomFish;
            }
            
        }

        return randomFish;
    }

    /*

    private int GetRandomDifficultyTier()
    {
        int random = Random.Range(0,100);

        int luckBonus = 0;


        //chose which difficulty tier of fish will be lotted within
        if(random < 1)
        {
            return 0;
        }

             if(random < 10)
        {
            return 0;
        }
    }
    */


}
