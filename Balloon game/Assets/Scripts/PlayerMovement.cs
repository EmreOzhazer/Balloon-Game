using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    private static PlayerMovement instance;

    public event EventHandler OnDead;

    public float speed = 250;
    public Rigidbody rb;
    // Start is called before the first frame update

    float horizontalInput;
    float verticalInput;
    public bool isDead;

    private void Awake()
    {
        instance = this;
        rb = transform.GetComponent<Rigidbody>();
        isDead = false;
    }


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

        if(isDead == true)
        {
            Die_Static();
        }
    }


    private void Die()
    {
        isDead = true;
        rb.velocity = Vector3.zero;
        if (OnDead != null) OnDead(this, EventArgs.Empty);
    }


    public static void Die_Static()
    {
        instance.Die();
        GameOverWindow.Show();
        //int finalScore = Coin.coinCount + LevelGenerator.GetLevelPartsSpawned();
        //HighscoreNameInputWindow.Show(finalScore, (string name) => {
        //    HighscoreTable.AddHighscoreEntry_Static(finalScore, name);
        //    HighscoreTable.Show();
        //});
        HighscoreTable.Show();
    }
}
