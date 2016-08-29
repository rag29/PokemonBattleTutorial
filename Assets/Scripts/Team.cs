using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Team : MonoBehaviour {

	public static List<string> player_team;
	public static List<string> enemy_team;

	// Use this for initialization
	void Start () {
	
		player_team = new List<string>();
		enemy_team = new List<string>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
