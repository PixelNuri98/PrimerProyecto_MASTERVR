using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float vInput;
    public float hInput;
    private Rigidbody rb;
    public float jumpVelocity = 5f;
    private bool isjumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       /* CollectionBase = GetComponent<CapsuleCollider>;*/
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        isjumping |= Input.GetKeyDown(KeyCode.J); 
/*        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);*/
    }

    private void FixedUpdate()
    {
        Vector3 rotarion = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotarion * Time.fixedDeltaTime);
        rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * angleRot);

        if (isjumping)
        {
            rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
        isjumping = false;
    }

/*    private bool InGround()
    {
        Vector3 capsuleBottom col.bounds.min.y, col.bounds.center.z);
    }*/
}

