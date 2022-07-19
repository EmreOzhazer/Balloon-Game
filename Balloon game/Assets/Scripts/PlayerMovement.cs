using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 250;
    public Rigidbody rb;
    // Start is called before the first frame update

    float horizontalInput;
    float verticalInput;

    private void FixedUpdate()
    {
        Vector3 upMove = transform.up * speed * Time.fixedDeltaTime;

        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * 2;

        Vector3 verticalMove = transform.up * verticalInput * speed * Time.fixedDeltaTime * 2;

        rb.MovePosition(rb.position + upMove + horizontalMove + verticalMove);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
}
