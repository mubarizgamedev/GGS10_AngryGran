using UnityEngine;
using System.Collections;

public class CatDie : MonoBehaviour
{
    [SerializeField] Animator catAnimator;
    [SerializeField] GameObject parentCat;
    public float disableAfterDie;
    public void ChangeState()
    {
        catAnimator.SetBool("Die", true);
        SFX_Manager.PlaySound(SFX_Manager.Instance.catCrySound);
        Debug.Log("Cat animator state changed to Die");
    }

    public void SetActiveFalse()
    {
        StartCoroutine(DisableAfterDelay());
    }

    private IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(9f);
        parentCat.SetActive(false);
    }

}
