using UnityEngine.SceneManagement;
using UnityEngine;
using SkillzSDK;


public class MainMenu : MonoBehaviour
{
	public sealed class MainMenuManager : MonoBehaviour
{
    public void LaunchSkillz()
    {
        SkillzCrossPlatform.LaunchSkillz(new GameController());
    }
}
	public void PlayGame(){
		SceneManager.LoadScene("Level");
	}
	
	public void QuitGame(){
		Application.Quit();
	}
	
}
