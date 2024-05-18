using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traps : MonoBehaviour
{
    public Transform trap_transform;
    public float first_loc=0;
    public float second_loc=0;
    public bool traped = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (traped)
        {
            if (trap_transform.position.y < 0)
            {
                if (trap_transform.position.y >= second_loc)
                    trap_transform.position = new Vector3(trap_transform.position.x, trap_transform.position.y - 0.01f, 1);
            }
            else
            {
                if (trap_transform.position.y <= second_loc)
                    trap_transform.position = new Vector3(trap_transform.position.x, trap_transform.position.y + 0.01f, 1);
            }
        }
        else
        {
            if (trap_transform.position.y < 0)
            {
                traped = false;
                if (trap_transform.position.y <= first_loc)
                    trap_transform.position = new Vector3(trap_transform.position.x, trap_transform.position.y + 0.01f, 1);
            }
            else
            {
                traped = false;
                if (trap_transform.position.y >= first_loc)
                    trap_transform.position = new Vector3(trap_transform.position.x, trap_transform.position.y - 0.01f, 1);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            traped = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            traped = false;
        }
    }

}
