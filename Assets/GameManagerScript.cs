using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject gameOverText;
    private bool GameOverFlag = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
        float x = Random.Range(-3.0f, 3.0f);
        Instantiate(enemy,new Vector3(x,0,10),Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームオーバーなら
        if (GameOverFlag==true)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("TitleScene");
            }
            
        }
    }

    void FixedUpdate()
    {
        if (GameOverFlag == true) return;

        int r = Random.Range(0,50);
        if (r == 0)
        {
            float x = Random.Range(-3.0f, 3.0f);
            Instantiate(enemy, new Vector3(x, 0, 15), Quaternion.identity);
        }
    }

    public void GameOverStart()
    {
        GameOverFlag= true;
        gameOverText.SetActive(true);
    }
    public bool IsGameOver()
    {
        return GameOverFlag;
    }

}
