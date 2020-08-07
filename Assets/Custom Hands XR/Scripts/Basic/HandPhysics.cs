using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandPhysics : MonoBehaviour
{
    public float smoothingAmout = 15f;
    public Transform target = null;

    private Rigidbody rigidBody;
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        TeleportToTarget();
    }

    private void Update()
    {
        SetTargetPosition();
        SetTargetRotation();
    }

    private void SetTargetPosition()
    {
        float time = smoothingAmout * Time.unscaledDeltaTime;
        targetPosition = Vector3.Lerp(targetPosition, target.position, time);
    }

    private void SetTargetRotation()
    {
        float time = smoothingAmout * Time.unscaledDeltaTime;
        targetRotation = Quaternion.Slerp(targetRotation, target.rotation, time);
    }

    private void FixedUpdate()
    {
        MoveToController();
        RotateToController();
    }

    private void MoveToController()
    {
        Vector3 positionDelta = targetPosition - transform.position;
        rigidBody.velocity = Vector3.zero;
        rigidBody.MovePosition(transform.position + positionDelta);
    }

    private void RotateToController()
    {
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.MoveRotation(targetRotation);
    }

    public void TeleportToTarget()
    {
        targetPosition = target.position;
        targetRotation = target.rotation;

        transform.position = targetPosition;
        transform.rotation = targetRotation;
    }
}
