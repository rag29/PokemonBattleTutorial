using UnityEngine;
using System.Collections;

public class SummonAPokemon_Player : MonoBehaviour {

	float timer;

	public GameObject particle_system_right;

	public GameObject pokeball_right;

	public GameObject pikachu_right;
	public GameObject squirtle_right;
	public GameObject charmeleon_right;
	public GameObject ivysaur_right;
	public GameObject hooh_right;
	public GameObject dialga_right;

	bool hit;


	// Use this for initialization
	void Start () 
	{
		timer = 0f;

		particle_system_right.SetActive (false);

		pokeball_right.SetActive (false);

		hit = false;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (pokeball_right.activeSelf) 
		{
			timer += Time.deltaTime;
		}

		if (timer > 1.8f) 
		{
			particle_system_right.SetActive (true);
		}

		if (timer > 4.8f) 
		{
			if (!GameState.player_1_summoned && !hit) {
				print (1);
				switch (Team.player_team [0]) {
				case "pikachu":
					pikachu_right.SetActive (true);
					pokeball_right.SetActive (false);
					break;
				case "squirtle":
					squirtle_right.SetActive (true);
					pokeball_right.SetActive (false);
					break;
				case "charmeleon":
					charmeleon_right.SetActive (true);
					pokeball_right.SetActive (false);
					break;
				case "ivysaur":
					ivysaur_right.SetActive (true);
					pokeball_right.SetActive (false);
					break;
				case "hooh":
					hooh_right.SetActive (true);
					pokeball_right.SetActive (false);
					break;
				case "dialga":
					dialga_right.SetActive (true);
					pokeball_right.SetActive (false);
					break;
				}
				pokeball_right.SetActive (false);
				timer = 0f;
				hit = true;
				GameState.player_1_summoned = true;

			} else if (!GameState.player_2_summoned && !hit) {
				print (2);
				switch (Team.player_team [1]) {
				case "pikachu":
					pikachu_right.SetActive (true);
					pokeball_right.SetActive (false);
					break;
				case "squirtle":
					squirtle_right.SetActive (true);
					pokeball_right.SetActive (false);
					break;
				case "charmeleon":
					charmeleon_right.SetActive (true);
					pokeball_right.SetActive (false);
					break;
				case "ivysaur":
					ivysaur_right.SetActive (true);
					pokeball_right.SetActive (false);
					break;
				case "hooh":
					hooh_right.SetActive (true);
					pokeball_right.SetActive (false);
					break;
				case "dialga":
					dialga_right.SetActive (true);
					pokeball_right.SetActive (false);
					break;
				}
				pokeball_right.SetActive (false);
				particle_system_right.SetActive (false);
				timer = 0f;
				hit = true;
				GameState.player_2_summoned = true;


			} else if (!GameState.player_3_summoned && !hit) {
				print (3);
				switch (Team.player_team [2]) {
				case "pikachu":
					pikachu_right.SetActive (true);
					pokeball_right.SetActive (false);
					break;
				case "squirtle":
					squirtle_right.SetActive (true);
					pokeball_right.SetActive (false);
					break;
				case "charmeleon":
					charmeleon_right.SetActive (true);
					pokeball_right.SetActive (false);
					break;
				case "ivysaur":
					ivysaur_right.SetActive (true);
					pokeball_right.SetActive (false);
					break;
				case "hooh":
					hooh_right.SetActive (true);
					pokeball_right.SetActive (false);
					break;
				case "dialga":
					dialga_right.SetActive (true);
					pokeball_right.SetActive (false);
					break;
				}
				pokeball_right.SetActive (false);
				particle_system_right.SetActive (false);
				timer = 0f;
				hit = true;
				GameState.player_3_summoned = true;

			} else {
				
			}
		}
	}
}
