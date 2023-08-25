using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Backpack : MonoBehaviour
{
    public void OnPacking(HoverEnterEventArgs args)
    {
        args.interactableObject.transform.GetComponent<MeshRenderer>().enabled = false;
    }
    
    public void UnPacking(HoverExitEventArgs args)
    {
        args.interactableObject.transform.GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<XRBaseControllerInteractor>(out var interactor))
        {
            interactor.SendHapticImpulse(1f, 1f);
        }
    }
}
