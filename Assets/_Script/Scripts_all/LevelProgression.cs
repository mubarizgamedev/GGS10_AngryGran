using UnityEngine;

public class LevelProgression : MonoBehaviour
{
    public string progressMessage;
    private void OnEnable()
    {
        if(AdmobAdsManager.Instance)
        if (AdmobAdsManager.Instance.Check_Firebase && Application.internetReachability != NetworkReachability.NotReachable)
        {
            Firebase.Analytics.FirebaseAnalytics.LogEvent(progressMessage);
        }
    }
}
