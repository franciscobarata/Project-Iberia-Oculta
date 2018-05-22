using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour {

    public float speed;

    public float distance;

    public Vector3 direction;

    public float degreesPerSecond = 15.0f;
    public float amplitude = 5.5f;
    public float frequency = 1f;

    // Position Storage Variables
    Vector3 tempPos = new Vector3();
    Vector3 posOffset = new Vector3();
    // Use this for initialization
    void Start()
    {
        speed = 10.0f;
        distance = 10.0f;
        direction = Vector3.right;

        // Store the starting position & rotation of the object
        posOffset = transform.position;

        InvokeRepeating("Rotate", distance, distance);
    }

    // Update is called once per frame
    void Update()
    {
        // Float up/down with a Sin()
        tempPos.x = transform.position.x;
        tempPos.y = posOffset.y;

        tempPos.x += speed * Time.deltaTime * direction.x;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }

    void Rotate()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        direction = -direction;
    }
}
