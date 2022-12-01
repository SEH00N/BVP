using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Movement movement = null;
    public bool a = false;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        MovementInput();
        JumpInput();
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

        if(a)
            transform.Translate(new Vector3(horizontal, 0, vertical) * Time.deltaTime * 10f);
        else
            movement.MoveTo(new Vector3(horizontal, 0, vertical));
    }
}
