using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float force = 200;
    public AudioSource audioSource;
    public AudioClip flyClip, dieClip, pingClip;


    bool isDie;
    int score = 0;

    public int Score { get => score; set => score = value; }
    private void Start()
    {
        SetUp();
    }
    private void Update()
    {
        if(isDie) return;
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector2.up * force);
            audioSource.PlayOneShot(flyClip);
        }

        if(rb.velocity.y > 0) { 
            float angle = Mathf.Lerp(0,90,rb.velocity.y/7);
            transform.rotation = Quaternion.Euler(0,0,angle);
        }
        else
        {
            float angle = Mathf.Lerp(0, -90, -rb.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void Init()
    {
        isDie = false;
        score = 0;
        rb.gravityScale = 1;
        transform.position = new Vector3(-1.3f,0,0);
        animator.SetTrigger("reset");
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDie && collision.CompareTag("Score"))
        {
            score++;
            audioSource.PlayOneShot(pingClip);
            UIManager.Instance.scoreText.text = score.ToString();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isDie && (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Pipe")))
        {
           
            audioSource.PlayOneShot(dieClip);
            animator.SetTrigger("die");
            isDie = true;
            GameManager.Instance.isGamePlay = false;
            UIManager.Instance.OpenGameoverDelay(0.5f);
        }
    }
    public void SetUp()
    {
        isDie = true;
        rb.gravityScale = 0;
    }
}
