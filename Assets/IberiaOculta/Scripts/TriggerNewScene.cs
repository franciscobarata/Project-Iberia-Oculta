using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerNewScene : MonoBehaviour
{

    public string scene;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Collider2D>().IsTouching(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>()) && Input.GetKey("w"))
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
}
