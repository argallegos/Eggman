using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Andrew Bangs Game manager script, Game manager controls UI, scenes, and player status
public class GameManager : MonoBehaviour {

protected static GameManager _instance = null;
	
	public static GameManager Instance = null;
	public int PlayerHP;
	public int DmgMultiplier;
	private bool PlayerBurning;
	public GameObject PauseMenu;
	public GameObject MainMenu;
	public int SceneNumber;
	
	void Awake () {		
		DontDestroyOnLoad(this.gameObject);
		if (Instance == null){
			Instance = this;
		} else if (Instance != this){
			Destroy(this.gameObject);
		}
		SceneNumber = SceneManager.GetActiveScene().buildIndex;
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.P) && SceneNumber > 0){
			PauseGame();
		}
	}

#region Scene Management	
	void OnEnable(){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	
	void OnDisable(){
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
	
	void OnSceneLoaded (Scene scene, LoadSceneMode mode){
		Debug.Log("Scene =" + SceneNumber);
		SceneNumber = SceneManager.GetActiveScene().buildIndex;
		if (SceneNumber == 0){
			MainMenu.SetActive (true);
		}else if (SceneNumber != 0){
			MainMenu.SetActive (false);
		}
	}
	
	IEnumerator RestartLevel(float delay) {
		// wait for the delay amount of seconds, by yield-returning a WaitForSeconds object:
		yield return new WaitForSeconds(delay);
		// Reload the active scene:
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
#endregion
	
#region Player damage and status functions
	public void ReduceHealth (int Amount){
		PlayerHP -= Amount;
		
		if (PlayerHP <= 0){
			StartCoroutine(RestartLevel(1));
		}
	}
	
	public void BurnPlayer (int Ticks, int DmgAmount, bool Burning){
		if (!Burning){
			StartCoroutine(BurnDamage(Ticks, DmgAmount));
			PlayerBurning = false;
			Debug.Log("Burninat Begin");
		} else if (Burning){
			StartCoroutine(BurnDamage(Ticks, DmgAmount));
			PlayerBurning = true;
		}
	}
	
	public void ChangeDMGMult(float Delay, bool Exiting){
		if (!Exiting){
			DmgMultiplier = 2;
		} else if (Exiting){
			StartCoroutine(ResetDmgMult(Delay));
		}
	}
	
	IEnumerator BurnDamage(int Ticks, int DmgAmount) {
		for(int i=0; i < Ticks; i++){
			ReduceHealth(DmgAmount * DmgMultiplier);
			yield return new WaitForSeconds(0.3f);
			if(PlayerBurning){
				Ticks += 1;
				Debug.Log("More Burninate");
			}
			Debug.Log("Burninated");
		}
    }
	
	IEnumerator ResetDmgMult(float Delay){
		yield return new WaitForSeconds(Delay);
		DmgMultiplier = 1;
	}
#endregion
	
#region UI Management
	public void StartGame(){
		SceneManager.LoadScene("Level_1");
	}
	
	public void ExitGame(){
		Application.Quit();
		Debug.Log("Quit Game");
	}
	
	public void PauseGame(){
		Debug.Log("Time Frozen");
		PauseMenu.SetActive (true);
		Time.timeScale = 0.0f;
	}
	
	public void GoToMain(){
		SceneManager.LoadScene("_MainMenu");
		SceneNumber = 0;
		ResumeGame();
	}
	
	public void ResumeGame(){
		Time.timeScale = 1.0f;
		Debug.Log("Time Continued");
		PauseMenu.SetActive (false);
	}
#endregion
}
