using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public void PlayGame()
    {
        Load();
    }



    public void OptionGame()
    {
        UIManagerScript.uiManager.UISelect(false, true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MenuGame()
    {
        UIManagerScript.uiManager.UISelect(true, false);
    }

    
    private void Load()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }

    }
}
