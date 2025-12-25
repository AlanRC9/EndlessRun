using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private int score;
    [SerializeField] private TextMeshProUGUI ScoreText;


    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        ScoreText.text = score.ToString();
    }

}
