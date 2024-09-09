using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuUI : MonoBehaviour
{
    
    private bool hasIllustrationEnded; // use this bool to enable the game scene to be loaded once the illustration is done playing.


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        // while loading new scene, play illustration
        // start game scene
        StartCoroutine(IllustrationMockUp());// for now until illustration is done
    }

    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone && !hasIllustrationEnded)
        {
            //Loading
            Debug.Log("Loading...");
            yield return null;
        }
    }

    IEnumerator IllustrationMockUp() 
    {
        hasIllustrationEnded = false;
        Debug.Log("Illustration happening");
        yield return new WaitForSeconds(3f);
        Debug.Log("Illustration done");
        hasIllustrationEnded = true;
        StartCoroutine(LoadYourAsyncScene("Game"));
    }
}
