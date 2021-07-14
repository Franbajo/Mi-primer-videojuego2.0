using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour {

	public Animator anim;
	public SpriteRenderer myRenderer;
	public float speed;
	public float climbSpeed;
	public int life; //la variable que indica la salud o la sangre del prota
	// Use this for initialization
	public Rigidbody2D rb;
	public float horizontal;
	public float vertical;
	public float jumpForce;
	private float jumpForce2= 3;
	public int availableJump;
	public int maxJump;
	public bool m_FacingRight = true;
	//public bool jumpbool = false; //Variable que me va a servir para activar o descativar el jump.
	public bool diagLook = false; //Nos indicará si el jugador mira diagonalmente o no
	public bool UpLook = false; //Nos indicará si el jugador mira arriba o no PARA EL DISPARO HACIA ARRIBA... NO es para elI dle mirando arriba
	public bool firepoint = true;//Es una variable que me sirve para indicar que el personaje esta disparando quieto en el sitio
	public bool downLook = false; //Variable para apuntar hacia abajo
	public bool isOnStairs; //Variable que sirve para las escaleras... Se traduce por "estar sobre las escaleras"
	public bool quieto = false; //Variable que nos va a servir para movernos



	void Start () {
		anim = this.GetComponent <Animator>();
		anim.Play ("On Air"); //En esta línea le hemos dicho al animator que reproduzca como primera Animación la animación de caida del salto...
		anim.SetInteger ("Life", life);
		myRenderer = this.GetComponent <SpriteRenderer> ();
		rb = this.GetComponent<Rigidbody2D> ();  //Esto nos vale para chocarnos con las paredes
		anim = GetComponent<Animator>();
		availableJump = maxJump;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 realVelocity;
			realVelocity.x = speed * horizontal;
		//Aquí vamos a puntualizar algunos datos sobre la escalera y su código

		if (!isOnStairs) {
			realVelocity.y = rb.velocity.y;
		} else {
			realVelocity.y =  /*climbSpeed **/  vertical; //Ni idea de pq habia un climbSpeed, se lo he comentado y la escalera funciona perfectamente
		} 
			
		realVelocity.z =0;
		rb.velocity = realVelocity;


		anim.SetFloat ("Walk Speed", Mathf.Abs (horizontal)); /*Mathf.Abs, significa el valor absoluto de la variable float horizontal...
																Hay mas Math, como son el  round "redondeo clasico", floor "redondeo a la baja", etc, etc, etc.*/
		anim.SetFloat ("Jump State", rb.velocity.y);
		print (rb.velocity.y);
	
		//this.GetComponent<SpriteRenderer>().flipX = false;
		if (quieto = true) {
			horizontal = 0;
		} else if (quieto = false) {
			realVelocity.x = speed * horizontal;
		}
}
		
	//SALTO

	public void Jump()
	{
		if (availableJump > 0) {
		
			anim.Play ("On Air");
			rb.velocity = Vector3.zero;
			rb.AddForce (Vector3.up * jumpForce * rb.gravityScale * rb.mass, ForceMode2D.Impulse);
			availableJump--;

		} else if(availableJump <=0) {anim.Play ("Movement");}
	}

	//AHORA VAMOS A PONER UNA VARIABLE QUE SIRVE PARA SABER CUANDO EL PLAYER1 TOCA EL SUELO DE UNA PLATAFORMA
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Floor") 
		{
			availableJump = maxJump;
			anim.Play ("Movement");
		}
		if (collision.gameObject.tag == "platform") 
		{
			availableJump = maxJump;
			anim.Play ("Movement");
			this.transform.parent = collision.transform;
		}
	}
	//ESTOS DOS VOID de ACONTINUACIÓN son para las Escaleras... EN ESTE CASO ESTAMOS SIGUIENDO EL METODO DEL KUMBIERO GAFOTAS CALVO ARGENTINO

	private void OnTriggerStay2D (Collider2D collision) // Este primer void es para cuando el personaje toca la escalera... Con el tag escalera conseguimos que sea true  
	{
		if (collision.gameObject.tag == "escalera") {
			isOnStairs = true;
			rb.gravityScale = 0;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)// Este segundo void es para cuando el personaje deja de tocar la escalera...  
	{
		if (collision.gameObject.tag == "escalera") {
			isOnStairs = false;
			rb.gravityScale = 4;
		} 
	}
		

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Floor")
		{
			anim.Play("On Air");
		}
		if (collision.gameObject.tag == "platform")
		{
			anim.Play("On Air");
			this.transform.parent = null;
		}
	}
		

	public void Move(float dirX, float dirY) //Cuando especificamos dirX y dir Y hacemos referencia a las dos variables horizontal y vertical respectivamente.
	{
		//float vertical = Input.GetAxisRaw ("Vertical"); //Se supone que esto es si mueves el joystick hacia arriba va a estar reconociendo ese valor verical.

		horizontal = dirX;   //Aquí estamos diciendole a los float horizontal y vertical que se comporten como los floats dirX y dirY
		vertical = dirY;

		if (horizontal > 0 && !m_FacingRight) {
			Flip ();
		} else if (horizontal < 0 && m_FacingRight) {
			Flip ();
		} 
		//ESTE CODIGO ES PARA EL APUNTAR HACIA ARRIBA-INCLINADO
		if ((vertical > 0 && horizontal >0 )||(vertical > 0 && horizontal < 0 )) {
			diagLook = true;
			firepoint = false;
		} else if ((vertical <= 0 && horizontal <=0)||(vertical >= 0 && horizontal <= 0)){

			diagLook = false;
			firepoint = true;
		}


		//ESTE CODIGO ES PARA EL APUNTAR HACIA ARRIBA
		if (vertical > 0 && horizontal == 0) {
			UpLook = true;
			firepoint = false;
			downLook = false;
			diagLook = false;
		} if (vertical == 0) {
			UpLook = false;
			firepoint = true;
			downLook = false;
			diagLook = false;
		} if (vertical < 0) {
			UpLook = false;
			firepoint = false;
			downLook = true;
			diagLook = false;
		} if (vertical >0 && ((horizontal > 0)||(horizontal < 0))){
			UpLook = false;
			firepoint = false;
			downLook = false;
			diagLook = true;
		}
		//ESTE CODIGO ES PARA EL MIRAR HACIA ARRIBA...PERO NO EJECUTA LA ANIMACIÓN DEL SALTO CORRECTAMENTE... :c
	/*if (vertical > 0 && horizontal ==0) {
			anim.Play ("Look_Up");
		}if (vertical < 0 && horizontal == 0) {
			anim.Play ("PostIdle");
		} else if (vertical < 0 || horizontal <0 || horizontal >0 ) {
			anim.Play ("Movement");
		} if (vertical == 0) {
			anim.Play ("Movement");
		} 
	}*/


	}
			//PARENTESIS FINAL DEL VOID MOVE...NO BORRAR ESTE COMENTARIO, GUÍA UN MONTÓN */

		
	private void Flip() 
	{
		m_FacingRight = !m_FacingRight;
		transform.Rotate(0f, 180f, 0f); 
	} 


	/*public void EnemyJump(){
		anim.Play ("On Air");
		rb.AddForce (Vector3.up * jumpForce * rb.gravityScale * rb.mass, ForceMode2D.Impulse);
	
	}*/

	public void EnemyKnockBack(float enemyPosX){

		float side = Mathf.Sign (enemyPosX - transform.position.x);
		if (availableJump > 0) {

			anim.Play ("On Air");
			rb.velocity = Vector3.zero;
			rb.AddForce (Vector3.up * jumpForce * rb.gravityScale * rb.mass, ForceMode2D.Impulse);
			availableJump--;

		} else if(availableJump <=0) {
			anim.Play ("Movement");
		}
	
	}
}