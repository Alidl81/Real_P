using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player_Transform;
    public BoxCollider2D player_colider;
    public Rigidbody2D player_Rigid;
    public Animator player_anim;
    public ParticleSystem blood_partic;
    private Vector2 checkpoint;
    public Transform start_pos;
    public float player_speed;
    public float jump_Speed;
    public bool isGround;
    public bool isdead=false;
    public Camera camCamera;
    public Transform camPos;
    float d_timer=0;
    public bool change_view = false;

    void Start()
    {
        checkpoint = start_pos.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isdead)
        {
            player_anim.SetBool("Run", false);
            //walk
            if (Input.GetKey(KeyCode.D))
            {
                player_anim.SetBool("Run", true);
                player_Transform.position = new Vector2(player_Transform.position.x + player_speed * Time.deltaTime, player_Transform.position.y);
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (Input.GetKey(KeyCode.A))
            {
                player_anim.SetBool("Run", true);
                player_Transform.position = new Vector2(player_Transform.position.x - player_speed * Time.deltaTime, player_Transform.position.y);
                GetComponent<SpriteRenderer>().flipX = true;
            }



            if (Input.GetKey(KeyCode.RightArrow))
            {
                player_anim.SetBool("Run", true);
                player_Transform.position = new Vector2(player_Transform.position.x + player_speed * Time.deltaTime, player_Transform.position.y);
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                player_anim.SetBool("Run", true);
                player_Transform.position = new Vector2(player_Transform.position.x - player_speed * Time.deltaTime, player_Transform.position.y);
                GetComponent<SpriteRenderer>().flipX = true;
            }


            //run
            if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                player_anim.SetBool("Run", true);
                player_Transform.position = new Vector2(player_Transform.position.x + (player_speed + 0.5f) * Time.deltaTime, player_Transform.position.y);
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                player_anim.SetBool("Run", true);
                player_Transform.position = new Vector2(player_Transform.position.x - (player_speed + 0.5f) * Time.deltaTime, player_Transform.position.y);
                GetComponent<SpriteRenderer>().flipX = true;
            }



            if (Input.GetKey(KeyCode.RightArrow))
            {
                player_anim.SetBool("Run", true);
                player_Transform.position = new Vector2(player_Transform.position.x + player_speed * Time.deltaTime, player_Transform.position.y);
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                player_anim.SetBool("Run", true);
                player_Transform.position = new Vector2(player_Transform.position.x - player_speed * Time.deltaTime, player_Transform.position.y);
                GetComponent<SpriteRenderer>().flipX = true;
            }


            //jump

            if (Input.GetKey(KeyCode.Space))
            {
                if (isGround)
                {
                    player_Rigid.velocity = new Vector2(player_Rigid.velocity.x, jump_Speed);
                    player_anim.SetBool("Jump", true);
                }
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (isGround)
                {
                    player_Rigid.velocity = new Vector2(player_Rigid.velocity.x, jump_Speed);
                    player_anim.SetBool("Jump", true);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (isdead)
        {

            player_anim.SetBool("Die", true);
            if (d_timer == 5)
            {
                blood_partic.Play();
            }
            if (d_timer == 50)
            { 
                player_Transform.position = checkpoint;
                isdead = false;
                d_timer = 0;
            }
            d_timer++;
        }
        else
        {
            player_anim.SetBool("Die", false);
        }
        
        if(change_view)
        {
            camCamera.orthographicSize = 4.5f;

        }
        else
        {
            camCamera.orthographicSize = 2.5f;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {


        if (other.gameObject.tag == "Ground")
        {

            isGround = true;
            player_anim.SetBool("Jump", false);

        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {

            isGround = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            isdead = true;
        }
        if (other.CompareTag("flag"))
        {
            checkpoint=other.gameObject.transform.position;
        }
        if (other.CompareTag("ChangeVeiw"))
        {
            change_view = true;
        }
        if (other.CompareTag("End"))
        {
            print("hpooooora");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ChangeVeiw"))
        {
            change_view = false;
        }
    }
}
