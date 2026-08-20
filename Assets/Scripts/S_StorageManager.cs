using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

public class S_StorageManager : MonoBehaviour
{
    //private List<(string nameID, int tier)> inventory;
    [SerializeField] private int maxStorage = 15;
    public S_StorageBox[] StorageBoxes {get; private set;}
    [SerializeField] int startUnlockedBoxes;

    [SerializeField] S_GameManager gameManager;


    public event Action<int> OnBoxUnlocked;
    public event Action<int> OnFishAdded;
     public event Action<int> OnFishRemoved;


    void Awake()
    {
        StorageBoxes = new S_StorageBox[maxStorage];

        for(int i = 0; i< StorageBoxes.Length; i++)
        {
            S_StorageBox newBox = new();
            StorageBoxes[i] = newBox;
            if(i< startUnlockedBoxes)
            {
                
                StorageBoxes[i].UnlockBox();
            }
        }
    }


    public void UnlockBox()
    {
        bool boxUnlocked = false;

        //if there are anyboxes to unlock then we can check for first locked box and unlock it

        if (!StorageBoxes[StorageBoxes.Length - 1].isUnlocked)
        {
            for(int i = 0; i< StorageBoxes.Length; i++)
            {
                //look for first empty storage box
                if(StorageBoxes[i].isUnlocked == false && boxUnlocked == false)
                {
                    StorageBoxes[i].UnlockBox();
                    Debug.Log("Unlocking Box" + i);
                    OnBoxUnlocked?.Invoke(i);
                    boxUnlocked = true;
                    return;
                }
            }
        }
    }

    public void AddFish((string nameID, int tier) fish)
    {
        bool fishAdded = false;
        for(int i = 0; i< StorageBoxes.Length; i++)
        {
            //look for first empty storage box
            if(StorageBoxes[i].isEmpty == true  && StorageBoxes[i].isUnlocked == true && fishAdded == false)
            {
                StorageBoxes[i].AddFish(fish);
                Debug.Log("This fish is added to storage: " + i + " "+ StorageBoxes[i]._fish);
                OnFishAdded?.Invoke(i);
                fishAdded = true;
                return;
            }
        }
        
    }

    public void RemoveAllFish()
    {
        for(int i = 0; i< StorageBoxes.Length; i++)
        {
            (string name, int tier) fish = StorageBoxes[i]._fish;
            gameManager.HandleSellFish(fish.name, fish.tier);
            StorageBoxes[i].RemoveFish();
            OnFishRemoved?.Invoke(i);
        }
    }

        public void KeepAllFish()
    {
        for(int i = 0; i< StorageBoxes.Length; i++)
        {
            (string name, int tier) fish = StorageBoxes[i]._fish;
            gameManager.HandleAddFish(fish.name, fish.tier);
            StorageBoxes[i].RemoveFish();
            OnFishRemoved?.Invoke(i);
        }
    }


}

