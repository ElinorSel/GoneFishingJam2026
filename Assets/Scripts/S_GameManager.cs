using UnityEngine;
using System;


public class S_GameManager : MonoBehaviour
{
    [SerializeField] float _money;
    [SerializeField] S_Aquarium aquarium;
    [SerializeField] S_AquariumVisuals aquariumVisuals;
    [SerializeField] S_FishData fishData;
    [SerializeField] S_Fisher playerFisher; //change to fisher

    private S_FishPoolData fishPoolData;

    
    public float Money => _money;


    //_______________Events__________
    public event Action<string, int> OnFishCaught;

    public void AddMoney(float value)
    {
        _money += value;
    }
    public bool RemoveMoney(float value)
    {
        if(value > _money)
        {
            return false;
        }
        _money -= value;
        return true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fishPoolData = fishData.GetFishPool(playerFisher.Stats.skill);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerFish()
    {
        StartCoroutine(playerFisher.FishAction((result) =>
        {
            // The code inside these brackets runs ONLY when the coroutine finishes
            //Debug.Log($"Received Item: {result.name} at Tier: {result.tier}");
            
            //the result is returned and can be handled here
            OnFishCaught.Invoke(result.name, result.tier);
        }, fishPoolData));
    }

    public void HandleAddFish( string name, int tier)
    {
        aquarium.AddFish(name, tier);
        GameObject fishPrefab = fishData.getFishPrefab(name, tier);
        aquariumVisuals.SpawnFish(fishPrefab);
    }

    public void HandleSellFish( string name, int tier)
    {
        AddMoney(fishData.GetFishSellPrice(name, tier));
    }

    public float GetCurrentPassiveIncome()
    {
       return aquarium.CurrentPassiveIncome;
    }


    //TODO: trigger autofishers from here
    //SKILL LVL increase handler updates autofish
    //
}
