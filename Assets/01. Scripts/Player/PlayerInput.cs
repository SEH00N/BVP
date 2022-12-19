using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Movement movement = null;
    private PlayerRotator rotator = null;
    private Animator anim;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        rotator = GetComponent<PlayerRotator>();
        anim = GetComponent<Animator>();
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

    private void JumpInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            movement.DoJump();
    }

    private void MovementInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Speed",new Vector2(horizontal,vertical).magnitude);
        movement.MoveTo(new Vector3(horizontal, 0, vertical));
    }
}
