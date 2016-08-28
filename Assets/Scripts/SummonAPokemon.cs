using UnityEngine;
using System.Collections;

public class SummonAPokemon : MonoBehaviour {

	float timer;

	public GameObject particle_system_right;
	public GameObject particle_system_left;

	public GameObject pokeball_left;
	public GameObject pokeball_right;

	public GameObject pikachu_left;
	public GameObject squirtle_left;
	public GameObject charmeleon_left;
	public GameObject ivysaur_left;
	public GameObject hooh_left;
	public GameObject dialga_left;

	public GameObject pikachu_right;
	public GameObject squirtle_right;
	public GameObject charmeleon_right;
	public GameObject ivysaur_right;
	public GameObject hooh_right;
	public GameObject dialga_right;


	// Use this for initialization
	void Start () 
	{
		timer = 0f;

		particle_system_right.SetActive (false);
		particle_system_left.SetActive (false);

		pokeball_left.SetActive (false);
		pokeball_right.SetActive (false);

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
			particle_system_right.SetActive (true);
			particle_system_left.SetActive (true);
		}

		if (timer > 4.8f) 
		{
			
		}
	}
}
