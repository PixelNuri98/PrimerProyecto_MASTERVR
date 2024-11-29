using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    private float vInput;
    private float hInput;

    public float JumpVelocity = 5f;
    private bool _isJumping;

    private Rigidbody _rb;
    
    void Start()
    {
        
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        _isJumping |= Input.GetKeyDown(KeyCode.J);

    }

    void FixedUpdate()
    {
        
        Vector3 rotation = Vector3.up * hInput;
        
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput *
        Time.fixedDeltaTime);
        
        _rb.MoveRotation(_rb.rotation * angleRot);

        if (_isJumping)
        {
            
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }
        
        _isJumping = false;
    }

}



public class ItemBehavior : MonoBehaviour
{
    
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "Player")
        {
            
            Destroy(this.transform.gameObject);
            
            Debug.Log("Item collected!");
        }
    }
}


public class EnemyBehavior : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        
        if (other.name == "Player")
        {
            Debug.Log("Player detected - attack!");
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        
        if (other.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }
}


