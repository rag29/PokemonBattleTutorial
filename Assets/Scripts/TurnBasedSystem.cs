using UnityEngine;
using System.Collections;

public class TurnBasedSystem : MonoBehaviour {

	/*
	 * This script is attached to an empty game object that is activated after the game state script runs and
	 * summons the two Pokemon to begin with. The purpose of this script is to facilitate the turn based gameplay 
	 * where the two opposing pokemon take truns attacking one another. When a Pokemon's hit points reach zero 
	 * the pokemon will faint and will either be replaced by a new Pokemon (if there are any replacement Pokemon left) or
	 * the player who struck the winning blow will wim the Pokemon battle game
	*/

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
