using UnityEngine;
using UnityEngine.InputSystem;

public class HeadRotation : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector2 lookVector;
    private Vector2 moveVector;

    public GameObject neck;
    public float movespeed = 5.0f;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
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
        transform.position += new Vector3(moveVector.x*Time.deltaTime* movespeed, 0, moveVector.y*Time.deltaTime* movespeed);
    }

    float euler_angle(float x, float y)
    {
        float rad = Mathf.Atan(y / x);   // arcus tangent in radians
        float deg = rad * 180 / Mathf.PI;  // converted to degrees
        if (x < 0) deg += 180;        // fixed mirrored angle of arctan
        float eul = (270 + deg) % 360;    // folded to [0,360) domain
        return eul;
    }
}
