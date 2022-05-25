using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    float dir;
    float speed;
    Animator myAnim;
    Rigidbody2D mybody;
    int salir = 0;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    IEnumerator MiCorutina()
    {
        yield return new WaitForSeconds(0.1f);
        myAnim.SetTrigger("time");
    }
    void Update()
    {
        transform.Translate(new Vector2(speed * dir, 0) * Time.deltaTime);
        if (salir == 0){
            salir++;
            StartCoroutine(MiCorutina());
        }
    }

    public void Shoot(float dir, float speed)
    {
        this.dir = -dir;
        this.speed = speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
