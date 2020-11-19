using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    public float attackDelay;
    private Transform target;

    private float lastAttackTime;
    public GameObject projectile;
    public float projectileForce;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update() {
        
        Vector3 targetDir = target.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);

        if(Time.time > lastAttackTime + attackDelay) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 7);

            Debug.DrawRay(transform.position, transform.up, Color.green);
            Debug.Log(hit.transform);
            
            if(hit.transform == target) {
            
                GameObject projectileItem = Instantiate(projectile, transform.position, transform.rotation);
                projectileItem.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, projectileForce));
                lastAttackTime = Time.time;

                StartCoroutine(DestroyProjectile(projectileItem));
            }
        }
    }

    private IEnumerator DestroyProjectile(GameObject projectileItem) {
        if(projectileItem != null) {
            yield return new WaitForSeconds(3f);
            Destroy(projectileItem);
        }
    }
}
