using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 OriginalPosition;
    bool grounded;
    [SerializeField] float jumpForce = 5.5f;

    private void Awake() {
        OriginalPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        grounded = true;
    }
    
    public void ToOriginalPosition() {
        transform.position = OriginalPosition;
    }

    private void OnCollisionEnter2D() {
        grounded = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Obstacle")) {
            GameManager.Instance.GameOver();
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && grounded) {
            grounded = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
