using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TitleColor : MonoBehaviour
{
    [SerializeField] List<Color> colors = new List<Color>();
    void Awake()
    {
        StartCoroutine(ChangeTextColor());
    }

    IEnumerator ChangeTextColor()
    {
        while(true)
        {   foreach(Color i in colors)
            {
                gameObject.GetComponent<TextMeshProUGUI>().color = i;
                yield return new WaitForSeconds(0.2f);
            }
            

        }
        
    }
}


