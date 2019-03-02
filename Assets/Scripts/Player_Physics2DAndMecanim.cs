using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Physics2DAndMecanim : MonoBehaviour
{
    public float speed = 12.0f;
    public float jumpPower = 30.0f;
    bool grounded;
    public static bool goalCheck;
    public static float goalTime;
    int jumpCount = 2;
    public GameObject go;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "NPC_Hime")
        {
            goalCheck = true;
            go.SetActive(true);
        }

        if (collision.gameObject.name.Contains("Fence"))
        {
            // UnityEngine.SceneManagement.SceneManager.LoadScene("StageA");
            transform.position = new Vector3(-6.2f, -0.7f, 0.0f);
        }

    }

    void Start()
    {
        grounded = false;
        goalCheck = false;
        goalTime = 0;
        jumpCount = 0;
    }
    

    void Update()
    {
        Transform groundCheck = transform.Find("GroundCheck");
        
        if (Physics2D.OverlapPoint(groundCheck.position) != null)
        {
            grounded = true;
            jumpCount = 1;
        }

        if (grounded)
        {
            if (jumpCount > 0)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpPower;// AddForce(new Vector2(0.0f, jumpPower));
                    jumpCount--;
                }
            }
        }
        if(jumpCount == 1)
        {
            GetComponent<Animator>().SetTrigger("Run");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Jump");
        }

        if (transform.position.y < -10.0f)
        {
            //UnityEngine.SceneManagement.SceneManager.LoadScene("StageA");
            transform.position = new Vector3(-6.2f, -0.7f, 0.0f);
        }
    }

   

    void FixedUpdate()
    {
        GameObject goCam = GameObject.Find("Main Camera");
        GameObject snow = GameObject.Find("Snow");
        if (!goalCheck)
        {
            goalTime += Time.deltaTime;
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
            snow.transform.position = new Vector3(transform.position.x + 1.0f, snow.transform.position.y, snow.transform.position.z);
            goCam.transform.position = new Vector3(
                transform.position.x + 5.0f, goCam.transform.position.y, goCam.transform.position.z);
        }
    }
}
