using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] MovementSO movementSO;
    [SerializeField] float rayDistance = 1.2f;

    private Rigidbody rb = null;

    private float currentVelocity = 0f;
    public float CurrentVelocity { get => currentVelocity; set => currentVelocity = value; }
    public bool onBoost = false;

    private Vector3 currentDir = Vector3.zero;
    private Vector2 CurrentPlaneVector => new Vector2(currentDir.x, currentDir.z);

    private int currentJumpCount = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(onBoost) return;
        
        Vector3 dir = ((currentDir.x * transform.right) + (currentDir.z * transform.forward)) * currentVelocity;

        dir.y = Mathf.Clamp(rb.velocity.y, movementSO.gravityClamp.x, movementSO.gravityClamp.y);
        rb.velocity = dir;
    }

    public void DoJump()
    {
        if(movementSO.maxJumpCount == 0) return;

        if(IsGround())
            currentJumpCount = 0;
        else if(++currentJumpCount >= movementSO.maxJumpCount)
           return;

        rb.AddForce(Vector3.up * movementSO.jumpSpeed, ForceMode.Impulse);
    }

    private bool IsGround() => Physics.Raycast(transform.position, Vector3.down, rayDistance, DEFINE.GroundLayer);

    public void MoveTo(Vector3 input)
    {
        input = input.normalized;
        Vector2 inputPlaneVector = new Vector2(input.x, input.z);

        if(inputPlaneVector.sqrMagnitude > 0f)
        {
            if(Vector2.Dot(inputPlaneVector, CurrentPlaneVector) < 0f)
                currentVelocity = 0f;

            currentDir = input;
        }

        if(!onBoost)
            currentVelocity = CalculateSpeed(input);
    }

    private float CalculateSpeed(Vector3 input)
    {
        float factor = input.sqrMagnitude > 0f ? movementSO.inAccel : -movementSO.deAccel;
        currentVelocity += factor * Time.deltaTime;

        return Mathf.Clamp(currentVelocity, 0, movementSO.maxSpeed);
    }

    public void DoStop()
    {
        currentVelocity = 0f;
        currentDir = Vector3.zero;
    }
}
