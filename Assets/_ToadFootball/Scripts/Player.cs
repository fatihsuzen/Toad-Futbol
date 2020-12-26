using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int Money;
    public static int Fans;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMoney(int money)
    {
        Money += money;
    }
    public void SetFans(int fans)
    {
        Fans += fans;
    }
}
