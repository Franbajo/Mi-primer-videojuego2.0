using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour {

	public Animator anim;
	public SpriteRenderer renderProta;
	public float speed;
	public int life;
	public GameObject particleDie;//PARA CUANDO MUERE EL PROTA HACE UNA EXPLOSIÓN DE SANGRE
	public Rigidbody2D rb;//Esta variable sirve para mover el personaje y evitar Bugs como encrustrarse entre colliders.
	public float horizontal;
	public float jumpForce;//Esta variable es para aplicar fuerza al salto
	/*PlayerController2 permisoSalto;*/
	public int permisoSato;
	public int maximoSaltos;


	// Use this for initialization
	void Start () { //Esto es una anotación puesta por Unity, no es C#
		anim=this.GetComponent<Animator>();
		anim.SetInteger("Life", life);
		anim.Play ("On Air");

		renderProta = this.GetComponent<SpriteRenderer> ();

		rb = this.GetComponent<Rigidbody2D> ();
		permisoSato = maximoSaltos;
	}
	
	// Update is called once per frame
	void Update () { 

		Vector3 realVelocity;
		realVelocity.x=speed*horizontal;
		realVelocity.y=rb.velocity.y;//La velocidad con la que vamos cayendo
		realVelocity.z=0;

		rb.velocity = realVelocity;

		/*ESTA PARTE ES PARA QUE EL PERSONAJE GIRE AL PULSAR IZQUIERDA*/
		if (horizontal > 0) {
			renderProta.flipX = false;
		} else if (horizontal < 0) {
			renderProta.flipX = true;
		}
			
		anim.SetFloat ("Walk Speed", Mathf.Abs(horizontal)); //Nos permite realizar el correr a la izquierda y derecha
		anim.SetFloat("Jump State", rb.velocity.y);//Aquí metemos el BlendTree del salto y hacemos referencia al parámetro Jump State.
		//Esta función sirve para cuando pulses el botón izquierdo del ratón haga hurt en el personaje.
		if (Input.GetMouseButtonDown (0)) {
			anim.Play ("hurt");
			life = Mathf.Clamp (--life, 0, 100);
			anim.SetInteger("Life", life);

			//EFECTO DE SANGRE
			if (life == 0) {
				Instantiate (particleDie, transform.position, Quaternion.identity);
			}
		}
	}

	public void Move(float dirX){
		horizontal = dirX;
	}

	public void Jump(){
		if (permisoSato > 0) {
			 //Aquí hacemos referencia al BlendTree del salto.
			rb.velocity = Vector3.zero;
			rb.AddForce (Vector3.up * jumpForce * rb.gravityScale * rb.mass, ForceMode2D.Impulse);
			anim.Play ("On Air");
			--permisoSato;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision){
		//Si el objeto que acaba de tocar
		if(collision.gameObject.tag == "Floor"){
			permisoSato = maximoSaltos;
			anim.Play ("Fall");
		}
	}

	private void OnCollisionExit2D(Collision2D collision){
		//Si el objeto que acaba de dejar de tocar
		if (collision.gameObject.tag == "Floor") {
			anim.Play("On Air");
		}
	}


}
