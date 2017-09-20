using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl {

	public static void RestartGame(){
		CheckpointControl.chkDictP1.Clear();
		CheckpointControl.chkDictP2.Clear();
		EnemyDefs.enemyDict.Clear();
		SceneManager.LoadScene ("ThrowYourself");
	}

	public static void LevelComplete(){
  		SceneManager.LoadScene ("WinScreen");
	}

    public static void QuitGame(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            Application.Quit();
        }
    }


}
