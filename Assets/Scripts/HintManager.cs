using UnityEngine;
using UnityEngine.Rendering;

public class HintManager : MonoBehaviour
{
    public GameObject[] diamondHints;
    public GameObject[] baloonHints;
    public GameObject[] keysHint;
    public GameObject[] TvHint;
    public GameObject[] GiftsHint;
    public GameObject[] ObjectHint;
    public GameObject[] ToysHint;

    string localText;

    private void Start()
    {
        TaskUI.OnHintRequested += ShowHint;
    }

    private void OnDestroy()
    {
        TaskUI.OnHintRequested -= ShowHint;
    }

    void ShowHint(string text)
    {
        localText = text;
        Rewad_.Instance.StartLoading(DoWork);
        
    }

    void DoWork()
    {
        Debug.Log(localText);
        if (localText == "Diamond")
        {
            ActiveHints(diamondHints, true);
        }
        else if (localText == "Baloon")
        {
            ActiveHints(baloonHints, true);
        }
        else if (localText == "Key")
        {
            ActiveHints(keysHint, true);
        }
        else if (localText == "Tv")
        {
            ActiveHints(TvHint, true);
        }
        else if (localText == "Gift")
        {
            ActiveHints(GiftsHint, true);
        }
        else if (localText == "Throw")
        {
            ActiveHints(ObjectHint, true);
        }
        else if (localText == "Toys")
        {
            ActiveHints(ToysHint, true);
        }
        else
        {
            Debug.LogWarning("No hints available for this text: " + localText);
        }
    }

    public void ActiveHints(GameObject[] gObjs, bool cond)
    {
        foreach (var hint in gObjs)
        {
            hint.SetActive(cond);
        }
    }
}
