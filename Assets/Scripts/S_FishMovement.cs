using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class S_FishMovement : MonoBehaviour
{
         [Header(" boundary")]
    [SerializeField] float boundaryMaxX;
    [SerializeField] float boundaryMinX;
    [SerializeField] float boundaryMinY;
    [SerializeField] float boundaryMaxY;
    [SerializeField] float boundaryZ = 10.4f;

    [SerializeField] float speed; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SwimTowardNewTarget());
        
    }

    private IEnumerator SwimTowardNewTarget()
    {
        float randomWait = Random.Range(0,1);
        float randomSpeed = Random.Range(0.01f,0.06f);
        float boundaryX = Random.Range(boundaryMinX, boundaryMaxX);
        float boundaryY = Random.Range(boundaryMinY, boundaryMaxY);
        Vector3 swimtarget = new Vector3(boundaryX,boundaryY,boundaryZ);
        //transform.LookAt(swimtarget, new Vector3(0,1,0));

        while (Vector3.Distance(transform.position, swimtarget)>0.5f)
        {
            //yield return null;
            transform.position = Vector3.MoveTowards(transform.position, swimtarget, randomSpeed);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(randomWait);
        StartCoroutine(SwimTowardNewTarget());
        
    }

}
