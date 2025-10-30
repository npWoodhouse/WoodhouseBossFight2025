using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class HeadRotation : MonoBehaviour
{
    private PlayerInput playerInput;
    public Rigidbody RB;
    private Vector2 lookVector;
    private Vector2 moveVector;

    public GameObject neck;
    private float movespeed = 8.0f;
    private float jumpforce = 400f;
    private float dashdorce = 400f;

    private bool canDash = true;
    private bool canJump = true;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        RB = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookVector = playerInput.actions["Look"].ReadValue<Vector2>();
        moveVector = playerInput.actions["Move"].ReadValue<Vector2>();

        neck.transform.rotation = Quaternion.Euler(0, euler_angle(-lookVector.x, lookVector.y), 0);
        transform.position += new Vector3(moveVector.x * Time.deltaTime * movespeed, 0, moveVector.y * Time.deltaTime * movespeed);


        if (playerInput.actions["Dash"].triggered)
        {
            dash();
        }

        if (playerInput.actions["Jump"].triggered)
        {
            jump();
        }
    }

    float euler_angle(float x, float y)
    {
        float rad = Mathf.Atan(y / x);   // arcus tangent in radians
        float deg = rad * 180 / Mathf.PI;  // converted to degrees
        if (x < 0) deg += 180;        // fixed mirrored angle of arctan
        float eul = (270 + deg) % 360;    // folded to [0,360) domain
        return eul;
    }

    void dash()
    {
        if (canDash)
        {
            Vector3 Impulse = new Vector3(moveVector.x, 0, moveVector.y);
            RB.AddForce(Impulse * dashdorce, ForceMode.Impulse);
            canDash = false;
            StartCoroutine(DashCoolDown());
        }
    }

    IEnumerator DashCoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        canDash = true;
    }

    void jump()
    {
        if (canJump)
        {
            Vector3 impulse = new Vector3(0, 1, 0);
            RB.AddForce(impulse * jumpforce, ForceMode.Impulse);
            canJump = false;
            StartCoroutine(JumpCoolDown());
        }
    }

    IEnumerator JumpCoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        canJump = true;
    }
}
