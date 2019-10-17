using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{

    float gameTime;
    private bool stopTrigger = true;
    Coroutine lastRou = null;
    Text timeLimit;
    public GameObject enemy;
    private static GameManager1 _instance;
    public static GameManager1 Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameManager1>();
            }
            return _instance;
        }
    }
    [SerializeField]
    private Text healthTxt;
    [SerializeField]
    private GameObject panel;
    // Start is called before the first frame update
    public int health = 3;
    void Start()
    {
        //gameTime = 10.0f;
        timeLimit = GameObject.Find("Canvas").transform.Find("Time").GetComponent<Text>();
        healthTxt.text = "Health: "+ health.ToString("N0");
        //Startbtn = GameObject.Find("Canvas").transform.Find("Startbtn").GetComponent<Button>();
        //lastRou = StartCoroutine(CreateEnemyRoutine());
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit.text = gameTime.ToString("N2");
        
        if (gameTime <= 0.0f)
        {
            GameOver();
        }
        else
        {
            gameTime -= Time.deltaTime;
        }
    }
    
    private void GameOver()
    {
        stopTrigger = false;
        StopCoroutine(lastRou);
        panel.SetActive(true);
        gameTime = 0.0f;
        //health = 3;
    }
    public void StartGame()
    {
        gameTime = 10.0f;
        health = 3;
        lastRou = StartCoroutine(CreateEnemyRoutine());
        panel.SetActive(false);
    }
   
    IEnumerator CreateEnemyRoutine()
    {
        while (true) {
            respawnEnemy();
            yield return new WaitForSeconds(0.5f);
            
        }
    }

    void respawnEnemy()
    {
        float x = 7.0f;
        float y = 4.7f;

        int rand = Random.Range(0, 4);

        switch (rand)
        {
            case 0:
                CreateEnemy(-x, Random.Range(0.0f, y * 2) - y);
                break;
            case 1:
                CreateEnemy(x, Random.Range(0.0f, y * 2) - y);
                break;
            case 2:
                CreateEnemy(Random.Range(0.0f, x * 2) - x, y);
                break;
            case 3:
                CreateEnemy(Random.Range(0.0f, x * 2) - x, -y);
                break;
            default:
                break;
        }
    }
    private void CreateEnemy(float x, float y)
    {
        Instantiate(enemy, new Vector3(x,y,0), Quaternion.identity);
    }
    public void HealthDown()
    {
        healthTxt.text = "Health: " + health;
        if (health <= 0)
        {
            GameOver();
        }
        else
        {
            health--;
        }
    }
}
