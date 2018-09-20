using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	// Use this for initialization
	public void MakeMove()
    {
        StartCoroutine("Attack");
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Stats>().Attack();
        StartCoroutine("EndTurn");
    }
    IEnumerator EndTurn()
    {
        yield return new WaitForSeconds(1);
        Camera.main.GetComponent<Battleground>().ChangeTurn();
    }
}
