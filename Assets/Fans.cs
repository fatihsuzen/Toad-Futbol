using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fans : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomAnim", Random.Range(0, 3), Random.Range(5,15));
    }
    
    void RandomAnim()
    {
        GetComponent<Animator>().SetInteger("Status",Random.Range(0,5));
    }
}
