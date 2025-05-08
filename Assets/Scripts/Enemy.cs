using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootInterval = 2f;
    public float projectileSpeed = 10f;

    void Start()
    {
        InvokeRepeating(nameof(Shoot), 2f, shootInterval);
    }
    
    void Shoot()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        Vector3 targetPos = player.position;
        targetPos.y -= 0.1f;
        
        Vector3 dirToPlayer = (targetPos - firePoint.position).normalized;
        
        float dot = Vector3.Dot(transform.forward, dirToPlayer);
        if (dot > 0.7f)
        {
            GameObject proj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = proj.GetComponent<Rigidbody>();
            rb.linearVelocity = dirToPlayer * projectileSpeed;
        }
    }
}