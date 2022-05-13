using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{
    [SerializeField] GameObject scoreObject;
    [SerializeField] Slider slider;
    [SerializeField] GameObject player;

    private void Update()
    {
        scoreObject.GetComponent<TextMeshProUGUI>().text =  
            FindObjectOfType<ScoreKeeper>().GetScore().ToString();
        if(player!=null)
            slider.value = (float)player.GetComponent<Health>().GetHealth()/100;
        if (FindObjectOfType<PlayerController>() == null && SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(2);
        }

    }
}
