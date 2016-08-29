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

	public Camera overhead_camera;
	public Camera left_camera;
	public Camera right_camera;

	public GameObject left_canvas;
	public GameObject right_canvas;

	public int switch_count;

	bool first_active;

	public GameObject left_pokeball;
	public GameObject right_pokeball;

	bool start_enemy_stuff;
	float enemy_timer;

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

		left_camera.enabled = false;
		right_camera.enabled = false;
		overhead_camera.enabled = true;

		switch_count = 0;

		first_active = true;

		left_pokeball.SetActive (false);
		right_pokeball.SetActive (false);

		start_enemy_stuff = false;

		enemy_timer = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (first_active) {
			game_timer += Time.deltaTime;

			if (game_timer < 5f) {
				overhead_camera.enabled = true;
			} 
			else if (game_timer > 10f) {
				EnableLeftCamera ();
				first_active = false;
			}
			else if (game_timer > 5f) {
				EnableRightCamera ();
				overhead_camera.enabled = false;
//				start_enemy_stuff = true;

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
	}

	void EnableLeftCamera()
	{
		left_camera.enabled = true;
		overhead_camera.enabled = false;
		right_camera.enabled = false;

		if (switch_count == 0) {
			left_pokeball.SetActive (true);
		} else if (switch_count >= 1) {
			left_canvas.SetActive (true);
		}

		switch_count++;
	}

	void EnableRightCamera()
	{
		right_camera.enabled = true;
		overhead_camera.enabled = false;
		left_camera.enabled = false;

		if (switch_count == 0) 
		{
			right_pokeball.SetActive (true);
		}else if (switch_count >= 1) {
			right_canvas.SetActive (true);
		}
	}
}
