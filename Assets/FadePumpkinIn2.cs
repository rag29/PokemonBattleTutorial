using UnityEngine;
using System.Collections;

public class FadePumpkinIn2 : MonoBehaviour {

	SkinnedMeshRenderer rend;
	Color c;
	bool running;

	// Use this for initialization
	void Start () {

		rend = this.gameObject.GetComponent<SkinnedMeshRenderer> ();

		running = true;

		foreach (Material mat in rend.materials) 
		{
			c = rend.material.color;
			c.a = 0f; 
		}
	}

	// Update is called once per frame
	void Update () 
	{
		//if (StateMachine_FinalCutscene.fade2 && running) 
		//{
		//	StartCoroutine ("FadeOut");
		//}


	}

	public IEnumerator FadeOut()
	{
		for (float f = 0f; f <= 1f; f += 0.1f) {

			c = rend.materials [0].color;
			c.a = f;
			rend.materials [0].color = c;

			c = rend.materials [1].color;
			c.a = f;
			rend.materials [1].color = c;

			c = rend.materials [2].color;
			c.a = f;
			rend.materials [2].color = c;

			c = rend.materials [3].color;
			c.a = f;
			rend.materials [3].color = c;

			yield return new WaitForSeconds (.1f);
		}

		//StateMachine_FinalCutscene.fade2 = false;
		running = false;




	}
}