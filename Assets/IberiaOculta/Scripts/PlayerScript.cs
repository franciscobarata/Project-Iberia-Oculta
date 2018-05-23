using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    public float speed;
    public Vector2 jumpHeight;
    public bool facingLeft;
    public bool touchingGround;

    public Animator anim;

    private void Start()
    {
        jumpHeight = new Vector2(0, 5);
        speed = 5f;
        facingLeft = false;
        touchingGround = true;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("space") && touchingGround)
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            touchingGround = false;
            Debug.Log("Jump\n");
        }
        //if (Input.GetKey("s"))
        //{
        //    pos.z -= speed * Time.deltaTime;
        //}
        if (Input.GetKey("d"))
        {
            if (facingLeft)
                Rotate();

            pos.x += speed * Time.deltaTime;
            anim.SetBool("PlayerWalk", true);
            

        }
        else if (Input.GetKey("a"))
        {
            if (!facingLeft)
                Rotate();

            pos.x -= speed * Time.deltaTime;
            anim.SetBool("PlayerWalk", true);
            
            
        }
        else
        {
            anim.SetBool("PlayerWalk", false);
        }

        transform.position = pos;
    }


    void Rotate()
    {
        facingLeft = !facingLeft;
        GetComponent<SpriteRenderer>().flipX = facingLeft;
    }

    private void LateUpdate()
    {
        //if (!touchingGround)
        //    anim.SetBool("PlayerWalk", false);
        if (GetComponent<Rigidbody2D>().IsTouching(GameObject.FindGameObjectWithTag("ground").GetComponent<Collider2D>()))
        {
            //Debug.Log("Touch the ground\n");
            touchingGround = true;
        }
    }
}