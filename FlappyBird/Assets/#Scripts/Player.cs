using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    Rigidbody2D rigid; // 사용할 리지드바디 컴포넌트
    Animator animator;
    public float jumpForce = 50; // 점프 힘
    public bool isDead = false; // 사망 상태
    public GameObject VFX;
    public GameObject VFX2;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isDead ==false)
        {
            animator.SetTrigger("Jump");
            rigid.velocity = Vector2.zero;
            rigid.AddForce(new Vector2(0, jumpForce));
            Instantiate(VFX,new Vector3(transform.position.x, transform.position.y + 0.1f,transform.position.z), transform.rotation); 
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Dead")
        {
            animator.SetTrigger("Die");
            isDead = true;
            this.gameObject.SetActive(false);
            Instantiate(VFX2, transform.position, transform.rotation); 

        }
        if (collision.tag == "Goal" && isDead==false)
        {
            GameManager.instance.scoreManager.IncreaseScore(1);
         
        }
        
    }
}
