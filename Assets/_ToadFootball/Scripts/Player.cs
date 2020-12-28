using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public static int Money = 5;
    public static int Fans = 5;
    public static int Gems = 5;
    public Text MoneyText;
    public Text FansText;
    public Text GemsText;

    private void Awake()
    {
        Load();

        MoneyUpdate(); 
        FansUpdate();
       
    }
    void Start()
    {
        if (SceneManager.sceneCount==0)
        {
            GemsUpdate();
        }      
    }
    public void SetMoney(int money)
    {
        Money += money;
    }
    public void SetFans(int fans)
    {
        Fans += fans;
    }
    public void SetGems(int gems)
    {
        Gems += gems;
    }
    public void MoneyUpdate()
    {
        MoneyText.text = Money.ToString();
    }
    public void FansUpdate()
    {
        FansText.text = Fans.ToString();
    }
    public void GemsUpdate()
    {
        GemsText.text = Gems.ToString();
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
