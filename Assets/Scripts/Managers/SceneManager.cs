using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void navigateToWelcomeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("WelcomeScene");
    }
    
    public void navigateToTrialScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TrialScene");
    }
    
    public void navigateToChallengeStartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ChallengeStartScene");
    }
    
    public void navigateToChallengeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ChallengeScene");
    }
    
    public void navigateToMelodyScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MelodyScene");
    }
}
