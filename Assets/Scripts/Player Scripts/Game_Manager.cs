using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Alex Gallegos and Andrew Bangs (In seperate region) Game manager script
public class Game_Manager : MonoBehaviour {

	
	#region Andrew Bangs Code
	void Awake () {		
		DontDestroyOnLoad(this.gameObject);
	}
	
	public int PlayerHP;
	
	public void ReduceHealth (){
		PlayerHP -= 1;
		
		if (PlayerHP <= 0){
			StartCoroutine(RestartLevel(1));
		}
	}
	
	IEnumerator RestartLevel(float delay) {
		// wait for the delay amount of seconds, by yield-returning a WaitForSeconds object:
		yield return new WaitForSeconds(delay);
		// Reload the active scene:
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
	#endregion
}
