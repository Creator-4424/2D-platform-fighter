using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float speed = 40f;
    public float HorizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed",Mathf.Abs(HorizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }
    void FixedUpdate()
    {
        controller.Move(HorizontalMove*Time.fixedDeltaTime, crouch, jump);
    }
}
