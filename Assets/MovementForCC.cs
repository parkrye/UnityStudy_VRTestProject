using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class MovementForCC : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] Transform cameraTransform;

    private void FixedUpdate()
    {
        characterController.Move((cameraTransform.position - transform.position).normalized * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        cameraTransform.position = characterController.transform.position;
    }
}
