using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fans : MonoBehaviour
{
    public List<GameObject> FanList = new List<GameObject>();
    void Start()
    {
        //InvokeRepeating("RandomAnim", Random.Range(0, 3), Random.Range(5,15));
    }
    
    void RandomAnim()
    {
        //GetComponent<Animator>().SetInteger("Status",Random.Range(0,5));
    }
}
