using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Andrew Bangs Game manager script, Game manager controls UI, scenes, and player status
public class GameManager : MonoBehaviour {

protected static GameManager _instance = null;

    /**
     * Return the instance of this singleton in the scene.
     */
    public static GameManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null) {
                    Debug.LogError("An instance of type GameManager is needed in the scene, but there is none!");
                }
            }
            return _instance;
        }
    }
	
	public int PlayerHP;
	public int DmgMultiplier;
	private bool PlayerBurning;
	
	void Awake () {		
		DontDestroyOnLoad(this.gameObject);
	}
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
	
#region UI and Scene Management
	public void StartGame(){
		SceneManager.LoadScene("Level_1");
	}
	
	public void ExitGame(){
		Application.Quit();
		Debug.Log("Quit Game");
	}
	
	IEnumerator RestartLevel(float delay) {
		// wait for the delay amount of seconds, by yield-returning a WaitForSeconds object:
		yield return new WaitForSeconds(delay);
		// Reload the active scene:
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
#endregion
}
