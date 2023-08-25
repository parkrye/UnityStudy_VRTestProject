using UnityEngine;
using UnityEngine.InputSystem;

public class PlanetMove : MonoBehaviour
{
    [SerializeField] Transform planet;
    [SerializeField] Rigidbody player;

    [SerializeField] float gravity;
    [SerializeField] bool isFar;
    [SerializeField] Vector3 upVector, localPrevRotation;
    [SerializeField] Quaternion lookRotation;

    private void Update()
    {
        upVector = player.transform.position - planet.position;
        lookRotation = Quaternion.FromToRotation(player.transform.up, upVector.normalized) * player.transform.rotation;
        localPrevRotation = player.transform.localEulerAngles;
        isFar = (Vector3.Distance(player.transform.position, planet.position) > planet.localScale.y * 0.5f + 2f);

    }

    private void FixedUpdate()
    {
        if(isFar)
            player.AddForce(gravity * -upVector, ForceMode.Force);
        player.transform.rotation = lookRotation;
        player.transform.localEulerAngles = new Vector3(player.transform.localEulerAngles.x, localPrevRotation.y, player.transform.localEulerAngles.z);
    }
}
