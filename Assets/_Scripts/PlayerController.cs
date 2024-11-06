using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _velocity = 5;

    [SerializeField]
    float _jumpForce = 5;

    [SerializeField]
    Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 input = (new Vector3(Input.GetAxis("Horizontal") * _velocity, _rigidbody.velocity.y, Input.GetAxis("Vertical") * _velocity));
        AddVelocity(input);

        if (Input.GetButtonDown("Fire1"))
            Jump();

    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce,ForceMode.Impulse);
    }

    public void AddVelocity(Vector3 velocity)
    {

        _rigidbody.velocity = velocity;

    }
}
