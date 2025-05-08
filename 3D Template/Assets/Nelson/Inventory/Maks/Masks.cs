using UnityEngine;

public class Masks : MonoBehaviour
{
    public string MaskName;
    
    public virtual void ApplyAffects()
    {
        Debug.Log("Eto");
    }

    public virtual void UnapplyAffects()
    {

    }

    private void Start()
    {
        ApplyAffects();
    }
}
