using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Perita : MonoBehaviour
{
    Rigidbody2D mybody;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    Animator myAnim;
    BoxCollider2D myCollider;
    bool wall;
    float jumpLogic;
    bool isGrounded;
    int aspect;
    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myCollider = GetComponent<BoxCollider2D>();
        SetAspect(ChoosingFruit.aspect);
    }

    private void SetAspect(int aspect)
    {
        myAnim.SetLayerWeight(aspect, 1);
        switch (aspect)
        {
            case 1:
                myCollider.size = new Vector2(1.12f, 2.027162f);
                jumpLogic = 1.12f;
                break;
            case 2:
                myCollider.size = new Vector2(1.3f, 1.7f);
                jumpLogic = 1.3f;
                break;
            case 3:
                myCollider.size = new Vector2(1.6f, 1.4f);
                jumpLogic = 1.6f;
                break;
            default:
                jumpLogic = 1.308716f;
                break;
        }
    }

    IEnumerator MiCorutina2()
    {
        Time.timeScale = 0;
        float FirstTime = Time.realtimeSinceStartup + 1f;
        while (Time.realtimeSinceStartup < FirstTime)
        {
            yield return 0;
        }
        Debug.Log("LLegue");
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D rayleft = Physics2D.Raycast(new Vector2(transform.position.x-(jumpLogic/2), transform.position.y), Vector2.down, 1.1f, LayerMask.GetMask("Piso"));
        RaycastHit2D rayright = Physics2D.Raycast(new Vector2(transform.position.x + (jumpLogic/2), transform.position.y), Vector2.down, 1.1f, LayerMask.GetMask("Piso"));
        Debug.DrawRay(new Vector2(transform.position.x + (jumpLogic/2), transform.position.y), Vector2.down* 1.1f, Color.red);
        Debug.DrawRay(new Vector2(transform.position.x - (jumpLogic/2), transform.position.y), Vector2.down * 1.1f, Color.red);

        Debug.Log("Colisionando con ");
        isGrounded = (rayleft.collider != null || rayright.collider != null);
        Jump();
    }

    void Jump()
    {
        if (isGrounded && !myAnim.GetBool("isJumping"))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                myAnim.SetBool("isJumping", true);
                mybody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
        if (mybody.velocity.y != 0 && !isGrounded)
        {
            myAnim.SetBool("isJumping", true);
        }
        else myAnim.SetBool("isJumping", false);

    }

    private void FixedUpdate()
    {
        if (wall)
        {
            mybody.velocity = new Vector2(0, mybody.velocity.y);
        } else {
            float dirH = Input.GetAxis("Horizontal");
            if (dirH != 0)
                {
                    mybody.velocity = new Vector2(dirH * speed, mybody.velocity.y);
                    myAnim.SetBool("isRunning", true);
                    if (dirH < 0)
                    {
                        transform.localScale = new Vector2(1, 1);
                        //transform.eulerAngles = new Vector2(0, 180);
                    }
                    else
                    {
                        transform.localScale = new Vector2(-1, 1);
                    }
            }
            else
            {
                myAnim.SetBool("isRunning", false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            myAnim.SetTrigger("die");
            StartCoroutine(MiCorutina2());
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!isGrounded && collision.gameObject.layer == 3)
        {
            wall = false;
            Debug.Log(wall);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isGrounded && collision.gameObject.layer == 3)
        {
            wall = true;
            Debug.Log(wall);
        }
    }
}
