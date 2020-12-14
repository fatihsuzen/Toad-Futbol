using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdMob.AdMobManager;

public class GameSystem : MonoBehaviour
{
    private static GameSystem ins = null;

    public AdMobManager adMobManager = null;

    public int showAdsCountMax = 2;
    public int showAdsCount = 0;
    public int gameTime = 90;
    public int gameTimeBonus = 15;

    public static GameSystem Instance
    {
        get
        {
            if(ins == null)
            {
                ins = new GameObject("GameSystem").AddComponent<GameSystem>();
                ins.Initailize();
                DontDestroyOnLoad(ins.gameObject);
            }
            return ins;
        }
    }

    private void Initailize()
    {
        adMobManager = new AdMobManager(new AdMobConfiguration() {
            Android_AppID = "",
            Android_BannerID = "ca-app-pub-3940256099942544/6300978111",
            Android_InterstitialID = "ca-app-pub-3940256099942544/1033173712",
            Android_VideoRewordID = "ca-app-pub-3940256099942544/5224354917",

            IOS_AppID = "",
            IOS_BannerID = "",
            IOS_InterstitailID = "",
            IOS_VideoRewordID = ""
        });

    }
}
