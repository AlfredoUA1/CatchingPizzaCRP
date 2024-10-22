using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer;
    public GameObject pizza;

    //Creates an Array (like a list) of Vector3's
    public Vector3[] locations;

    public float score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //Every second, spawn a pizza at one of my locations randomly (put locations in the Inspector)
        //And rotate it to 60 degrees
        if(timer > 1)
        {
            Instantiate(pizza, locations[Random.Range(0, locations.Length)], Quaternion.Euler(0, 0, 60));
            timer = 0;
        }
    }
}
