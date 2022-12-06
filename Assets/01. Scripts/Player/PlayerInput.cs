using System.Collections;
using DG.Tweening;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] GameObject jumpEffect = null;

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
        {
            movement.DoJump(() => {
                onJump = true;
                jumpEffect.SetActive(true);
                jumpEffect.transform.DOScale(Vector3.zero, 0.4f).SetEase(Ease.Linear).OnComplete(() => {
                    jumpEffect.SetActive(false);
                    jumpEffect.transform.localScale = Vector3.one;
                    onJump = false;
                });
            });
        }
    }

    private void MovementInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement.MoveTo(new Vector3(horizontal, 0, vertical));
    }
}
