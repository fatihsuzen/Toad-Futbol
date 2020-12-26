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
        Load();
    }
    public void SetMoney(int money)
    {
        Money += money;
    }
    public void SetFans(int fans)
    {
        Fans += fans;
    }
    public void MoneyUpdate()
    {
        MoneyText.text = Money.ToString();
    }
    public void FansUpdate()
    {
        FansText.text = Fans.ToString();
    }
    public void Save()
    {
        //save money
        //save fans
    }
    public void Load()
    {
        //Load money
        //Load fans
    }
}
