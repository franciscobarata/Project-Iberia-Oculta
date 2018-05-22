using UnityEngine;
using System.Collections;

public class SpikesText : MonoBehaviour
{

    private bool displayText = false;

    public Vector2 rect = new Vector2(475, 115);

    private void Update()
    {
        if (GetComponent<BoxCollider2D>().IsTouching(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>()))
        {
            //Debug.Log("Touch the ground\n");
            displayText = true;
        } else
        {
            displayText = false;
        }
    }

    void OnGUI()
    {
        if (displayText == true) {
            Vector2 pos = GameObject.FindGameObjectWithTag("Player").transform.position;
            GUI.contentColor = Color.black;
            GUI.Label(new Rect(rect.x, rect.y, 250, 50), "The fields of war... I need a weapon!");
        }
    }
 } 
