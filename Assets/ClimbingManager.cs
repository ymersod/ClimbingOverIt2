using UnityEngine;

public class ClimbingManager : MonoBehaviour
{
    [SerializeField] GameObject RightHandThingy;
    [SerializeField] GameObject LeftHandThingy;
    [SerializeField] GameObject RightHandClimbing;
    [SerializeField] GameObject LeftHandClimbing;
    private int nrActive = 0;
    public void ActiveClimbing()
    {
        RightHandClimbing.SetActive(true);
        LeftHandClimbing.SetActive(true);
        RightHandThingy.SetActive(false);
        LeftHandThingy.SetActive(false);
        nrActive++;
    }

    public void DeactiveClimbing()
    {
        nrActive--;
        if(nrActive == 0) {
            RightHandClimbing.SetActive(false);
            LeftHandClimbing.SetActive(false);
            RightHandThingy.SetActive(true);
            LeftHandThingy.SetActive(true);
        }
    }
}
