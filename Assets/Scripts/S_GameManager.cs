using UnityEngine;
using System;
using Unity.VisualScripting;
using System.Collections.Generic;
using System.Collections;


public class S_GameManager : MonoBehaviour
{
    [SerializeField] float _money;
    [SerializeField] S_Aquarium aquarium;
      [SerializeField] S_StorageManager storageManager;
    [SerializeField] S_AquariumVisuals aquariumVisuals;
    [SerializeField] S_FishData fishData;
    [SerializeField] S_Fisher playerFisher;
    [SerializeField] List<S_Fisher> autoFishers;

    private S_FishPoolData fishPoolData;

    
    public float Money => _money;


    //_______________Events__________
    public event Action<string, int> OnFishCaught;

    public void AddMoney(float value)
    {
        _money += value;
    }
    public bool TryBuy(float value)
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
        GameObject fishPrefab = fishData.GetFishPrefab(name, tier);
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


    //____Auto fishing_____

    public bool TryBuyAutoFisher(float price, string nameID)
    {
        if (TryBuy(price))
        {
            AddAutoFisher(nameID);
            return true;
        }
        else return false;
    }

    public void AddAutoFisher(string nameID)
    {
        S_Fisher newAutofisher = new();
        newAutofisher.SetStats(S_FishData.Instance.autoFisherDataLookup[nameID]);
        autoFishers.Add(newAutofisher);
        StartCoroutine(AutoFish(newAutofisher));
    }

    private IEnumerator AutoFish(S_Fisher autoFisher)
    {
        while (true) //TODO: change to while game running?
        {
            StartCoroutine(autoFisher.FishAction((result) =>
            {
                // The code inside these brackets runs ONLY when the coroutine finishes
                //Debug.Log($"Received Item: {result.name} at Tier: {result.tier}");
                
                //the result is returned and can be handled here
                //TODO: add to autofish storage
                storageManager.AddFish((result.name, result.tier));
                Debug.Log( result.name + result.tier + " was caught by " + autoFisher.Stats.nameID);
            }, fishPoolData));

            yield return new WaitForSeconds(autoFisher.Stats.fishSpeed);
        }

        
    }


    //TODO: trigger autofishers from here
    //SKILL LVL increase handler updates autofish
    //
}
