using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public CharacterController CharacterController;
    public Animator Animator;
    public Sprite DeadCat;
    public Sprite JumpCat;
    public Sprite IdleCat;


    public float runSpeed = 40f;
    private float horizontalMove = 0f;
    private bool jump = false;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        CatAliveControl();
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
        Animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        JumpControl();
    }

    private void FixedUpdate() {
        CharacterController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    private void CatAliveControl() {
        if (transform.position.y <= -3.66) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = DeadCat;
        }
    }

    private void JumpControl() {
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
    }
}
