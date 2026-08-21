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
    [SerializeField] GameObject autoFisherParent;
    [SerializeField] GameObject autoFisherPrefab;

    public S_Fisher PlayerFisher => playerFisher;


    private S_FishPoolData fishPoolData;
    public bool PlayerIsFishing {get; private set;}

    
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

    public void PlayerFish()
    {
        PlayerIsFishing = true;
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
        PlayerIsFishing = false; // cant fish untill you chose an option in the ui
        aquarium.AddFish(name, tier);
        GameObject fishPrefab = fishData.GetFishPrefab(name, tier);
        aquariumVisuals.SpawnFish(fishPrefab);
    }

    public void HandleSellFish( string name, int tier)
    {
        PlayerIsFishing = false; // cant fish untill you chose an option in the ui
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
        
        GameObject newAutofisherGO = Instantiate(autoFisherPrefab, autoFisherParent.transform);
        S_Fisher newAutofisher =  newAutofisherGO.GetComponent<S_Fisher>();
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

    public void IncreaseSkillLvl()
    {
        playerFisher.Stats.skill++;
        Debug.Log("Player Skill is" + playerFisher.Stats.skill);
        fishPoolData = fishData.GetFishPool(playerFisher.Stats.skill);

    }

    public void IncreaseLuckLvl()
    {
        playerFisher.Stats.luck++;
    }
        public void IncreaseSpeed()
    {
        if (playerFisher.Stats.fishSpeed - 0.5f >= 0.5f)
        {
            playerFisher.Stats.fishSpeed -= 0.5f;
        }
        else
        {
            Debug.Log("WARNING fishing speed cannot be negative");
        }
        
    }




    //TODO: trigger autofishers from here
    //SKILL LVL increase handler updates autofish
    //
}
