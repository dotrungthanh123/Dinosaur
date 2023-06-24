using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float LeftEdge;

    private void Awake() {
        LeftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }

    private void Update() {
        transform.position += Vector3.left * GameManager.Instance.GameSpeed * Time.deltaTime;
        if (transform.position.x < LeftEdge)
            Destroy(gameObject);
    }
}
