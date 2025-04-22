using UnityEngine;

public class Masks : MonoBehaviour
{
    public string MaskName;
    
    public virtual void ApplyAffects()
    {
        Debug.Log("Communists & Fascist are cultrue vultures");
    }

    private void Start()
    {
        ApplyAffects();
    }
}
