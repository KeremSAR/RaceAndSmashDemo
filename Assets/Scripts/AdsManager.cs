using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour,IUnityAdsListener
{
    private string playStoreID = "3876955";
    private string appStorID = "3876954";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    public bool isTargetPlayStore;
    public bool isTestAd;

    private void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvirtisement();
    }

    private void InitializeAdvirtisement()
    {
        if (isTargetPlayStore)
        {
            Advertisement.Initialize(playStoreID,isTestAd); 
            return;
        }
        Advertisement.Initialize(appStorID,isTestAd);
    }

    public void PlayInterstitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd))
        {
            return;
        }
        Advertisement.Show(interstitialAd);
    }

    public void PlayRewardedVideoAd()
    {
        if (!Advertisement.IsReady(rewardedVideoAd))
        {
            return;
        }
        Advertisement.Show(rewardedVideoAd);
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // todo mute the audio for our game because it runs with the ads audio
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if (placementId==rewardedVideoAd)
                {
                    Debug.Log("reward the player");
                }

                if (placementId==interstitialAd)
                {
                    Debug.Log("reward the player");
                }
                break;
            
        }
    }
}