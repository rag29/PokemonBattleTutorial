using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameState : MonoBehaviour {

	public static bool one_set;
	public static bool two_set;
	public static bool three_set;

	public static bool enemy_1_summoned;
	public static bool enemy_2_summoned;
	public static bool enemy_3_summoned;

	public static bool player_1_summoned;
	public static bool player_2_summoned;
	public static bool player_3_summoned;

	float game_timer;

	public GameObject overhead_camera;
	public GameObject left_camera;
	public GameObject right_camera;

	public GameObject left_canvas;
	public GameObject right_canvas;

	public int switch_count;

	bool first_active;

	public GameObject left_pokeball;
	public GameObject right_pokeball;

	bool start_enemy_stuff;
	float enemy_timer;

	bool player_pkmn_summon;

	public GameObject turn_based_system;

	// Use this for initialization
	void Start () 
	{
		one_set = false;
		two_set = false;
		three_set = false;

		enemy_1_summoned = false;
		enemy_2_summoned = false;
		enemy_3_summoned = false;

		player_1_summoned = false;
		player_2_summoned = false;
		player_3_summoned = false;

		game_timer = 0f;

		left_camera.SetActive(false);
		right_camera.SetActive(false);
		overhead_camera.SetActive(true);

		switch_count = 0;

		first_active = true;

		left_pokeball.SetActive (false);
		right_pokeball.SetActive (false);

		start_enemy_stuff = false;

		enemy_timer = 0f;

		player_pkmn_summon = false;

		turn_based_system.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		game_timer += Time.deltaTime;

		if (game_timer > 20f) {
			//activate the state machine
			turn_based_system.SetActive(true);
		}
		if (game_timer > 17f) {
			left_pokeball.SetActive (false);
		}
		else if (game_timer > 12f) 
		{
			EnableLeftCamera ();
			DisableRightCamera ();
			left_pokeball.SetActive (true);
		}
		else if (game_timer > 10f) 
		{
			right_pokeball.SetActive (false);
		}
		else if (game_timer > 5f) 
		{
			EnableRightCamera ();
			overhead_camera.SetActive (false);
			right_pokeball.SetActive (true);
		}
			
	}

//		if (start_enemy_stuff) 
//		{
//			enemy_timer += Time.deltaTime;
//
//			if (enemy_timer > 4f) {
//				EnableLeftCamera ();
//			}
//		}


	void EnableLeftCamera()
	{
		
		left_camera.SetActive(true);

		if (switch_count == 0) {
			left_pokeball.SetActive (true);

		} else if (switch_count >= 1) {
			left_canvas.SetActive (true);
		}

		switch_count++;
	}

	void EnableRightCamera()
	{

		right_camera.SetActive(true);

		if (switch_count == 0) 
		{
			
		}else if (switch_count >= 1) {
			right_canvas.SetActive (true);
		}
	}

	void DisableRightCamera()
	{
		right_camera.SetActive(false);
	}

	void DisableLeftCamera()
	{
		left_camera.SetActive(false);
	}


}
