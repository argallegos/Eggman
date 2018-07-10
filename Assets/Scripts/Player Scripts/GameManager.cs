using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Andrew Bangs Game manager script
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
	private bool PlayerBurning;
	
	void Awake () {		
		DontDestroyOnLoad(this.gameObject);
	}
	
	public void ReduceHealth (int Amount){
		PlayerHP -= Amount;
		
		if (PlayerHP <= 0){
			StartCoroutine(RestartLevel(1));
		}
	}
	
	public void BurnPlayer (int Ticks, int DmgAmount){
		if (!PlayerBurning){
			StartCoroutine(BurnDamage(Ticks, DmgAmount));
			PlayerBurning = true;
			Debug.Log("Burninat Begin");
		}
	}
	
	IEnumerator BurnDamage(int Ticks, int DmgAmount) {
		for(int i=0; i < Ticks; i++){
			ReduceHealth(DmgAmount);
			yield return new WaitForSeconds(0.3f);
			Debug.Log("Burninated");
		}
    }
	
	IEnumerator RestartLevel(float delay) {
		// wait for the delay amount of seconds, by yield-returning a WaitForSeconds object:
		yield return new WaitForSeconds(delay);
		// Reload the active scene:
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
