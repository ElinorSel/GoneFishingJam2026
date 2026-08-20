using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class S_AquariumVisuals : MonoBehaviour
{
     [Header("Spawn boundary")]
    [SerializeField] float spawnMaxX;
    [SerializeField] float spawnMinX;
    [SerializeField] float spawnMinY;
    [SerializeField] float spawnMaxY;
    [SerializeField] float spawnZ = 10.4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void SpawnFish(GameObject fishPrefab)
    {
        float spawnX = Random.Range(spawnMinX, spawnMaxX);
        float spawnY = Random.Range(spawnMinY, spawnMaxY);
    
        Instantiate(fishPrefab, new Vector3(spawnX,spawnY,spawnZ), fishPrefab.transform.rotation);

    }
}
