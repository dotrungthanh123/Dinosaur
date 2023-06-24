using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float GameSpeed { get; private set; }
    public float IncreaseSpeed = 0.1f;
    public float OriginalSpeed = 5f;
    public float score;
    public float hiScore;
    private Dinosaur dino;
    private Rigidbody2D DinoBody;
    private Spawner sp;
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI HiScore;
    public Button RetryButton;
    private void Awake() {
        if (Instance == null) Instance = this;
        else DestroyImmediate(gameObject);
    }

    private void OnDestroy() {
        if (Instance == this) Instance = null;
    }

    private void Start() {
        dino = FindObjectOfType<Dinosaur>();
        sp = FindObjectOfType<Spawner>();
        DinoBody = dino.GetComponent<Rigidbody2D>();

        NewGame();
    }

    public void GameOver() {
        GameSpeed = 0f;
        enabled = false;

        DinoBody.velocity = Vector2.zero;
        DinoBody.isKinematic = true;
        sp.gameObject.SetActive(false);

        RetryButton.gameObject.SetActive(true);
        GameOverText.gameObject.SetActive(true);

        UpdateScore();
        HiScore.text = Mathf.FloorToInt(hiScore).ToString("D5");
    }

    public void NewGame() {
        score = 0;
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach(var obstacle in obstacles) {
            Destroy(obstacle.gameObject);
        }

        RetryButton.gameObject.SetActive(false);
        GameOverText.gameObject.SetActive(false);

        GameSpeed = OriginalSpeed;
        enabled = true;

        DinoBody.isKinematic = false;
        dino.ToOriginalPosition();
        dino.gameObject.SetActive(false);
        dino.gameObject.SetActive(true);
        sp.gameObject.SetActive(true);
        UpdateScore();
        HiScore.text = Mathf.FloorToInt(hiScore).ToString("D5");
    }

    private void Update() {
        GameSpeed += IncreaseSpeed * Time.deltaTime;
        score += GameSpeed * Time.deltaTime;
        Score.text = Mathf.FloorToInt(score).ToString("D5");
    }

    private void UpdateScore() {
        hiScore = PlayerPrefs.GetFloat("HiScore", 0);
        if (score > hiScore) {
            hiScore = score;
            PlayerPrefs.SetFloat("HiScore", hiScore);
        }
    }
}
