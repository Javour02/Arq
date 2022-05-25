using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estante : MonoBehaviour
{
    [SerializeField] float distancia;
    [SerializeField] GameObject planta;
    Animator myAnim;
    bool isColliding;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, distancia, LayerMask.GetMask("Player"));
        Debug.DrawLine(transform.position, Vector2.down * distancia, Color.red);
        isColliding = (ray.collider != null);
        Shoot();
    }

    void Shoot()
    {
        if (isColliding)
        {
            Instantiate(planta, new Vector2(transform.position.x + 1f, transform.position.y + 0.3f), transform.rotation);
            myAnim.SetTrigger("shoot");
            Destroy(this);
        }
    }
}
