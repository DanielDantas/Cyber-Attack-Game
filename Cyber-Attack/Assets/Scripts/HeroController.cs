using Pathfinding;
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

    private bool immobile = false;
    private float lastHit = 0;
    public float immobileTime;
    private bool fade = true;
    private bool fading = false;

    private WeaponController weaponController;


    public float runSpeed = 40f;
    private float horizontalMove = 0f;
    private bool jump = false;

    private bool gameOver = false;

    // Start is called before the first frame update
    private void Start() {
        if (gameObject != null) {
            weaponController = gameObject.GetComponent<WeaponController>();
        }
    }

    // Update is called once per frame
    private void Update() {
        if (Time.time - lastHit > immobileTime) {
            immobile = false;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        if (!gameOver) {
            if (!immobile) {
                horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
                Animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
                JumpControl();
                ShootControl();
                FallControl();
            } else {
                if (!fading) {
                    fading = true;
                    StartCoroutine(FadeImage(fade));
                }
            }
        }
    }

    IEnumerator FadeImage(bool fade) {
        // loop over 1 second backwards
        if (fade) {
            for (float i = 1; i >= 0; i -= Time.deltaTime) {
                // set color with i as alpha
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, i);
                if (!immobile)
                {
                    yield break;
                }
                yield return null;
            }
        } else {
            for (float i = 1; i >= 0; i -= Time.deltaTime) {
                // set color with i as alpha
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - i);
                if (!immobile)
                {
                    yield break;
                }
                yield return null;
            }

        }

        fade = !fade;
        fading = false;

    }

    private void FixedUpdate() {
        if (!immobile) {
            CharacterController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        }
        jump = false;
    }

    private void FallControl() {
        if(gameObject.transform.position.y <= -30f) {
            gameObject.transform.position = new Vector3(0, 0, 0);
            immobile = true;
        }
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
        immobile = false;
        gameOver = true;
    }

    public void SetLooser() {
        Animator.SetBool("Looser", true);
        immobile = false;;
        gameOver = true;
        CharacterController.Move(0f, false, true);
    }

    private void OnTriggerEnter2D(Collider2D otherObj) {
        Debug.Log("Hit by" + otherObj.gameObject.tag);
        if (otherObj.gameObject.tag == "Enemy") {
            immobile = true;
            lastHit = Time.time;
            Transform Cloud = GameObject.FindGameObjectWithTag("Cloud").transform;
            otherObj.gameObject.transform.parent.gameObject.GetComponent<AIDestinationSetter>().target = Cloud;
        }

    }

    /*private void OnTriggerEnter2D(Collider2D otherObj)
    {
        Debug.Log("Hit by trigger" + otherObj.gameObject.tag);
    }*/
}
