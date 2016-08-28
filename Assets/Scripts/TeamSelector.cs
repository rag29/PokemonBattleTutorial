﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeamSelector : MonoBehaviour {

	/*
	This script is attached to each of the 6 pokemon you can select on the team select screen. 
	It handles when a user mouses over choices as well as selects them
	It keeps track of the pokemon selected and the order they were selected in
	*/

	private GameObject pikachu_choice;
	private GameObject squirtle_choice;
	private GameObject charmeleon_choice;
	private GameObject ivysaur_choice;
	private GameObject hooh_choice;
	private GameObject dialga_choice;

	private GameObject one;
	private GameObject two;
	private GameObject three;

	private bool active; //keeps track of if this particular pokemon has already been chosen

	List<string> all_possible_pokemon;

	// Use this for initialization
	void Start ()
	{
		pikachu_choice = GameObject.FindGameObjectWithTag ("pikachu_choice");
		squirtle_choice = GameObject.FindGameObjectWithTag ("squirtle_choice");
		charmeleon_choice = GameObject.FindGameObjectWithTag ("charmeleon_choice");
		ivysaur_choice = GameObject.FindGameObjectWithTag ("ivysaur_choice");
		hooh_choice = GameObject.FindGameObjectWithTag ("hooh_choice");
		dialga_choice = GameObject.FindGameObjectWithTag ("dialga_choice");

		one = this.gameObject.transform.GetChild (1).gameObject;
		two = this.gameObject.transform.GetChild (2).gameObject;
		three = this.gameObject.transform.GetChild (3).gameObject;

		active = false;

		all_possible_pokemon = new List<string>();

		all_possible_pokemon.Add("pikachu");
		all_possible_pokemon.Add("squirtle");
		all_possible_pokemon.Add("charmeleon");
		all_possible_pokemon.Add("ivysaur");
		all_possible_pokemon.Add("hooh");
		all_possible_pokemon.Add("dialga");

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnMouseEnter()
	{
		if (!active)
		{
			this.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		}

	}

	void OnMouseExit()
	{
		if (!active) 
		{
			this.gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		}
	}

	void OnMouseDown()
	{
		if (!GameState.one_set && !active) {
			
			one.GetComponent<SpriteRenderer> ().enabled = true;
			GameState.one_set = true;

			switch(this.gameObject.tag)
			{
				case "pikachu_choice":
					GameState.player_team.Add("pikachu");
					break;
				case "squirtle_choice":
					GameState.player_team.Add("squirtle");
					break;
				case "charmeleon_choice":
					GameState.player_team.Add("charmeleon");
					break;
				case "ivysaur_choice":
					GameState.player_team.Add("ivysaur");
					break;
				case "hooh_choice":
					GameState.player_team.Add("hooh");
					break;
				case "dialga_choice":
					GameState.player_team.Add("dialga");
					break;
			}

			active = true;

		} else if (!GameState.two_set && !active) {
			two.GetComponent<SpriteRenderer> ().enabled = true;
			GameState.two_set = true;

			switch(this.gameObject.tag)
			{
			case "pikachu_choice":
				GameState.player_team.Add("pikachu");
				break;
			case "squirtle_choice":
				GameState.player_team.Add("squirtle");
				break;
			case "charmeleon_choice":
				GameState.player_team.Add("charmeleon");
				break;
			case "ivysaur_choice":
				GameState.player_team.Add("ivysaur");
				break;
			case "hooh_choice":
				GameState.player_team.Add("hooh");
				break;
			case "dialga_choice":
				GameState.player_team.Add("dialga");
				break;
			}

			active = true;

		} else if (!GameState.three_set && !active) {
			three.GetComponent<SpriteRenderer> ().enabled = true;
			GameState.three_set = true;

			switch(this.gameObject.tag)
			{
			case "pikachu_choice":
				GameState.player_team.Add("pikachu");
				break;
			case "squirtle_choice":
				GameState.player_team.Add("squirtle");
				break;
			case "charmeleon_choice":
				GameState.player_team.Add("charmeleon");
				break;
			case "ivysaur_choice":
				GameState.player_team.Add("ivysaur");
				break;
			case "hooh_choice":
				GameState.player_team.Add("hooh");
				break;
			case "dialga_choice":
				GameState.player_team.Add("dialga");
				break;
			}

			foreach (string obj in GameState.player_team) 
			{
				print ("player" + obj);
			}

			foreach (string str in all_possible_pokemon) 
			{
				if(!GameState.player_team.Contains(str))
				{
					GameState.enemy_team.Add (str);
				}
			}

			foreach (string obj in GameState.enemy_team) 
			{
				print ("enemy" + obj);
			}

			active = true;

		} else {
			
		}



	}
}
