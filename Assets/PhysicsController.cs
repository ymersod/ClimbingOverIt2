using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PhysicsController : MonoBehaviour
{
    [Header("PID")] 
    [SerializeField] float frequency = 50f;
    [SerializeField] float damping = 1f;
    [SerializeField] float rotFrequency = 100f;
    [SerializeField] float rotDamping = 0.9f;
    [SerializeField] Rigidbody playerRigidbody;
    [SerializeField] TrackedPoseDriver target;
    [SerializeField] Transform target_transform;

    [Space] 
    [Header("Springs")] 
    [SerializeField] float climbForce = 1000f;
    [SerializeField] float climbDrag = 500f;

    Vector3 _previousPosition;
    Rigidbody _rigidbody;
    public bool _isColliding = false;    
    private float timer = 0f;
    void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = float.PositiveInfinity;
        transform.position = target_transform.position;
        transform.rotation = target_transform.rotation;
        _previousPosition = transform.position;
    }
    
    void FixedUpdate()
    {
        PIDMovement();
        PIDRotation();
        timer -= Time.fixedDeltaTime;
        if (_isColliding && timer <= 0) {
            HookesLaw();
        }
    }

    void PIDMovement()
    {
        float kp = (6f * frequency) * (6f * frequency) * 0.25f;
        float kd = 4.5f * frequency * damping;
        float g = 1 / (1 + kd * Time.fixedDeltaTime + kp * Time.fixedDeltaTime * Time.fixedDeltaTime);
        float ksg = kp * g;
        float kdg = (kd + kp * Time.fixedDeltaTime) * g;
        Vector3 force = (target_transform.position - transform.position) * ksg + (playerRigidbody.linearVelocity - _rigidbody.linearVelocity) * kdg;
        _rigidbody.AddForce(force, ForceMode.Acceleration);
    }

    void PIDRotation()
    {
        float kp = (6f * rotFrequency) * (6f * rotFrequency) * 0.25f;
        float kd = 4.5f * rotFrequency * rotDamping;
        float g = 1 / (1 + kd * Time.fixedDeltaTime + kp * Time.fixedDeltaTime * Time.fixedDeltaTime);
        float ksg = kp * g;
        float kdg = (kd + kp * Time.fixedDeltaTime) * g;
        Quaternion q  = target.rotationInput.action.ReadValue<Quaternion>() 
        * Quaternion.Inverse(transform.rotation);

        if (q.w < 0)
        {
            q.x = -q.x;
            q.y = -q.y;
            q.z = -q.z;
            q.w = -q.w;
        }
        q.ToAngleAxis(out float angle, out Vector3 axis);
        axis.Normalize();
        axis *= Mathf.Deg2Rad;
        Vector3 torque = ksg * axis * angle + -_rigidbody.angularVelocity * kdg;
        _rigidbody.AddTorque(torque, ForceMode.Acceleration);
    }

    void HookesLaw()
    {
        Vector3 displacementFromResting = transform.position - target_transform.position;

        Vector3 force = displacementFromResting * climbForce;
        float drag = GetDrag();
        
        playerRigidbody.AddForce(force, ForceMode.Acceleration);
        playerRigidbody.AddForce(drag * -playerRigidbody.linearVelocity * climbDrag, ForceMode.Acceleration);
    }

    float GetDrag()
    {
        Vector3 handVelocity = (target_transform.localPosition - _previousPosition) / Time.fixedDeltaTime;
        float drag = 1 / handVelocity.magnitude + 0.01f;
        drag = drag > 1 ? 1 : drag;
        drag = drag < 0.03f ? 0.03f : drag;
        _previousPosition = transform.position;
        return drag;
    }

    public void SetTimer()
    {
        timer = 1f;
    }

    // bool IsVelocityMaxDownward()
    // {
    //     Vector3 velocity = playerRigidbody.linearVelocity;
    //     float downwardSpeed = Mathf.Abs(velocity.y);

    //     return velocity.y < 0 && downwardSpeed > Mathf.Abs(velocity.x) && downwardSpeed > Mathf.Abs(velocity.z);
    // }
}
