using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameState : MonoBehaviour {

	public static bool one_set;
	public static bool two_set;
	public static bool three_set;

	public static List<string> player_team;
	public static List<string> enemy_team;

	// Use this for initialization
	void Start () 
	{
		one_set = false;
		two_set = false;
		three_set = false;

		player_team = new List<string>();
		enemy_team = new List<string>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
