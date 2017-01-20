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
                    Vector3 dir = player.transform.position - gameObject.transform.position;
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    gameObject.transform.Translate(new Vector3(gameObject.transform.forward.x * speed, gameObject.transform.forward.y * speed , 0));
                }
            }
        }
        
	}
}
