using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Vector3 leftDirection;
    public Vector3 rightDirection;

    public Vector3 jumpForce;
    public bool canJump;
    public bool doubleJump;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Transform>().position += leftDirection;
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Transform>().position += rightDirection;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (canJump == true)
            {
                canJump = false;
                GetComponent<Rigidbody2D>().AddForce(jumpForce);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //This code is so you can only jump when touching the floor
        if (collision.gameObject.tag == "Floor")
        {
            canJump = true;
            //doubleJump = true;
        }

        if(collision.gameObject.tag == "Pizza")
        {
            gameManager.score += 1;
            Destroy(collision.gameObject);
        }
    }
}
