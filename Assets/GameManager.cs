using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region MainMenu Button Controls

    public void playButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitButton()
    {
        Application.Quit();
    }

    public void infoButton()
    {
        SceneManager.LoadScene(3);//load info scene
    }

    #endregion

    #region EndMenu Controls

    public void returnMM()
    {
        SceneManager.LoadScene(0);//load the main menu
    }

    #endregion

    #region InfoScene Controls

    public void InfoButtonReturn()
    {
        SceneManager.LoadScene(0);
    }

    #endregion
}
