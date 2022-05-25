using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef : MonoBehaviour
{
    Rigidbody2D mybody;
    [SerializeField] float speed;
    [SerializeField] float fireRate;
    [SerializeField] float knifeSpeed;
    [SerializeField] int aspect;
    Animator myAnim;
    bool isGrounded = true;
    bool move = true;
    bool isPlayer = false;
    bool changeDir = false;
    float starttime;
    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        starttime = Time.time;
        myAnim.SetLayerWeight(aspect, 1);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 1.3f, LayerMask.GetMask("Piso"));
        isGrounded = (ray.collider != null);
        
    }
    private void FixedUpdate()
    {
        changeDirection();
        if (changeDir)
        {
            transform.localScale = new Vector2(1, 1);
            if (move)
            {
                mybody.velocity = new Vector2(speed, mybody.velocity.y);
            }
            else
            {
                mybody.velocity = new Vector2(0, mybody.velocity.y);
            }
            RaycastHit2D throwKnife = Physics2D.Raycast(transform.position, Vector2.right, 8f, LayerMask.GetMask("Player"));
            Debug.DrawLine(transform.position, Vector2.right * 8f, Color.red);
            isPlayer = (throwKnife.collider != null);
            Shoot();
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
            if (move)
            {
                mybody.velocity = new Vector2(-speed, mybody.velocity.y);
            }
            else
            {
                mybody.velocity = new Vector2(0, mybody.velocity.y);
            }
            RaycastHit2D throwKnife = Physics2D.Raycast(transform.position, Vector2.left, 15f, LayerMask.GetMask("Player"));
            Debug.DrawLine(transform.position, Vector2.left * 15f, Color.red);
            isPlayer = (throwKnife.collider != null);
            Shoot();
        }
    }

    void changeDirection()
    {
        if (!isGrounded)
        {
            if (changeDir)
            {
                changeDir = false;
            }
            else
            {
                changeDir=true;
            }
        }
    }

    IEnumerator MiCorutina()
    {
        move = false;
        myAnim.SetBool("near", true);
        Debug.Log("Esperando para pasar de animación");
        yield return new WaitForSeconds(0.5f);
        move = true;
        myAnim.SetBool("near", false);
    }

    void Shoot()
    {
        if (isPlayer)
        {
            if ((starttime + fireRate) < Time.time)
            {
                Debug.Log("Hola");
                starttime = Time.time;
                //GameObject myKnife = Instantiate(knife, new Vector2(transform.position.x, transform.position.y-0.3f), transform.rotation);
                GameObject myKnife = KnifePool.Instance.RequestKnife();
                myKnife.transform.position = new Vector2(transform.position.x, transform.position.y - 0.3f);  
                myKnife.GetComponent<Knife>().Shoot(transform.localScale.x, knifeSpeed);
                StartCoroutine(MiCorutina());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer==8)
        {
            if (changeDir)
            {
                changeDir = false;
            }
            else
            {
                changeDir = true;
            }
        }
    }
}
