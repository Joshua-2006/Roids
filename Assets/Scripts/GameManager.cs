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
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI lives;
    public int lives1;
    [SerializeField] private int score1;

    [Header("Restart")]
    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI restart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lives1 <= 0)
        {
            restart.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
        }
    }
}
