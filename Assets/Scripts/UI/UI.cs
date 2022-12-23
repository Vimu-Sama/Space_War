using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Player;


public class UI : MonoBehaviour
{
    [SerializeField] private GameObject scoreObject;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject player;
    private ScoreKeeper scoreKeeper;
    private TextMeshProUGUI scoreText;
    private Health healthScript;

    private void Start()
    {
        scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
        scoreKeeper = ScoreKeeper.Instance;
        healthScript = player.GetComponent<Health>();
    }
    private void Update()
    {
        scoreText.text =  scoreKeeper.GetScore().ToString();
        if(player!=null)
            slider.value = (float)healthScript.GetHealth()/100;

        //need to address this issue with Observer Pattern
        if (FindObjectOfType<PlayerController>() == null && SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(2);
        }

    }
}
