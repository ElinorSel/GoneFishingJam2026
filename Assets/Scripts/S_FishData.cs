using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_FishData : MonoBehaviour
{
    
    [SerializeField] public SO_Fish[] rawData;
    public Dictionary<string, SO_Fish> data = new();

    
    public static S_FishData Instance { get; private set; }



    private Dictionary<int, List<(string nameID, int tier)>> difficultyPools = new();
    private S_FishPoolData fishPool;

    void Awake()
    {
         if (Instance != null && Instance != this)
        {
            Debug.LogError("Multiple VisualizationSettings instances found!");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        fishPool = gameObject.AddComponent<S_FishPoolData>();
        ImportData();
        CreateDifficultyPools();
        //TestPoolSkillcheck();
        //TestGetFishValue();
        
    }



    void ImportData()
    {
        foreach( SO_Fish fishSO in rawData)
        {
            data[fishSO.nameID] = fishSO;
        }
    }

    void DebugData()
    {
        foreach(var key in data.Keys)
        {
            Debug.Log("Loaded data: " +  key + data[key]);
        }
    }

    void TestPoolSkillcheck()
    {
        List<(string nameID, int tier)> result = new();
        result = GetApprovedDifficultyPool(0);
        foreach((string nameID, int tier) item in result)
        { 
            Debug.Log(item.nameID + " Tier: " + item.tier);
        }
    }

    void TestGetFishValue()
    {
       Debug.Log( GetFishPassiveIncome("Shrimp", 2));

    }

    void DebugDificultyPool()
    {
        foreach(KeyValuePair<int,List<(string nameID, int tier)>> item in difficultyPools)
        {
            
            Debug.Log("Difficulty" + item.Key + " Fishes:");
            foreach((string, int) fish in item.Value){
            Debug.Log(fish);
            }
        }
    }

    void CreateDifficultyPools()
    {
        // add fish into pools based on difficulty
        foreach(var fish in data.Keys)
        {
            for(int i = 0; i < data[fish].tier.Length; i++)
            {
                int currentFishDifficulty = data[fish].difficulty[i];

                //null check
                if (!difficultyPools.ContainsKey(currentFishDifficulty))
                {
                    difficultyPools[i] = new List<(string nameID, int tier)>(); 
                }
                
                difficultyPools[currentFishDifficulty].Add((fish, data[fish].tier[i]));
            }
        }
    }

    //GM will call at start, and when skill lvl updates
    public S_FishPoolData GetFishPool(int skillLvl)
    {
        fishPool.CreateFilteredDifficultyPools(GetApprovedDifficultyPool(skillLvl));
        return fishPool;
    }

    //makes 1 long list of all possible fishes to get based on skill lvl
    public List<(string nameID, int tier)> GetApprovedDifficultyPool(int skillLvl)
    {
        List<(string nameID, int tier)> approvedDifficultyPools = new();
        for(int i = 0; i <= skillLvl; i++)
        {
            approvedDifficultyPools.AddRange(difficultyPools[i]);
        }
        return approvedDifficultyPools;
    } 

    public float GetFishPassiveIncome(string nameID, int tierValue)
    {
        return data[nameID].passiveIncome[tierValue];
    }
        public float GetFishSellPrice(string nameID, int tierValue)
    {
        return data[nameID].sellPrice[tierValue];
    }

    

}
