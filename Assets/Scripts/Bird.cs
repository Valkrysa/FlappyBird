using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float upForce = 200f;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator animator;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update () {
        if (!isDead) {
            if (Input.GetMouseButtonDown(0)) {
                animator.SetTrigger("Flap");
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0f, upForce));
            }
        }
    }

    void OnCollisionEnter2D() {
        rb2d.velocity = Vector2.zero;
        animator.SetTrigger("Die");
        isDead = true;
        GameController.instance.BirdDied();
    }
}
