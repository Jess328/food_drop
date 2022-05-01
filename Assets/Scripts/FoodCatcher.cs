using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCatcher : MonoBehaviour
{
    public float keeperSpeed = 5;

    void Start()
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (Input.GetKey("a"))
        {
            gameObject.transform.position = new Vector3(transform.position.x - (keeperSpeed*Time.deltaTime), transform.position.y, transform.position.z);
        }
        if (Input.GetKey("d"))
        {
            gameObject.transform.position = new Vector3(transform.position.x + (keeperSpeed * Time.deltaTime), transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="LeftBorder")
        {
            gameObject.transform.position = new Vector3(-6.9f, transform.position.y, transform.position.z);
        }

        if (other.tag=="RightBorder")
        {
            gameObject.transform.position = new Vector3(6.9f, transform.position.y, transform.position.z);
        }
    }
}
