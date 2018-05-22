using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehaviour : MonoBehaviour
{

    public float speed;

    public float distance;

    public Vector3 direction;

    // Use this for initialization
    void Start()
    {
        speed = 3.0f;
        distance = 2.5f;
        direction = Vector3.right;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        int layerMask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, layerMask);
        
        if (hit.collider != null)
        {
            direction = -direction;
            Rotate();
        }
    }

    void Rotate()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
