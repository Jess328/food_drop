using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateFood : MonoBehaviour
{
    public GameObject gameobject;
    private bool foodfalling;
    public int FoodSpeed = 3;
    private List<GameObject> objects = new List<GameObject>();
    public Text text1;
    public Text text2;
    public Text text3;
    public static bool gameOver;
    public static string HighScore;
    public static float Score;
    public static int YourLife;

    void Start()
    {
        YourLife = 3;
        Score = 0;
        gameOver = false;
        foodfalling=true;
        HighScore = PlayerPreferences.GetInt("Score", 0)

    }

    void Update()
    {
        if(gameOver == false){
            StartCoroutine(PerfectTime());
            foreach (GameObject obj in objects)
            {
                if (obj != null)
                {
                    obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z-(FoodSpeed*Time.deltaTime));
                }
            }
        }
        if (YourLife<=0)
        {
            gameOver=true;
        }
        if (gameOver == true)
        {
            text3.text = "GAME OVER";
            PlayerPreferences.StoreInt("Score", Score)  
            PlayerPreferences.GetInt("Score", 0)
        }
        text1.text = "Score: " + Score;
        text2.text = "Your Life: " + YourLife;

    }
    private void createFood()
    {
        if(foodfalling == true)
        {
              GameObject obj = Instantiate(gameobject, new Vector3(Random.Range(-6.9f,6.9f),gameObject.transform.position.y,3.8f),Quaternion.identity); 
              obj.GetComponent<Renderer>().material.color = Random.ColorHSV(0f,1f,1f,1f,0.5f,1f);
              objects.Add(obj);
              foodfalling = false;
        }
    }
    IEnumerator PerfectTime()
    {
        if (foodfalling == true)
        {
            createFood();
            yield return new WaitForSeconds(2f);      
            foodfalling = true;
        }
        
    }
}
