using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    [SerializeField] GameObject puzzleUI;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<Hackable>(out Hackable taget))
        {
            puzzleUI.SetActive(true);
        }
    }
}
