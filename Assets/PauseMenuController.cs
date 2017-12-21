using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
	[SerializeField]
	private GameObject pauseGameObject;
    private bool paused = true;
	private bool checkPause = false;
	public void Awake()
	{
		pauseGameObject.SetActive(checkPause);
	}
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			TooglePauseMenu();
		}
			
	}
	public void TooglePauseMenu()
	{
		pauseGameObject.SetActive(!pauseGameObject.activeSelf);
        if (paused)
        {
            Time.timeScale = 0;
            paused = !paused;
            var cameraBone = GameObject.Find("CameraBone").GetComponent<SmoothCamera>();
            cameraBone.enabled = false;
        }
        else
        {
            Time.timeScale = 1;
            paused = !paused;
            var cameraBone = GameObject.Find("CameraBone").GetComponent<SmoothCamera>();
            cameraBone.enabled = true;
        }
	}

	public void GoToMenu()
	{
		SceneManager.LoadScene(0);
	}
}
