using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Carieer : MonoBehaviour
{
    public List<string> Teams = new List<string>();
    public List<Text> TeamVersus = new List<Text>();
    public List<Text> TeamSlot = new List<Text>();
    public List<Text> TeamPointSlot = new List<Text>();
    public int[] Number = new int[12];
    int Temp;
    void Start()
    {
        Versus();
    }    
    void Versus()
    {
        for (int i = 0; i < TeamVersus.Count; i++)
        {
            TeamVersus[i].text = Teams[Random.Range(0, Teams.Count)];
        }
    }
    void PointRanking()
    {
        for (int i = 0; i < Teams.Count; i++)
        {
            TeamSlot[i].text = Teams[i];
            //TeamPointSlot[i].text = "0";//playerpref.getstring(Teams)
        }
        for (int i = 0; i < 10; i++)
        {
            for (int j = i + 1; j < 10; j++)
            {
                if (Number[j] < Number[i])
                {
                    Temp = Number[i];

                    Number[i] = Number[j];

                    Number[j] = Temp;
                }
            }
        }
        for (int i = 0; i < TeamPointSlot.Count; i++)
        {
            TeamPointSlot[i].text = Number[i].ToString();
        }
    }
}
