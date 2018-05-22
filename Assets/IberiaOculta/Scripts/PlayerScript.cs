using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

    public float speed;
    public Vector2 jumpHeight;
    public bool facingRight;
    public bool touchingGround;

    public Animator anim;

    private void Start()
    {
        jumpHeight = new Vector2(0, 5);
        speed = 5f;
        facingRight = true;
        touchingGround = true;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w") && touchingGround)
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
            if (!facingRight)
                Rotate();
            anim.SetBool("PlayerWalk", true);
            pos.x += speed * Time.deltaTime;
            

        }
        else if (Input.GetKey("a"))
        {
            if (facingRight)
                Rotate();
            anim.SetBool("PlayerWalk", true);
            pos.x -= speed * Time.deltaTime;
            
        }
        else
        {
            anim.SetBool("PlayerWalk", false);
        }


        transform.position = pos;
    }


    void Rotate()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
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