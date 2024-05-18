using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public Transform check_transform;
    public Animator check_anim;
    float timer = 0;
    bool trig=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trig)
        {
            if(timer==1)
            {
                check_anim.SetBool("Check", true);
            }
            if (timer >= 250)
            {
                check_anim.SetBool("flag_On", true);
                timer = 0;
            }
            timer++;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            trig = true;
        }
    }
}
