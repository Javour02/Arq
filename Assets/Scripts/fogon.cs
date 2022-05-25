using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogon : MonoBehaviour
{
    [SerializeField] GameObject fire;
    [SerializeField] float fireRate;

    float starttime;
    // Start is called before the first frame update
    void Start()
    {
        starttime = Time.time;
    }

    IEnumerator MiCorutina()
    {
        Debug.Log("Esperando para disparar");
        yield return new WaitForSeconds(1f);
        Instantiate(fire, new Vector2(transform.position.x, transform.position.y + 0.3f), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if ((starttime+fireRate)<Time.time)
        {
            starttime= Time.time;
            Instantiate(fire, new Vector2(transform.position.x, transform.position.y + 0.3f), transform.rotation);
        }
        
    }
}
