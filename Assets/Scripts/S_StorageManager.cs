using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_StorageManager : MonoBehaviour
{
    //private List<(string nameID, int tier)> inventory;
    //[SerializeField] private int maxStorage = 10;
    [SerializeField] S_StorageBox[] storageBoxes;
    [SerializeField] int startUnlockedBoxes;


    void Start()
    {
        for(int i = 0; i< startUnlockedBoxes; i++)
        {
            storageBoxes[i].UnlockBox();
        }
    }


    public void UnlockBox()
    {
        bool boxUnlocked = false;

        //if there are anyboxes to unlock then we can check for first locked box and unlock it

        if (!storageBoxes[storageBoxes.Length - 1].isUnlocked)
        {
            for(int i = 0; i< storageBoxes.Length; i++)
            {
                //look for first empty storage box
                if(storageBoxes[i].isUnlocked == false && boxUnlocked == false)
                {
                    storageBoxes[i].UnlockBox();
                    boxUnlocked = true;
                }
            }
        }
    }

    public void AddFish((string nameID, int tier) fish)
    {
        bool fishAdded = false;
        for(int i = 0; i< storageBoxes.Length; i++)
        {
            //look for first empty storage box
            if(storageBoxes[i].isEmpty == true  && storageBoxes[i].isUnlocked == true && fishAdded == false)
            {
                storageBoxes[i].AddFish(fish);
                fishAdded = true;
            }
        }
        
    }
}

