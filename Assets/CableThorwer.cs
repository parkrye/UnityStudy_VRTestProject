using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class CableThorwer : MonoBehaviour
{
    [SerializeField] bool isSelected, isShot;
    [SerializeField] GameObject cable;
    [SerializeField] Transform socketTransform;
    [SerializeField] float power;
    [SerializeField] IXRSelectInteractor interactor;

    public void SelectEnter(SelectEnterEventArgs args)
    {
        if(args.interactableObject.transform.gameObject == cable)
        {
            isSelected = true;
            interactor = args.interactorObject;
        }
    }

    public void SelectExit(SelectExitEventArgs args)
    {
        if (!isShot)
        {
            interactor.transform.gameObject.SetActive(true);
            isSelected = false;
            interactor = null;
        }
    }

    void OnPrimaryButton()
    {
        if (!isShot && isSelected)
        {
            isShot = true;
            interactor.transform.gameObject.SetActive(false);
            cable.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.Impulse);
            if(interactor != null)
            {
                interactor.transform.gameObject.SetActive(true);
                isSelected = false;
                interactor = null;
            }
            isShot = false;
        }
        else
        {
            cable.SetActive(false);
            cable.transform.position = socketTransform.position;
            cable.SetActive(true);
        }
    }
}
