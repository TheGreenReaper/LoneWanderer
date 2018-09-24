using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
	public GameObject ammo;
	public int range;
	public float attackCooldown;

	private GameObject target;
	private float attackTimer;
	// Use this for initialization
	void Start () {
		InvokeRepeating("FindEnemy",1,1);
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
			Shoot();
		}
	}
	void Shoot(){
		attackTimer+=Time.deltaTime;
		if(Vector2.Distance(target.transform.position,gameObject.transform.position) < 10 && attackTimer > attackCooldown){
			GameObject ammoInst = Instantiate(ammo,gameObject.transform.position,transform.rotation) as GameObject;
			ammoInst.GetComponent<Ammunition>().target = target;
			attackTimer =0;
		}
	}
	void FindEnemy(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach(GameObject enemy in enemies){
			if(Vector2.Distance(enemy.transform.position, gameObject.transform.position) < range){
				target = enemy;
				break;
			}
		}
	}
}
