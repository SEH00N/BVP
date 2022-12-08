using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Movement movement = null;
    private PlayerRotator rotator = null;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        rotator = GetComponent<PlayerRotator>();
    }

    private void Update()
    {
        MovementInput();
        JumpInput();
        RotateInput();
    }

    private void RotateInput()
    {
        float x = Input.GetAxis("Mouse Y");
        float y = Input.GetAxis("Mouse X");
        
        rotator.HeadRotateTo(x);
        rotator.BodyRotateTo(y);
    }

    [SerializeField] bool onJump = false;
    private void JumpInput()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !onJump)
            movement.DoJump();
    }

    private void MovementInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement.MoveTo(new Vector3(horizontal, 0, vertical));
    }
}
