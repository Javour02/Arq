using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fork : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    Rigidbody2D mybody;
    bool dir = true;
    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dir)
        {
            transform.localScale = new Vector2(1,1);
            mybody.velocity = new Vector2(speed, mybody.velocity.y);
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
            mybody.velocity = new Vector2(-speed, mybody.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            mybody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        if(collision.gameObject.layer == 8)
        {
            if (dir)
            {
                dir = false;
            }
            else
            {
                dir = true;
            }
        }
    }
}
