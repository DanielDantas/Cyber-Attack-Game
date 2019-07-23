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

    private WeaponController weaponController;


    public float runSpeed = 40f;
    private float horizontalMove = 0f;
    private bool jump = false;

    private bool gameWon = false;

    // Start is called before the first frame update
    private void Start()
    {
        if (gameObject != null) {
            weaponController = gameObject.GetComponent<WeaponController>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (!gameWon) {
            horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
            Animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
            JumpControl();
            ShootControl();
        } else {
            SetWinner();
        }
    }

    private void FixedUpdate() {
        CharacterController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    private void JumpControl() {
        if (Input.GetButtonDown("Jump")) {
            jump = true;
            Animator.SetBool("IsJumping", true);
        }
    }

    private void ShootControl() {
        if (Input.GetButtonDown("Fire1")) {
            Animator.SetBool("IsShooting", true);
            weaponController.Shoot();
        }

        if (Input.GetButtonUp("Fire1")) {
            Animator.SetBool("IsShooting", false);
        }
    }

    public void OnLanding() {
        Animator.SetBool("IsJumping", false);
    }

    public void SetWinner() {
        Animator.SetBool("Winner", true);
        gameWon = true;
    }

    public void SetLoose() {
        
    }
}
