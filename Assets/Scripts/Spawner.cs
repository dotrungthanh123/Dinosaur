using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] Obstacles;

    private void Awake() {

    } 

    private void OnEnable() {
        Invoke(nameof(Spawn), 0f);
    }

    private void OnDisable() {
        CancelInvoke();
    }

    private void Spawn() {
        GameObject Obstacle = Instantiate(Obstacles[Random.Range(0, Obstacles.Length)]);
        Obstacle.transform.position = transform.position;
        Invoke(nameof(Spawn), 1.5f);
    }
}
