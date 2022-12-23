using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneNavigation : MonoBehaviour
{
    [SerializeField] AudioClip buttonSound;
    public void ChangeScene(int n)
    {
        AudioSource.PlayClipAtPoint(buttonSound, Camera.main.transform.position);
        StartCoroutine(LoadAfterSound(n));

    }

    IEnumerator LoadAfterSound(int n)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(n);
    }

    public void QuitGame()
    {
        Application.Quit(); //quit application
    }

}
