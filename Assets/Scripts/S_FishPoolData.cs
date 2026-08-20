using UnityEngine;
using System.Collections.Generic;

public class S_FishPoolData : MonoBehaviour
{
    List<(string nameID, int tier)> _approvedDifficultyPool = new();
    List<(string nameID, int tier)> _tier0fish =new();
    List<(string nameID, int tier)> _tier1fish = new();
    List<(string nameID, int tier)> _tier2fish = new();


    public List<(string nameID, int tier)> ApprovedDifficultyPool => _approvedDifficultyPool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //todo, not rlly gonna use this below part...
    public void CreateFilteredDifficultyPools(List<(string nameID, int tier)> approvedDifficultyPool)
    {
        _approvedDifficultyPool = approvedDifficultyPool;

        for(int i = 0; i < _approvedDifficultyPool.Count; i++)
        {
           if(_approvedDifficultyPool[i].tier == 0){
            _tier0fish.Add(_approvedDifficultyPool[i]);
            }
            else if(_approvedDifficultyPool[i].tier == 1){
            _tier0fish.Add(_approvedDifficultyPool[i]);
            }
            else if(_approvedDifficultyPool[i].tier == 2){
            _tier0fish.Add(_approvedDifficultyPool[i]);
            }
        }
    }
}
