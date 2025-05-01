using UnityEngine;

public class Masks : MonoBehaviour
{
    public string MaskName;
    
    public virtual void ApplyAffects()
    {
        Debug.Log("Eto");
    }

    private void Start()
    {
        ApplyAffects();
    }
}
