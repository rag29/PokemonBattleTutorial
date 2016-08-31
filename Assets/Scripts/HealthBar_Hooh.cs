using UnityEngine;
using System.Collections;

public class HealthBar_Hooh : MonoBehaviour {

	float original_health_value;
	float new_health_value;
	float difference_between_health_values;

	GameObject health_sprite;

	float original_health_x;
	public static float health_ratio;
	float health_y_scale;
	float health_z_scale;

	SpriteRenderer renderer;

	public Material redMat;
	public Material yellowMat;
	public Material greenMat;

	// Use this for initialization
	void Start () 
	{
		health_sprite = this.gameObject;
		renderer = this.gameObject.GetComponent<SpriteRenderer> ();

		original_health_x = health_sprite.transform.localScale.x;
		health_y_scale = health_sprite.transform.localScale.y;
		health_z_scale = health_sprite.transform.localScale.z;

		health_ratio = 1f;


	}
	
	// Update is called once per frame
	void Update () 
	{
		original_health_value = health_sprite.GetComponent<Renderer>().bounds.min.x;
		health_sprite.transform.localScale = new Vector3 (original_health_x * health_ratio, health_y_scale, health_z_scale); 
		new_health_value = health_sprite.GetComponent<Renderer>().bounds.min.x;
		difference_between_health_values = new_health_value - original_health_value;
		health_sprite.transform.Translate(new Vector3(-difference_between_health_values, 0f, 0f));

		if (health_ratio < 0.25f) {
			renderer.material = redMat;
		} else if (health_ratio < 0.5f) {
			renderer.material = yellowMat;
		} 
		else 
		{
			renderer.material = greenMat;
		}
		if (health_ratio <= 0) 
		{
			Destroy (this.gameObject);
		}
	}
}
