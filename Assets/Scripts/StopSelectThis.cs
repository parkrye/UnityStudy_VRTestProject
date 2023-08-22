using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StopSelectThis : MonoBehaviour
{
    public void OnActivated(ActivateEventArgs args)
    {
        StartCoroutine(Drop(args.interactorObject.transform.gameObject));
    }

    IEnumerator Drop(GameObject go)
    {
        go.SetActive(false);
        yield return new WaitForSeconds(1f);
        go.SetActive(true);
    }
}
