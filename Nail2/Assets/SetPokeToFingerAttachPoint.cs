using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class SetPokeToFingerAttachPoint : MonoBehaviour
{
    public Transform PokeAttachPoint;
    private XRPokeInteractor _xrPokeInteractor;
    void Start()
    {   
        _xrPokeInteractor=transform.parent.parent.GetComponentInChildren<XRPokeInteractor>();
        SetPokeAttachPoint();
        
    }

    void SetPokeAttachPoint()
    {
        if (PokeAttachPoint == null)
        {
            Debug.Log("Poke Attach point is null");
            return;
        }
        if (_xrPokeInteractor == null)
        {
            Debug.Log("XR Poke Interactor is null");
            return;
        }
        _xrPokeInteractor.attachTransform = PokeAttachPoint;
    }

}
