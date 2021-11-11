using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : Jam
{
    public float speed = 20f;
    public Rigidbody2D rb;
    void Start() {
        rb.velocity = transform.forward * speed;
    }

    void Update() {
        //rb.AddForce(transform.left * speed);
    }
    void OnTriggerEnter2D(Collider2D hit) {
        Destroyable d = hit.GetComponent<Destroyable>();
        if (d != null)
            d.Dead();
        Destroy(gameObject);
    }
}
