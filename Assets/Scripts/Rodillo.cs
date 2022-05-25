using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rodillo : MonoBehaviour
{
    [SerializeField] float speed;
    Animator animator;
    Rigidbody2D mybody;
    BoxCollider2D mycollider;
    bool endRolling = true;
    int previous = 1;
    bool roll = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();
        mycollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator esperaGiro()
    {
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("rolling", false);
        roll = false;
        mycollider.size = new Vector2(0.96f, 2.666667f);
        yield return new WaitForSeconds(0.5f);
        if(previous == 1)
        {
            transform.localScale = new Vector2(-1,1);
            previous = 0;
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
            previous = 1;
        }
        endRolling = true;
    }

    private void FixedUpdate()
    {
        if (endRolling)
        {
            endRolling = false;
            roll = true;
            animator.SetBool("rolling", true);
            mycollider.size = new Vector2(0.96f, 0.96f);
            StartCoroutine(esperaGiro());
        }

        if (roll)
        {
            if(transform.localScale.x == 1)
            {
                mybody.velocity = new Vector2(speed, mybody.velocity.y);
            }
            else
            {
                mybody.velocity = new Vector2(-speed, mybody.velocity.y);
            }
            
        }
    }
}
