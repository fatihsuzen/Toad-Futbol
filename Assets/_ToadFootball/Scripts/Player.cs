using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public static int Money;
    public static int Fans;
    public Text MoneyText;
    public Text FansText;
    void Start()
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
