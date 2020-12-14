using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public Image loadingSlider = null;
    public GameSystem gameSystem = null;

    public void Start()
    {
        gameSystem = GameSystem.Instance;
        StartCoroutine(IELoading());
    }

    private IEnumerator IELoading()
    {
        loadingSlider.fillAmount = 0;
        while (loadingSlider.fillAmount < 1)
        {
            yield return new WaitForSeconds(0.02f);
            loadingSlider.fillAmount += 0.01f;
            if(loadingSlider.fillAmount >= 1)
            {
                Debug.Log("Load To Menu");
                SceneManager.LoadSceneAsync("Menu");
            }
        }
    }
}
