using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fans : MonoBehaviour
{
    public List<GameObject> FanList = new List<GameObject>();
    public List<GameObject> FanSlot = new List<GameObject>();
    int fanPiece=10;
    void Start()
    {
        SpawnFan();
        //InvokeRepeating("RandomAnim", Random.Range(0, 3), Random.Range(5,15));
    }
    
    void RandomAnim()
    {
        //GetComponent<Animator>().SetInteger("Status",Random.Range(0,5));
    }
    public void SpawnFan()
    {
        for (int i = 0; i < fanPiece; i++)
        {
            int rnd = Random.Range(0, FanSlot.Count);
            Instantiate<GameObject>(FanList[Random.Range(0, FanList.Count)], FanSlot[rnd].transform.position, Quaternion.Euler(FanSlot[rnd].transform.rotation.x, FanSlot[rnd].transform.rotation.y+180, FanSlot[rnd].transform.rotation.z));
        }
    }
}
