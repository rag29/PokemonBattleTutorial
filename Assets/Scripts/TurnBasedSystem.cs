using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TurnBasedSystem : MonoBehaviour {

	/*
	 * This script is attached to an empty game object that is activated after the game state script runs and
	 * summons the two Pokemon to begin with. The purpose of this script is to facilitate the turn based gameplay 
	 * where the two opposing pokemon take truns attacking one another. When a Pokemon's hit points reach zero 
	 * the pokemon will faint and will either be replaced by a new Pokemon (if there are any replacement Pokemon left) or
	 * the player who struck the winning blow will wim the Pokemon battle game
	*/

	public GameObject right_camera;
	public GameObject left_camera;
	public GameObject overhead_camera;
	public GameObject attack_camera;

	public GameObject attack_canvas;
	public GameObject battle_canvas;

	public Text attack1;
	public Text attack2;

	float timer;

	bool choose_an_attack;
	bool overhead;
	bool attack_in_progress;
	bool enemy_damage;
	bool enemy_attack_in_progress;
	bool player_damage;

	int enemy_attack_random_number;

	public GameObject pikachu_thunder_player;
	public GameObject pikachu_shockwave_player;
	public GameObject squirtle_watergun_player;
	public GameObject squirtle_bubble_player;
	public GameObject charmeleon_fireblast_player;
	public GameObject charmeleon_flamethrower_player;
	public GameObject ivysaur_razorleaf_player;
	public GameObject ivysaur_hyperbeam_player;
	public GameObject dialga_dragonbreath_player;
	public GameObject hooh_sacredfire_player;

	public GameObject pikachu_thunder_enemy;
	public GameObject pikachu_shockwave_enemy;
	public GameObject squirtle_watergun_enemy;
	public GameObject squirtle_bubble_enemy;
	public GameObject charmeleon_fireblast_enemy;
	public GameObject charmeleon_flamethrower_enemy;
	public GameObject ivysaur_razorleaf_enemy;
	public GameObject ivysaur_hyperbeam_enemy;
	public GameObject dialga_dragonbreath_enemy;
	public GameObject hooh_sacredfire_enemy;

	bool attack1_chosen;
	bool attack2_chosen;

	public Material sunny_day_MAT;
	public Material roar_of_time_MAT;
	public Material normal_skybox_MAT;

	public GameObject right_pokeball;
	public GameObject left_pokeball;

	public GameObject pikachu_player;
	public GameObject squirtle_player;
	public GameObject charmeleon_player;
	public GameObject ivysaur_player;
	public GameObject hooh_player;
	public GameObject dialga_player;

	public GameObject pikachu_enemy;
	public GameObject squirtle_enemy;
	public GameObject charmeleon_enemy;
	public GameObject ivysaur_enemy;
	public GameObject hooh_enemy;
	public GameObject dialga_enemy;

	public GameObject pikachu_enemy_canvas_stuff;
	public GameObject squirtle_enemy_canvas_stuff;
	public GameObject charmeleon_enemy_canvas_stuff;
	public GameObject ivysaur_enemy_canvas_stuff;
	public GameObject hooh_enemy_canvas_stuff;
	public GameObject dialga_enemy_canvas_stuff;

	public GameObject pikachu_player_canvas_stuff;
	public GameObject squirtle_player_canvas_stuff;
	public GameObject charmeleon_player_canvas_stuff;
	public GameObject ivysaur_player_canvas_stuff;
	public GameObject hooh_player_canvas_stuff;
	public GameObject dialga_player_canvas_stuff;

	public GameObject pikachu_enemy_health;
	public GameObject squirtle_enemy_health;
	public GameObject charmeleon_enemy_health;
	public GameObject ivysaur_enemy_health;
	public GameObject hooh_enemy_health;
	public GameObject dialga_enemy_health;

	public GameObject pikachu_player_health;
	public GameObject squirtle_player_health;
	public GameObject charmeleon_player_health;
	public GameObject ivysaur_player_health;
	public GameObject hooh_player_health;
	public GameObject dialga_player_health;

	// Use this for initialization
	void Start () 
	{
		timer = 0f;
		choose_an_attack = true;
		overhead = false;
		attack_in_progress = false;
		enemy_damage = false;
		enemy_attack_in_progress = false;
		player_damage = false;

		battle_canvas.SetActive (false);

		enemy_attack_random_number = 0;

		attack1_chosen = false;
		attack2_chosen = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		enemy_attack_random_number = Random.Range (0, 2);

		if (choose_an_attack) 
		{
			PlayerChooseAttack ();
		}

		if (overhead) 
		{
			timer += Time.deltaTime;

			if (timer > 2f) 
			{
				Player_AttackInProgress ();
		
			}
		}

		if (attack_in_progress) 
		{
			print (timer);
			timer += Time.deltaTime;

			if (timer > 5f) 
			{
				print ("hit");
				EnemyDamage ();

			}
		}

		if (enemy_damage)
		{
			timer += Time.deltaTime;

			if (timer > 5f) 
			{
				Enemy_AttackInProgress ();

			}
		}

		if (enemy_attack_in_progress) 
		{
			timer += Time.deltaTime;

			if (timer > 5f) 
			{
				PlayerDamage ();

			}
		}

		if (player_damage) 
		{
			timer += Time.deltaTime;

			if (timer > 5f) 
			{
				PlayerChooseAttack ();

			}
		}
			
	}

	//the function that enables the player (right) camera and lets them choose an attack
	void PlayerChooseAttack()
	{
		right_camera.SetActive (true);
		left_camera.SetActive (false);
		overhead_camera.SetActive (false);

		attack_canvas.SetActive (true);

		switch(ActivePokemonScript.activePokemon_Player)
		{
		case "pikachu":
			attack1.text = "Thunder";
			attack2.text = "Shockwave";
			pikachu_player_canvas_stuff.SetActive (true);
			pikachu_player_health.GetComponent<SpriteRenderer>().enabled = true;
			break;
		case "squirtle":
			attack1.text = "Water Gun";
			attack2.text = "Bubble";
			squirtle_player_canvas_stuff.SetActive (true);
			squirtle_player_health.GetComponent<SpriteRenderer>().enabled = true;
			break;
		case "charmeleon":
			attack1.text = "Fire Blast";
			attack2.text = "Flamethrower";
			charmeleon_player_canvas_stuff.SetActive (true);
			charmeleon_player_health.GetComponent<SpriteRenderer>().enabled = true;
			break;
		case "ivysaur":
			attack1.text = "Razor Leaf";
			attack2.text = "Hyper Beam";
			ivysaur_player_canvas_stuff.SetActive (true);
			ivysaur_player_health.GetComponent<SpriteRenderer>().enabled = true;
			break;
		case "dialga":
			attack1.text = "Dragon Breath";
			attack2.text = "Roar of Time";
			dialga_player_canvas_stuff.SetActive (true);
			dialga_player_health.GetComponent<SpriteRenderer>().enabled = true;
			break;
		case "hooh":
			attack1.text = "Sacred Fire";
			attack2.text = "Sunny Day";
			hooh_player_canvas_stuff.SetActive (true);
			hooh_player_health.GetComponent<SpriteRenderer>().enabled = true;
			break;
		}
		//check for active pokemon and display attacks based on that
	}
		
	//the function called when the player clicks one of the attack buttons
	public void Attack1()
	{
		attack1_chosen = true;
		choose_an_attack = false;
		attack_canvas.SetActive (false);

		switch(ActivePokemonScript.activePokemon_Player)
		{
		case "pikachu":
			pikachu_player_canvas_stuff.SetActive (false);
			pikachu_player_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "squirtle":
			squirtle_player_canvas_stuff.SetActive (false);
			squirtle_player_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "charmeleon":
			charmeleon_player_canvas_stuff.SetActive (false);
			charmeleon_player_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "ivysaur":
			ivysaur_player_canvas_stuff.SetActive (false);
			ivysaur_player_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "dialga":
			dialga_player_canvas_stuff.SetActive (false);
			dialga_player_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "hooh":
			hooh_player_canvas_stuff.SetActive (false);
			hooh_player_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		}

		switch(ActivePokemonScript.activePokemon_Enemy)
		{
		case "pikachu":
			pikachu_enemy_canvas_stuff.SetActive (false);
			pikachu_enemy_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "squirtle":
			squirtle_enemy_canvas_stuff.SetActive (false);
			squirtle_enemy_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "charmeleon":
			charmeleon_enemy_canvas_stuff.SetActive (false);
			charmeleon_enemy_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "ivysaur":
			ivysaur_enemy_canvas_stuff.SetActive (false);
			ivysaur_enemy_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "dialga":
			dialga_enemy_canvas_stuff.SetActive (false);
			dialga_enemy_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "hooh":
			hooh_enemy_canvas_stuff.SetActive (false);
			hooh_enemy_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		}

		//set the attack
		OverheadView();
	}

	public void Attack2()
	{
		attack2_chosen = true;
		choose_an_attack = false;
		attack_canvas.SetActive (false);

		switch(ActivePokemonScript.activePokemon_Player)
		{
		case "pikachu":
			pikachu_player_canvas_stuff.SetActive (false);
			pikachu_player_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "squirtle":
			squirtle_player_canvas_stuff.SetActive (false);
			squirtle_player_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "charmeleon":
			charmeleon_player_canvas_stuff.SetActive (false);
			charmeleon_player_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "ivysaur":
			ivysaur_player_canvas_stuff.SetActive (false);
			ivysaur_player_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "dialga":
			dialga_player_canvas_stuff.SetActive (false);
			dialga_player_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "hooh":
			hooh_player_canvas_stuff.SetActive (false);
			hooh_player_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		}

		switch(ActivePokemonScript.activePokemon_Enemy)
		{
		case "pikachu":
			pikachu_enemy_canvas_stuff.SetActive (false);
			pikachu_enemy_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "squirtle":
			squirtle_enemy_canvas_stuff.SetActive (false);
			squirtle_enemy_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "charmeleon":
			charmeleon_enemy_canvas_stuff.SetActive (false);
			charmeleon_enemy_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "ivysaur":
			ivysaur_enemy_canvas_stuff.SetActive (false);
			ivysaur_enemy_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "dialga":
			dialga_enemy_canvas_stuff.SetActive (false);
			dialga_enemy_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		case "hooh":
			hooh_enemy_canvas_stuff.SetActive (false);
			hooh_enemy_health.GetComponent<SpriteRenderer>().enabled = false;
			break;
		}

		//set the attack
		OverheadView();
	}

	//briefly enables the overhead camera
	void OverheadView()
	{
		overhead_camera.SetActive (true);
		right_camera.SetActive (false);
		left_camera.SetActive (false);

		overhead = true;

	}

	void Player_AttackInProgress()
	{
		attack_camera.SetActive (true);
		left_camera.SetActive (false);
		overhead_camera.SetActive (false);

		if (attack1_chosen) {
			switch (ActivePokemonScript.activePokemon_Player) {
			case "pikachu":
				pikachu_thunder_player.SetActive (true);
				break;
			case "squirtle":
				squirtle_watergun_player.SetActive (true);
				break;
			case "charmeleon":
				charmeleon_fireblast_player.SetActive (true);
				break;
			case "ivysaur":
				ivysaur_razorleaf_player.SetActive (true);
				break;
			case "dialga":
				dialga_dragonbreath_player.SetActive (true);
				break;
			case "hooh":
				hooh_sacredfire_player.SetActive (true);
				break;
			}
		}

			else
			{
				switch (ActivePokemonScript.activePokemon_Player) 
				{
				case "pikachu":
					pikachu_shockwave_player.SetActive (true);
					break;
				case "squirtle":
					squirtle_bubble_player.SetActive (true);
					break;
				case "charmeleon":
					charmeleon_flamethrower_player.SetActive (true);
					break;
				case "ivysaur":
					ivysaur_hyperbeam_player.SetActive (true);
					break;
				case "dialga":
					RenderSettings.skybox = roar_of_time_MAT;
					break;
				case "hooh":
					RenderSettings.skybox = sunny_day_MAT;
					break;
				}
			}


		overhead = false;
		attack_in_progress = true;

		//play the attack

		timer = 0;
	}

	void EnemyDamage()
	{
		left_camera.SetActive (true);
		attack_camera.SetActive (false);

		switch (ActivePokemonScript.activePokemon_Enemy) {
		case "pikachu":
			pikachu_enemy_canvas_stuff.SetActive (true);
			pikachu_enemy_health.GetComponent<SpriteRenderer> ().enabled = true;
			HealthBar_Pikachu.health_ratio -= .25f;
			break;
		case "squirtle":
			squirtle_enemy_canvas_stuff.SetActive (true);
			squirtle_enemy_health.GetComponent<SpriteRenderer> ().enabled = true;
			HealthBar_Squirtle.health_ratio -= .25f;
			break;
		case "charmeleon":
			charmeleon_enemy_canvas_stuff.SetActive (true);
			charmeleon_enemy_health.GetComponent<SpriteRenderer> ().enabled = true;
			HealthBar_Charmeleon.health_ratio -= .25f;
			break;
		case "ivysaur":
			ivysaur_enemy_canvas_stuff.SetActive (true);
			ivysaur_enemy_health.GetComponent<SpriteRenderer> ().enabled = true;
			HealthBar_Ivysaur.health_ratio -= .25f;
			break;
		case "dialga":
			dialga_enemy_canvas_stuff.SetActive (true);
			dialga_enemy_health.GetComponent<SpriteRenderer> ().enabled = true;
			HealthBar_Dialga.health_ratio -= .25f;
			break;
		case "hooh":
			hooh_enemy_canvas_stuff.SetActive (true);
			hooh_enemy_health.GetComponent<SpriteRenderer> ().enabled = true;
			HealthBar_Hooh.health_ratio -= .25f;
			break;
		}

		if (attack1_chosen) {
			switch (ActivePokemonScript.activePokemon_Player) {
			case "pikachu":
				pikachu_thunder_player.SetActive (false);
				break;
			case "squirtle":
				squirtle_watergun_player.SetActive (false);
				break;
			case "charmeleon":
				charmeleon_fireblast_player.SetActive (false);
				break;
			case "ivysaur":
				ivysaur_razorleaf_player.SetActive (false);
				break;
			case "dialga":
				dialga_dragonbreath_player.SetActive (false);
				break;
			case "hooh":
				hooh_sacredfire_player.SetActive (false);
				break;
			}
		} else {
			switch (ActivePokemonScript.activePokemon_Player) {
			case "pikachu":
				pikachu_shockwave_player.SetActive (false);
				break;
			case "squirtle":
				squirtle_bubble_player.SetActive (false);
				break;
			case "charmeleon":
				charmeleon_flamethrower_player.SetActive (false);
				break;
			case "ivysaur":
				ivysaur_hyperbeam_player.SetActive (false);
				break;
			case "dialga":
				RenderSettings.skybox = normal_skybox_MAT;
				break;
			case "hooh":
				RenderSettings.skybox = normal_skybox_MAT;
				break;
			}
		}
	
		attack1_chosen = false;
		attack2_chosen = false;

		attack_in_progress = false;
		enemy_damage = true;

		CheckForEnemyFaint ();
		timer = 0;
	}

	void Enemy_AttackInProgress()
	{
		attack_camera.SetActive (true);
		left_camera.SetActive (false);

		enemy_attack_random_number = Random.Range (0, 2);

		if (enemy_attack_random_number == 0) {
			switch (ActivePokemonScript.activePokemon_Enemy) {
			case "pikachu":
				pikachu_thunder_enemy.SetActive (true);
				break;
			case "squirtle":
				squirtle_watergun_enemy.SetActive (true);
				break;
			case "charmeleon":
				charmeleon_fireblast_enemy.SetActive (true);
				break;
			case "ivysaur":
				ivysaur_razorleaf_enemy.SetActive (true);
				break;
			case "dialga":
				dialga_dragonbreath_enemy.SetActive (true);
				break;
			case "hooh":
				hooh_sacredfire_enemy.SetActive (true);
				break;
			}

		} else {
			switch (ActivePokemonScript.activePokemon_Enemy) 
			{
			case "pikachu":
				pikachu_shockwave_enemy.SetActive (true);
				break;
			case "squirtle":
				squirtle_bubble_enemy.SetActive (true);
				break;
			case "charmeleon":
				charmeleon_flamethrower_enemy.SetActive (true);
				break;
			case "ivysaur":
				ivysaur_hyperbeam_enemy.SetActive (true);
				break;
			case "dialga":
				RenderSettings.skybox = roar_of_time_MAT;
				break;
			case "hooh":
				RenderSettings.skybox = sunny_day_MAT;
				break;
			}
		}
		enemy_damage = false;
		enemy_attack_in_progress = true;
		//play the enemy attack

		timer = 0;
	}

	void PlayerDamage()
	{
		right_camera.SetActive (true);
		attack_camera.SetActive (false);

		switch (ActivePokemonScript.activePokemon_Player) {
		case "pikachu":
			pikachu_player_canvas_stuff.SetActive (true);
			pikachu_player_health.GetComponent<SpriteRenderer> ().enabled = true;
			HealthBar_Pikachu.health_ratio -= .25f;
			break;
		case "squirtle":
			squirtle_player_canvas_stuff.SetActive (true);
			squirtle_player_health.GetComponent<SpriteRenderer> ().enabled = true;
			HealthBar_Squirtle.health_ratio -= .25f;
			break;
		case "charmeleon":
			charmeleon_player_canvas_stuff.SetActive (true);
			charmeleon_player_health.GetComponent<SpriteRenderer> ().enabled = true;
			HealthBar_Charmeleon.health_ratio -= .25f;
			break;
		case "ivysaur":
			ivysaur_player_canvas_stuff.SetActive (true);
			ivysaur_player_health.GetComponent<SpriteRenderer> ().enabled = true;
			HealthBar_Ivysaur.health_ratio -= .25f;
			break;
		case "dialga":
			dialga_player_canvas_stuff.SetActive (true);
			dialga_player_health.GetComponent<SpriteRenderer> ().enabled = true;
			HealthBar_Dialga.health_ratio -= .25f;
			break;
		case "hooh":
			hooh_player_canvas_stuff.SetActive (true);
			hooh_player_health.GetComponent<SpriteRenderer> ().enabled = true;
			HealthBar_Hooh.health_ratio -= .25f;
			break;
		}

		if (enemy_attack_random_number == 0) {
			switch (ActivePokemonScript.activePokemon_Enemy) {
			case "pikachu":
				pikachu_thunder_enemy.SetActive (false);
				break;
			case "squirtle":
				squirtle_watergun_enemy.SetActive (false);
				break;
			case "charmeleon":
				charmeleon_fireblast_enemy.SetActive (false);
				break;
			case "ivysaur":
				ivysaur_razorleaf_enemy.SetActive (false);
				break;
			case "dialga":
				dialga_dragonbreath_enemy.SetActive (false);
				break;
			case "hooh":
				hooh_sacredfire_enemy.SetActive (false);
				break;
			}

		} else {
			switch (ActivePokemonScript.activePokemon_Enemy) 
			{
			case "pikachu":
				pikachu_shockwave_enemy.SetActive (false);
				break;
			case "squirtle":
				squirtle_bubble_enemy.SetActive (false);
				break;
			case "charmeleon":
				charmeleon_flamethrower_enemy.SetActive (false);
				break;
			case "ivysaur":
				ivysaur_hyperbeam_enemy.SetActive (false);
				break;
			case "dialga":
				RenderSettings.skybox = normal_skybox_MAT;
				break;
			case "hooh":
				RenderSettings.skybox = normal_skybox_MAT;
				break;
			}
		}

		enemy_attack_in_progress = false;
		player_damage = true;

		CheckForPlayerFaint ();
		timer = 0;
	}

	void CheckForPlayerFaint()
	{
		//check to see if the player has fainted after taking damage
		switch (ActivePokemonScript.activePokemon_Player) 
		{
		case "pikachu":
			if (HealthBar_Pikachu.health_ratio <= 0f) {
				Destroy (pikachu_player);
				Destroy (pikachu_player_canvas_stuff);
				left_pokeball.SetActive (true);
			}
			break;
		case "squirtle":
			if (HealthBar_Squirtle.health_ratio <= 0f) {
				Destroy(squirtle_player);
				Destroy (squirtle_player_canvas_stuff);
				left_pokeball.SetActive (true);
			}
			break;
		case "charmeleon":
			if (HealthBar_Charmeleon.health_ratio <= 0f) {
				Destroy (charmeleon_player);
				Destroy (charmeleon_player_canvas_stuff);
				left_pokeball.SetActive (true);
			}
			break;
		case "ivysaur":
			if (HealthBar_Ivysaur.health_ratio <= 0f) {
				Destroy (ivysaur_player);
				Destroy (ivysaur_player_canvas_stuff);
				left_pokeball.SetActive (true);
			}
			break;
		case "dialga":
			if (HealthBar_Dialga.health_ratio <= 0f) {
				Destroy (dialga_player);
				Destroy (dialga_player_canvas_stuff);
				left_pokeball.SetActive (true);
			}
			break;
		case "hooh":
			if (HealthBar_Hooh.health_ratio <= 0f) {
				Destroy (hooh_player);
				Destroy (hooh_player_canvas_stuff);
				left_pokeball.SetActive (true);
			}
			break;
		}
	}

	void CheckForEnemyFaint()
	{
		//check to see if the enemy has fainted after taking damage
		switch (ActivePokemonScript.activePokemon_Enemy) 
		{
		case "pikachu":
			if (HealthBar_Pikachu.health_ratio <= 0f) {
				Destroy (pikachu_enemy);
				Destroy (pikachu_enemy_canvas_stuff);
				left_pokeball.SetActive (true);
			}
			break;
		case "squirtle":
			if (HealthBar_Squirtle.health_ratio <= 0f) {
				Destroy(squirtle_enemy);
				Destroy (squirtle_enemy_canvas_stuff);
				left_pokeball.SetActive (true);
			}
				break;
		case "charmeleon":
			if (HealthBar_Charmeleon.health_ratio <= 0f) {
				Destroy (charmeleon_enemy);
				Destroy (charmeleon_enemy_canvas_stuff);
				left_pokeball.SetActive (true);
			}
			break;
		case "ivysaur":
			if (HealthBar_Ivysaur.health_ratio <= 0f) {
				Destroy (ivysaur_enemy);
				Destroy (ivysaur_enemy_canvas_stuff);
				left_pokeball.SetActive (true);
			}
			break;
		case "dialga":
			if (HealthBar_Dialga.health_ratio <= 0f) {
				Destroy (dialga_enemy);
				Destroy (dialga_enemy_canvas_stuff);
				left_pokeball.SetActive (true);
			}
			break;
		case "hooh":
			if (HealthBar_Hooh.health_ratio <= 0f) {
				Destroy (hooh_enemy);
				Destroy (hooh_enemy_canvas_stuff);
				left_pokeball.SetActive (true);
			}
			break;
		}
	}
		
}
