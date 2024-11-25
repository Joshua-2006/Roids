using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Player Stuff")]
    [SerializeField] private GameObject player;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI livestext;
    [SerializeField] private int extraLives;
    public int lives = 3;
    public int score = 0;
    public int currentscore = 0;

    [Header("Restart")]
    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI restart;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lives < extraLives)
        {
            extraLives = lives;
            livestext.text = $"Lives: {lives}";
        }
        if(lives <= 0)
        {
            restart.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
        }
    }
    public void Score()
    {
        score += 50;
        scoretext.text = $"Score: {score}";
    }
}
