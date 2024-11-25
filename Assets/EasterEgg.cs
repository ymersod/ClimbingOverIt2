using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform easterEgg;
    [SerializeField] CharacterController characterController;
    [SerializeField] Rigidbody playerRb;
    [SerializeField] XROrigin xrOrigin;

    public void TeleportToEasterEgg()
    {
        StartCoroutine(Hehehe());
    }

    private IEnumerator Hehehe()
    {
        yield return new WaitForSeconds(2f);
        var destination = easterEgg.position + new Vector3(0, 10, 0);

        player.position = destination;
    }
}
