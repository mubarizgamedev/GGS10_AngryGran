using UnityEngine;

public class CatHandsMatSelector : MonoBehaviour
{
    [Header("Assign 3 Materials")]
    public Material[] catMaterials; // Make sure size is 3 in Inspector

    private void Start()
    {
        ApplySelectedMaterial();
    }
    private void OnEnable()
    {
        ApplySelectedMaterial();
    }
    void ApplySelectedMaterial()
    {
        // Safety checks
        if (catMaterials == null || catMaterials.Length < 3)
        {
            
            return;
        }

        if (!PlayerPrefs.HasKey("SelectedCatIndex"))
        {
            
        }

        int index = PlayerPrefs.GetInt("SelectedCatIndex", 0); // Default to 0 if not set
        index = Mathf.Clamp(index, 0, catMaterials.Length - 1); // Clamp to valid range

        SkinnedMeshRenderer smr = GetComponent<SkinnedMeshRenderer>();

        if (smr == null)
        {
            return;
        }

        // Copy current materials
        Material[] currentMaterials = smr.materials;

        // Replace only the first material
        currentMaterials[0] = catMaterials[index];

        // Apply back
        smr.materials = currentMaterials;
    }
}
