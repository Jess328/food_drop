using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFood : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
      
    }
    private void OnTriggerEnter(Collider other)
    {        
            if (other.gameObject.tag == "Player")
            {
                Destroy(gameObject);
                CreateFood.Score += 10;
            }
            if (other.gameObject.tag == "DownBorder")
            {
                Destroy(gameObject);
                CreateFood.YourLife -= 1;
            }
        
    }
}
