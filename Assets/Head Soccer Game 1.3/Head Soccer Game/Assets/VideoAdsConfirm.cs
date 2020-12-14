using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoAdsConfirm : MonoBehaviour
{
    public GameController gameController = null;
    private float buttonAnimationSpeed = 9;
    public PauseManager pauseManager = null;
    public GameObject GameFinishPlane;

    private void OnEnable()
    {
        pauseManager.PauseGame(false);
    }

    private void Update()
    {
        StartCoroutine(tapManager());
    }

    private RaycastHit hitInfo;
    private Ray ray;
    private IEnumerator tapManager()
    {
        //Mouse of touch?
        if (Input.touches.Length > 0 && Input.touches[0].phase == TouchPhase.Ended)
            ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
        else if (Input.GetMouseButtonUp(0))
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        else
            yield break;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject objectHit = hitInfo.transform.gameObject;
            switch (objectHit.name)
            {

                case "Btn-Yes":
                    pauseManager.UnPauseGame(false);
                    StartCoroutine(animateButton(objectHit));
                    yield return new WaitForSeconds(0.25f);     //Wait for the animation to end
                    PlayVideoAds();
                    break;

                case "Btn-No":
                    pauseManager.UnPauseGame(false);
                    StartCoroutine(animateButton(objectHit));
                    yield return new WaitForSeconds(0.25f);
                    this.gameObject.SetActive(false);
                    GameFinishPlane.SetActive(true);
                    break;
            }
        }
    }

    private void PlayVideoAds()
    {
#if !UNITY_EDITOR

        if (GameSystem.Instance.adMobManager.adMobVideoAds.IsLoaded())
        {
            AdMob.AdMobManager.AdMobVideoAds.onVideoRewarded = (GoogleMobileAds.Api.Reward r) =>
            {
                GameController.gameTime += GameSystem.Instance.gameTimeBonus;
                this.gameObject.SetActive(false);
                GameController.gameIsFinished = false;
                gameController.gameFinishFlag = false;
            };
            GameSystem.Instance.adMobManager.adMobVideoAds.ShowRewardVideoAds();
        }
        else
        {
            GameSystem.Instance.adMobManager.adMobVideoAds.RequestRewardVideoAds();
        }
#else
        GameController.gameTime += GameSystem.Instance.gameTimeBonus;
                    this.gameObject.SetActive(false);
                    GameController.gameIsFinished = false;
                    gameController.gameFinishFlag = false;
#endif
    }

    private IEnumerator animateButton(GameObject _btn)
    {
        Vector3 startingScale = _btn.transform.localScale;  //initial scale	
        Vector3 destinationScale = startingScale * 1.1f;    //target scale

        //Scale up
        float t = 0.0f;
        while (t <= 1.0f)
        {
            t += Time.deltaTime * buttonAnimationSpeed;
            _btn.transform.localScale = new Vector3(Mathf.SmoothStep(startingScale.x, destinationScale.x, t),
                                                    Mathf.SmoothStep(startingScale.y, destinationScale.y, t),
                                                    _btn.transform.localScale.z);
            yield return 0;
        }

        //Scale down
        float r = 0.0f;
        if (_btn.transform.localScale.x >= destinationScale.x)
        {
            while (r <= 1.0f)
            {
                r += Time.deltaTime * buttonAnimationSpeed;
                _btn.transform.localScale = new Vector3(Mathf.SmoothStep(destinationScale.x, startingScale.x, r),
                                                        Mathf.SmoothStep(destinationScale.y, startingScale.y, r),
                                                        _btn.transform.localScale.z);
                yield return 0;
            }
        }

    }


    //*****************************************************************************
    // Play sound clips
    //*****************************************************************************
    void playSfx(AudioClip _clip)
    {
        GetComponent<AudioSource>().clip = _clip;
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
