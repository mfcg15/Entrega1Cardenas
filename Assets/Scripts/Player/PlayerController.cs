using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rbPlayer;
    private float moveVertical, rotation = 70f;
    private bool isGrounded;

    public int lifePlayer = 15, gems = 0;
    public float jumpForce = 5f;
    public bool sword;
    [SerializeField] float speedPlayer = 5f, timeWait = 3f , timeWaitS = 3.3f, timeWin = 4f;
    [SerializeField] bool isDeath, isWin;
   
    void Start()
    {
        anim = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
       if(isWin == true)
       {
            anim.Play("Victory");
       }
       else
       {
            Move();
            Rotation();
       }
    }

    void Update()
    {

       if(isDeath==true)
       {
            if(sword == true)
            {
                timeWaitS -= Time.deltaTime;

                if (timeWaitS <= 0)
                {
                    Debug.Log("Game Over");
                    Debug.Break();
                }
            }
            else
            {
                timeWait -= Time.deltaTime;

                if (timeWait <= 0)
                {
                    Debug.Log("Game Over");
                    Debug.Break();
                }
            }
            
        }
       else
       {
            if(isWin == true)
            {
                anim.Play("Victory");
            }
            else
            {
                if(isGrounded)
                {
                    Abilities();
                }
                else
                {
                    anim.SetBool("isJump", false);
                }
            }      
       }

    }

    private void Move()
    {
        moveVertical = Input.GetAxis("Vertical");
        transform.Translate(0, 0, moveVertical * Time.deltaTime * speedPlayer);
        anim.SetFloat("SpeedY", moveVertical);
    }

    private void Rotation()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, Time.deltaTime * -(rotation), 0.0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0.0f, Time.deltaTime * rotation, 0.0f);
        }
    }

    private void Abilities()
    {
        Run();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            anim.SetBool("stayFloor", false);
        }

        Attack();
    }

    private void Run()
    {
        if (moveVertical != 0 && Input.GetKey(KeyCode.Z))
        {
            speedPlayer = 8f;
            rbPlayer.AddRelativeForce(Vector3.forward * speedPlayer * moveVertical, ForceMode.Force);
            anim.SetBool("isRun", true);

        }
        else
        {
            anim.SetBool("isRun", false);
            speedPlayer = 5f;
        }
    }

    private void Jump()
    {
        anim.SetBool("isJump", true);
        rbPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void Attack()
    {
        if (sword == true)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                anim.SetBool("isCut", true);
            }

            if (Input.GetKeyUp(KeyCode.X))
            {
                anim.SetBool("isCut", false);
            }
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.X))
            {
                anim.SetBool("isPunch", true);
            }

            if (Input.GetKeyUp(KeyCode.X))
            {
                anim.SetBool("isPunch", false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = true;
            anim.SetBool("stayFloor", true);
        }

        if(other.gameObject.tag == "Attack" || other.gameObject.tag == "AttackGoblin" || other.gameObject.tag == "AttackEnemy")
        {

            lifePlayer--;

            if (sword==true)
            {
                if (lifePlayer >= 1)
                {
                    anim.SetTrigger("isHitSword");
                }

                if (lifePlayer == 0)
                {
                    anim.SetTrigger("isDeathSword");
                    isDeath = true;
                }
            }
            else
            {
                if (lifePlayer >= 1)
                {
                    anim.SetTrigger("isHit");
                }

                if (lifePlayer == 0)
                {
                    anim.SetTrigger("isDeath");
                    timeWait = 5f;
                    isDeath = true;
                }

            }
            
        }

        if (other.gameObject.tag == "Finish")
        {
            if(gems == 40)
            {
                isWin = true;
                Debug.Log("¡¡¡ Has ganado !!!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = false;
            anim.SetBool("stayFloor", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
   {
        if (collision.gameObject.tag == "FloorMove")
        {
            transform.parent = collision.transform;
            isGrounded = true;
            anim.SetBool("stayFloor", true);
            jumpForce = 5f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "FloorMove")
        {
            isGrounded = false;
            anim.SetBool("stayFloor", false);
            transform.parent = null;
        }
    }

}
