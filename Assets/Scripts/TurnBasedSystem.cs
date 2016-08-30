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
	}
	
	// Update is called once per frame
	void Update () 
	{
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
			timer += Time.deltaTime;

			if (timer > 5f) 
			{
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

		//check for active pokemon and display attacks based on that
	}
		
	//the function called when the player clicks one of the attack buttons
	public void Attack()
	{
		choose_an_attack = false;
		attack_canvas.SetActive (false);
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
		right_camera.SetActive (true);
		left_camera.SetActive (false);
		overhead_camera.SetActive (false);

		overhead = false;
		attack_in_progress = true;


		//play the attack

		timer = 0;
	}

	void EnemyDamage()
	{
		left_camera.SetActive (true);
		right_camera.SetActive (false);
		overhead_camera.SetActive (false);

		attack_in_progress = false;
		enemy_damage = true;

		CheckForEnemyFaint ();
		timer = 0;
	}

	void Enemy_AttackInProgress()
	{
		enemy_damage = false;
		enemy_attack_in_progress = true;
		//play the enemy attack

		timer = 0;
	}

	void PlayerDamage()
	{
		right_camera.SetActive (true);
		left_camera.SetActive (false);
		overhead_camera.SetActive (false);

		enemy_attack_in_progress = false;
		player_damage = true;

		CheckForPlayerFaint ();
		timer = 0;
	}

	void CheckForPlayerFaint()
	{
		//check to see if a pokemon has fainted after damage
	}

	void CheckForEnemyFaint()
	{
		//check to see if the enemy has fainted after taking damage
	}
		
}
