using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    MeshRenderer mr;
    private void Awake() {
        mr = GetComponent<MeshRenderer>();
    }

    private void Update() {
        float speed = GameManager.Instance.GameSpeed / transform.localScale.x;
        mr.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }
}
