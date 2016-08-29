using UnityEngine;
using System.Collections;

public class SummonAPokemon_Enemy : MonoBehaviour {

	float timer;

	public GameObject particle_system_left;

	public GameObject pokeball_left;

	public GameObject pikachu_left;
	public GameObject squirtle_left;
	public GameObject charmeleon_left;
	public GameObject ivysaur_left;
	public GameObject hooh_left;
	public GameObject dialga_left;

	// Use this for initialization
	void Start () 
	{
		timer = 0f;

		particle_system_left.SetActive (false);

		pokeball_left.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (pokeball_left.activeSelf) 
		{
			timer += Time.deltaTime;
		}

		if (timer > 1.8f) 
		{
			particle_system_left.SetActive (true);
		}

		if (timer > 4.8f) 
		{
			if (!GameState.enemy_1_summoned) {
				switch (Team.enemy_team [0]) {
				case "pikachu":
					pikachu_left.SetActive (true);
					break;
				case "squirtle":
					squirtle_left.SetActive (true);
					break;
				case "charmeleon":
					charmeleon_left.SetActive (true);
					break;
				case "ivysaur":
					ivysaur_left.SetActive (true);
					break;
				case "hooh":
					hooh_left.SetActive (true);
					break;
				case "dialga":
					dialga_left.SetActive (true);
					break;
				}
				pokeball_left.SetActive (false);
				timer = 0f;
				GameState.enemy_1_summoned = true;

			} else if (!GameState.enemy_2_summoned) {
				switch (Team.enemy_team [1]) {
				case "pikachu":
					pikachu_left.SetActive (true);
					break;
				case "squirtle":
					squirtle_left.SetActive (true);
					break;
				case "charmeleon":
					charmeleon_left.SetActive (true);
					break;
				case "ivysaur":
					ivysaur_left.SetActive (true);
					break;
				case "hooh":
					hooh_left.SetActive (true);
					break;
				case "dialga":
					dialga_left.SetActive (true);
					break;
				}
				pokeball_left.SetActive (false);
				timer = 0f;
				GameState.enemy_2_summoned = true;


			} else if (!GameState.enemy_3_summoned) {
				switch (Team.enemy_team [2]) {
				case "pikachu":
					pikachu_left.SetActive (true);
					break;
				case "squirtle":
					squirtle_left.SetActive (true);
					break;
				case "charmeleon":
					charmeleon_left.SetActive (true);
					break;
				case "ivysaur":
					ivysaur_left.SetActive (true);
					break;
				case "hooh":
					hooh_left.SetActive (true);
					break;
				case "dialga":
					dialga_left.SetActive (true);
					break;
				}
				pokeball_left.SetActive (false);
				timer = 0f;
				GameState.enemy_3_summoned = true;

			} else {
				
			}
		}
	}
}
