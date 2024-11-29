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

    public float DistanceToGround = 0.1f;
    public LayerMask GroundLayer;
    private CapsuleCollider _col;

    public GameObject Bullet;
    public GameObject bulletSpawn;
    public float BulletSpeed = 100f;
    private bool _isShooting;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        /* CollectionBase = GetComponent<CapsuleCollider>;*/
        _col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        isjumping |= Input.GetKeyDown(KeyCode.J);
        /*        this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
                this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);*/

        _isShooting |= Input.GetKeyDown(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        Vector3 rotarion = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotarion * Time.fixedDeltaTime);
        rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * angleRot);

        if (isjumping && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
        isjumping = false;

        if (_isShooting){
            GameObject newBullet = Instantiate(Bullet, bulletSpawn.transform.position + new Vector3(0, 0, 1),bulletSpawn.transform.rotation);

            Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();

            BulletRB.velocity = this.transform.forward * BulletSpeed;
        }

        _isShooting = false;
    }
    private bool IsGrounded()
    {
        
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, DistanceToGround, GroundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }
}

