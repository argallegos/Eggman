using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private GameObject gameObject;

    private static GameManager m_instance;

    public static GameManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new GameManager();
                m_instance.gameObject = new GameObject ("_gameManager");
                m_instance.gameObject.AddComponent<InputController>();

            }
            return m_instance;
        }
    }
    private InputController m_InputController;
    public InputController InputController
    {
        get
        {
            if (m_InputController == null)
                m_InputController = gameObject.GetComponent<InputController>();
            return m_InputController;
        }
    }
	
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
