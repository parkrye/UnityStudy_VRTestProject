using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class Climber : MonoBehaviour
{
    [SerializeField] Transform climbTransform;
    [SerializeField] CharacterController characterController;
    [SerializeField] LocomotionSystem locomotionManager;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        locomotionManager = GetComponentInChildren<LocomotionSystem>();
    }

    private void FixedUpdate()
    {
        if(climbTransform != null)
        {
            locomotionManager.enabled = false;
            if (Vector3.Distance(climbTransform.position, transform.position) > 0.1f)
            {
                characterController.Move((climbTransform.position - transform.position).normalized * Time.fixedDeltaTime);
                Debug.Log((climbTransform.position - transform.position).normalized);
            }
        }
        else
        {
            locomotionManager.enabled = true;
            characterController.Move(Vector3.down * Time.fixedDeltaTime);
        }
    }

    public void OnSelect(Transform t)
    {
        climbTransform = t;
    }

    public void OffSelect()
    {
        climbTransform = null;
    }
}
