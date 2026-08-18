using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine.InputSystem;

public class S_Aquarium : MonoBehaviour
{
    [SerializeField] float _passiveIncomeSpeed = 1f;
    [SerializeField] int _mergeThreshold = 3;
    [SerializeField] S_GameManager gameManager;
    [SerializeField] S_FishData fishData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("Spawn boundary")]
    [SerializeField] float spawnMaxX;
    [SerializeField] float spawnMinX;
    [SerializeField] float spawnMinY;
    [SerializeField] float spawnMaxY;
    [SerializeField] float spawnZ = 10.4f;

     private Dictionary<(string nameID, int tier), int> _fishCount = new();
     private List<S_Fish> _fishes = new();

    public float CurrentPassiveIncome {get; private set;}

    void Start()
    {
        CurrentPassiveIncome  = 0;
        StartCoroutine(PassiveIncome());
    }

    private IEnumerator PassiveIncome()
    {
        
        while(true) //TODO: only start when game is ready to start?
        {
            float income = 0;
            foreach((string nameID, int tier) fish in _fishCount.Keys)
            {
                income += fishData.GetFishPassiveIncome(fish.nameID,fish.tier);
                gameManager.AddMoney(fishData.GetFishPassiveIncome(fish.nameID,fish.tier));
            }
            //Debug.Log("Current money" + gameManager.Money);
            CurrentPassiveIncome = income;
            yield return new WaitForSeconds(_passiveIncomeSpeed);
        }
       
    }

      public void PassiveIncomeTest()
    {
        foreach((string nameID, int tier) fish in _fishCount.Keys)
        {
            gameManager.AddMoney(fishData.GetFishPassiveIncome(fish.nameID,fish.tier));
            Debug.Log(fishData.GetFishPassiveIncome(fish.nameID,fish.tier));
        }
        

        Debug.Log("Current money" + gameManager.Money);
       
    }

    public void AddFish( string nameID, int tier)
    {
       
         //instansiate the entry if it does not exist
        if (!_fishCount.ContainsKey((nameID, tier)))
        {
            _fishCount[(nameID, tier)] = 0;  
        }
        
        MergeCheck(nameID, tier);


        
        foreach(var key in _fishCount.Keys)
        {
            Debug.Log( key.nameID + " tier " + key.tier + " Count: " +_fishCount[key]);
        }
        Debug.Log("__________________________________");

        
        
        
    }


/*

    void SpawnFish()
    {
        float spawnX = Random.Range(spawnMinX, spawnMaxX);
        float spawnY = Random.Range(spawnMinY, spawnMaxY);
    
        Instantiate(fishData._aborrePrefabs[0], new Vector3(spawnX,spawnY,spawnZ), fishData._aborrePrefabs[0].transform.rotation);

    } 
*/
    void MergeCheck(string nameID, int tier)
    {
        //null check
        if (!_fishCount.ContainsKey((nameID, tier)))
        {
            _fishCount[(nameID, tier)] = 0;  
        }

        if(_fishCount[(nameID, tier)] > _mergeThreshold - 2 && (tier <= 2)) //max merge tier
        {
            _fishCount[(nameID, tier)] += 1; //add fish

            //if there is enough fish merge them into one fish of higher tier
            if(_fishCount[(nameID, tier)] % _mergeThreshold == 0)
            {
                //remove all fish
                _fishCount[(nameID, tier)] = 0;
                MergeCheck(nameID, tier+1);
            }
        }

        //add fish
        else
        {
            _fishCount[(nameID, tier)] += 1;
        }
    }
}
