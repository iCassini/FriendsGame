using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed;
	public float jumpPower;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A)) 
			transform.position += Vector3.left * speed * Time.deltaTime;

		if (Input.GetKey(KeyCode.D)) 
			transform.position += Vector3.right * speed * Time.deltaTime;
	}

	void OnCollisionStay2D(Collision2D coll){
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		if (coll.gameObject.tag == "Ground" && Input.GetKey(KeyCode.W))
			rb.AddForce(Vector3.up * jumpPower);

		//Quando encostar na plataforma
		if (coll.gameObject.tag == "Plataforma" && Input.GetKey(KeyCode.W))
			rb.AddForce(Vector3.up * jumpPower);
        
        //Quando encostar na alavanca
        if (coll.gameObject.name == "botao-porta-topo" && Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.up * jumpPower);

        //Quando colidir com o muro azul
        if (coll.gameObject.name == "muro-azul-vertical") { 
            Debug.Log("Tocou no muro");

        }

    }

}
