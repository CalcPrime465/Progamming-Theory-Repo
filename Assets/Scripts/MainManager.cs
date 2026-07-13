using UnityEngine;
using TMPro;

public class MainManager : MonoBehaviour
{
    private int health = 0;
    private int score = 0;

    public TMP_Text healthText;
    public TMP_Text scoreText;

    private void Start()
    {
        UpdateHealth(10);
        UpdateScore(0);
    }
    public void UpdateHealth(int value)
    {
        health += value;
        healthText.text = "Health: " + health;
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }
}
