using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class EnemyScript : MonoBehaviour
{
    private GameObject gameManager;
    private GameManagerScript gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();
        Destroy(gameObject, 12);
        if (gameManagerScript.IsGameOver() == true)
        {
            return;
        }
        transform.rotation = Quaternion.Euler(0, 180, 0);
        int r = Random.Range(0, 2);
        if (r == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180-30,0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180+30, 0);
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 2.0f;
        if (gameManagerScript.IsGameOver() == true)
        {
            return;
        }
        Vector3 velocity = new Vector3(0,0,moveSpeed*Time.deltaTime);
        transform.position += transform.rotation * velocity;

        if(transform.position.x>4)
        {
            transform.rotation = Quaternion.Euler(0,180+30,0);
        }
        if(transform.position.x<-4) 
        {
            transform.rotation = Quaternion.Euler(0, 180-30, 0);
        }
    }
}
