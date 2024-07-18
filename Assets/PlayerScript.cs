using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Animator animator;
    public Rigidbody rb;
    public GameObject bullet;
    private GameManagerScript gameManagerScript;
    public GameObject gameManager;
    float bulletTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
        animator = GetComponent<Animator>();
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 2.0f;
        float stageMax = 4.0f;

        if (gameManagerScript.IsGameOver() == true)
        {
            rb.velocity = new Vector3(0, 0, 0);
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(transform.position.x<stageMax)
            {
                rb.velocity = new Vector3(moveSpeed, 0, 0);
                animator.SetBool("walk", true);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(-moveSpeed, 0, 0);
            animator.SetBool("walk", true);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            animator.SetBool("walk", false);
        }

        

    }
    void FixedUpdate()
    {
        if (gameManagerScript.IsGameOver() == true)
        {
            return;
        }

        if (bulletTimer == 0.0f)
        {
            //’e”­ŽË
            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 position = transform.position;
                position.y += 0.8f;
                position.z += 1.0f;
                Instantiate(bullet, position, Quaternion.identity);
                bulletTimer = 1.0f;
            }
        }
        else
        {
            bulletTimer++;
            if(bulletTimer>20.0f)
            {
                bulletTimer = 0.0f;
            }
        }

        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            gameManagerScript.GameOverStart();
            
        }
    }
}
