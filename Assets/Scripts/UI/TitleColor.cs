using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TitleColor : MonoBehaviour
{
    [SerializeField] List<Color> colors = new List<Color>();
    private TextMeshProUGUI titleTextMesh;
    void Awake()
    {
        titleTextMesh = GetComponent<TextMeshProUGUI>();
        StartCoroutine(ChangeTextColor());
    }

    IEnumerator ChangeTextColor()
    {
        while (true)
        {
            foreach (Color i in colors)
            {
                titleTextMesh.color = i;
                yield return new WaitForSeconds(0.2f);
            }
        }

    }
}


