using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed = 250;
    public Rigidbody rb;
    public Transform player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
       // offset = transform.position - player.position;
    }
    private void FixedUpdate()
    {
        Vector3 upMove = transform.up * speed * Time.fixedDeltaTime;

        

        rb.MovePosition(rb.position + upMove );
    }
    // Update is called once per frame
    void Update()
    {
        //Vector3 targetPos = player.position + offset;
        //targetPos.x=0;
        //transform.position = player.position + offset;
    }
}
