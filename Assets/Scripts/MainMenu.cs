using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject tutorialScreen1;
    public GameObject tutorialScreen2;
    public GameObject tutorialScreen3;
    public GameObject creditsScreen;
    public GameObject mainMenu;
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void Tutorial()
    {
        mainMenu.SetActive(false);
        tutorialScreen1.SetActive(true);
    }

    public void CreditsButton()
    {
        mainMenu.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void NextButtonTutorial1()
    {
        tutorialScreen1.SetActive(false);
        tutorialScreen2.SetActive(true);
    }
    public void NextButtonTutorial2()
    {
        tutorialScreen2.SetActive(false);
        tutorialScreen3.SetActive(true);
    }

    public void BackButtonTutorial1()
    {
        tutorialScreen2.SetActive(false);
        tutorialScreen1.SetActive(true);
    }

    public void BackButtonTutorial2()
    {
        tutorialScreen3.SetActive(false);
        tutorialScreen2.SetActive(true);
    }


    public void BackButtonMain()
    {
        if (creditsScreen != null)
        {
            creditsScreen.SetActive(false);
        }

        if (tutorialScreen1 != null)
        {
            tutorialScreen1.SetActive(false);
        }

        if (tutorialScreen2 != null)
        {
            tutorialScreen2.SetActive(false);
        }

        if (tutorialScreen3 != null)
        {
            tutorialScreen3.SetActive(false);
        }

        mainMenu.SetActive(true);
    }
}

