using UnityEngine;

public class ClimbActivatedHandTracker : MonoBehaviour
{
    [SerializeField] GameObject correspondingHand;
    [SerializeField] Transform target;

    void Update()
    {
        if(!correspondingHand.activeSelf) UpdateHandPos();
    }

    void UpdateHandPos(){
        transform.position = target.position;
    }

    public void ClimbingActivated()
    {
        correspondingHand.SetActive(false);
    }

    public void ClimbingDeactivated()
    {
        correspondingHand.SetActive(true);
    }
}
