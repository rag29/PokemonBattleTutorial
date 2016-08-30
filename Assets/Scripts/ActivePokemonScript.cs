using UnityEngine;
using System.Collections;

public class ActivePokemonScript : MonoBehaviour {

	public static string activePokemon_Player;
	public static string activePokemon_Enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//check which Pokemon the enemy is currently using 
		if (GameState.enemy_1_summoned && !GameState.enemy_2_summoned)
		{
			activePokemon_Enemy = Team.enemy_team [0];
		} 

		else if (GameState.enemy_2_summoned && !GameState.enemy_3_summoned) 
		{
			activePokemon_Enemy = Team.enemy_team [1];
		} 

		else 
		{
			activePokemon_Enemy = Team.enemy_team [2];
		}

	//---------------------------------------------------------------------------------------------

		//check which Pokemon the player is currently using 
		if (GameState.player_1_summoned && !GameState.player_2_summoned)
		{
			activePokemon_Player = Team.player_team[0];
		} 

		else if (GameState.player_2_summoned && !GameState.player_3_summoned) 
		{
			activePokemon_Player = Team.player_team[1];
		} 

		else 
		{
			activePokemon_Player = Team.player_team[2];
		}
	
	}
}
