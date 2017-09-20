using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Prefabs DB")]

public class PrefabsDB : ScriptableObject {
	[SerializeField]
	private GameObject[] players;
	public GameObject[] Players { get { return players; } }

	[SerializeField]
	private GameObject[] enemies;
	public GameObject[] Enemies { get { return enemies; } }

	[SerializeField]
	private GameObject[] ammoTypes;
	public GameObject[] AmmoTypes { get { return ammoTypes; }} 

	[SerializeField]
	private GameObject[] triggerTypes;
	public GameObject[] TriggerTypes { get { return triggerTypes; }}

    [SerializeField]
    private GameObject gameManager;
    public GameObject GameManager {  get { return gameManager; } }
}
