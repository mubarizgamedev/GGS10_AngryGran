using UnityEngine;

public class new_AD_Call : MonoBehaviour
{
    public bool AdoptiveBanner;
    public bool MedRec;


    void OnEnable()
    {

        // Top Ad
        if (AdoptiveBanner == true)
        {
            LoadShowTopBanner();
        }

        // Medium Rectangle Ad
        if (MedRec == true)
        {
            if(AdmobAdsManager.Instance)
            if (AdmobAdsManager.Instance.Skip_MedRec)
            {
                return;
            }
            MedBanner();
        }
        loAd();
    }
    void OnDisable()
    {

        if (MedRec == true)
        {
            if (AdmobAdsManager.Instance)
                AdmobAdsManager.Instance.hideMediumBanner();
        }

        if (AdoptiveBanner == true)
        {
            if (AdmobAdsManager.Instance)
                AdmobAdsManager.Instance.hideSmallBanner();
        }
    }


    //ADOPTIVE BANNER AD
    void loAd()
    {
        if(AdmobAdsManager.Instance)
        if (AdmobAdsManager.Instance.Skip_MedRec)
        {
            return;
        }
        LoadShowTopBanner();
    }



    void LoadShowTopBanner()
    {
        if (AdmobAdsManager.Instance)
        {
            if (!AdmobAdsManager.Instance.IsSmallBannerReady())
            {
                TopBanner();
            }
            else
            {
                AdmobAdsManager.Instance.ShowSmallBanner();
            }
        }
    }

    //MEDIUM RECTANGLE AD
    void TopBanner()
    {
        if (!AdmobAdsManager.Instance.IsSmallBannerReady())
        {
            AdmobAdsManager.Instance.LoadSmallBanner();
            Invoke(nameof(trry), 3f);
        }
        else
        {
            AdmobAdsManager.Instance.ShowSmallBanner();
        }
    }
    void trry()
    {
        LoadShowTopBanner();
    }

    void MedBanner()
    {
        if (AdmobAdsManager.Instance)
            if (AdmobAdsManager.Instance.Internet == true)
            {
                if (AdmobAdsManager.Instance.Skip_MedRec)
                {
                    return;
                }
                AdmobAdsManager.Instance.ShowMediumBanner();
            }
    }



    //INTERSTITIAL
    public void Btn_Int_Call()
    {
        if (AdmobAdsManager.Instance.Skip_Int)
        {
            return;
        }
        if (AdmobAdsManager.Instance)
            AdmobAdsManager.Instance.ShowInterstitial();
    }
}