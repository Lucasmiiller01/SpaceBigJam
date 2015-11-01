using UnityEngine;
using System.Collections;

public class FireManager : MonoBehaviour
{
    public float speed;
    private float startTime;
	public Vector3 target;

    void Start()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        startTime = Time.fixedTime;
    }


    void Move()
    {
		float step = 20 * Time.deltaTime;
		//this.transform.position = Vector3.Lerp(this.transform.position,target, step);
		transform.position = Vector3.MoveTowards(this.transform.position , target, step);
    }
    void FixedUpdate()
    {
        Move();
        if (Time.fixedTime - startTime > 8)
            Destroy(this.gameObject);
    }
}