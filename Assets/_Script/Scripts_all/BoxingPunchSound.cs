using UnityEngine;

public class BoxingPunchSound : MonoBehaviour
{
    public void PunchSound()
    {
        SFX_Manager.PlaySound(SFX_Manager.Instance.BoxingPunch);
    }
}
