using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : MonoBehaviour {
	public GameObject target;
	public float speed;
	public int damage;
	Vector2 currentPosition;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

		if(target != null){
			//Lookat
			Vector3 diff = target.transform.position - transform.position;
			diff.Normalize();
			float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
			//Lookat
			currentPosition = gameObject.transform.position;
			transform.position = Vector2.MoveTowards(currentPosition, target.transform.position, speed * Time.deltaTime);
		} else {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Enemy"){
			other.GetComponent<NPCore>().TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}
