using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public Transform saw_transform;
    public Animator animator;
    
    public float speed;
    private bool t; 
    private bool left; 
    private bool right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (saw_transform.position.x <= 0)
        {
            right = true;
            left = false;
        }
        else if (saw_transform.position.x >= 5)
        {
            right = false;
            left = true;
        }

        if (t)
        {
            if (left)
            {
                //-1.9f
                animator.SetBool("on", true);
                saw_transform.position = new Vector3(saw_transform.position.x - speed * Time.deltaTime, -1.9f,1);
                
            }

            if (right)
            {
                //-2.5f
                animator.SetBool("on", true);
                saw_transform.position = new Vector3(saw_transform.position.x + speed * Time.deltaTime, -1.9f, 1);
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            t=true;
        }
    }
}
