using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class door : MonoBehaviour
{
    Animator animator;
    [SerializeField] int level;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator MiCorutina()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level"+ level);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            animator.SetTrigger("open");
            StartCoroutine(MiCorutina());
        }
    }
}
