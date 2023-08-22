using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OnlyDirectInterator : MonoBehaviour
{
    [SerializeField] Renderer rndr;
    [SerializeField] Material before, after;
    public void OnDirectInteracteEnter(HoverEnterEventArgs args)
    {
        if (args.interactorObject.transform.TryGetComponent(out LineRenderer _))
            return;
        rndr.material = after;
    }

    public void OnDirectInteracteExit(HoverExitEventArgs args)
    {
        if (args.interactorObject.transform.TryGetComponent(out LineRenderer _))
            return;
        rndr.material = before;
    }
}
