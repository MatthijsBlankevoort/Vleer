using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowing : MonoBehaviour {

    public float lookRadius;
    public float speed;
    public  GameObject player;
    private Collider2D[] collidersInRadius;

	// Use this for initialization
	void Start () {
        //player = GameObject.FindGameObjectWithTag("Player");
	}

    void OnGizmoDraw ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, lookRadius);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        

        collidersInRadius = Physics2D.OverlapCircleAll(gameObject.transform.position, lookRadius);

        Debug.DrawRay(gameObject.transform.position, (player.transform.position - gameObject.transform.position), Color.black);

        foreach(Collider2D colliderInRadius in collidersInRadius)
        {
            if (colliderInRadius.gameObject == player)
            {
                RaycastHit2D hit =
                    Physics2D.Raycast(gameObject.transform.position, (player.transform.position - gameObject.transform.position));
                if (hit.collider.gameObject.tag == "Player")
                {
                    if (Vector3.Distance(transform.position, player.transform.position) > 1f)
                    {//move if distance from target is greater than 1
                        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                        transform.LookAt(player.transform.position);
                        transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                    }
                }

            }
        }
        
	}
}
