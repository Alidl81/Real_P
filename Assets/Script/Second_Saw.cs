using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_Saw : MonoBehaviour
{
    public Transform saw_transform;
    public Animator animator;

    public float speed=0.1f;
    private bool t;
    private bool left;
    private bool right;
    private bool up;
    // Start is called before the first frame update
    void Start()
    {
        //37.9
        //38.5
    }

    // Update is called once per frame
    void Update()
    {
        if (saw_transform.position.x <= 38.45)
        {
            up = true;
            
        }
        else if (saw_transform.position.x >= 39)
        {
            right = false;
            left = true;
        }

        if (t)
        {
            if (left)
            {
                
                animator.SetBool("on", true);
                saw_transform.position = new Vector3(saw_transform.position.x - speed * Time.deltaTime, -1.9f, 1);

            }

            if (right)
            {
                
                animator.SetBool("on", true);
                saw_transform.position = new Vector3(saw_transform.position.x + speed * Time.deltaTime, -1.9f, 1);

            }
            if (up)
            {
                saw_transform.position = new Vector3(saw_transform.position.x + speed * Time.deltaTime, -1.9f, 1);

            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            t = true;
        }
    }
}
