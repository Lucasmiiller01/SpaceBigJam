using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {


	public Transform target; 
	public GameObject shoot_;

	// behavior de inimigos
	public bool followPosition;
	public bool Enemy_shoot; 
	public bool Enemy_Explosion; 

	// speed do enemy 
	public float speed;
	// tempo do tiro 
	private float waitShoot;
	// tempo da explosao 
	private float timeShine;
	private int beforeExploding = 0;


	void FixedUpdate () {
		if(followPosition) follow ();

		if(Enemy_shoot) EnemyShoot ();

		if (Enemy_Explosion) Explosion ();

	}
	// ir ate a posiçao de um objeto no caso o Player
	void follow() {

		float step = speed * Time.deltaTime;

		transform.position = Vector3.MoveTowards(this.transform.position = new Vector3(transform.position.x,transform.position.y, target.position.z), target.position = new Vector3(target.position.x, target.position.y,this.target.position.z), step);
	}

	void Explosion() {

		// Depois de meio segundo troca a cor pra amarelo e depois volta pra Red LINDO
		if (Time.fixedTime - timeShine > 0.5f)
		{
			this.GetComponent<SpriteRenderer>().color = Color.yellow;

			if(Time.fixedTime - timeShine > 1f)
			{
				this.GetComponent<SpriteRenderer>().color = Color.red; 
				beforeExploding ++;
				timeShine = Time.fixedTime;
			}
		}
		// depois de 4 segundos explode 
		if (beforeExploding.Equals (4))
			Destroy (gameObject);
		
	}
	// Atirar e ajusta automaticamente a direçao do tiro 

	// atira em intervalos de meio segundo
	void EnemyShoot() {
		
		if (Time.fixedTime - waitShoot > 0.5f)
		{
			waitShoot = Time.fixedTime;
			// instanciando tiro
			GameObject shoot;
			shoot = (GameObject)Instantiate(shoot_, this.transform.position, Quaternion.identity);
			Vector2 direction_shoot;

			// Ajustando direction do tiro
			if(this.transform.position.x > target.position.x) direction_shoot = new Vector2 (-50,-50);
			else direction_shoot = new Vector2 (50f,50f);

			// Add força no tiro
			shoot.GetComponent<Rigidbody2D>().AddForceAtPosition(direction_shoot, target.position,ForceMode2D.Force);
		}
	}
}
