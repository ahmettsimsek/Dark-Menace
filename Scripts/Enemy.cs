using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Enmy Health and Damage")]
    private float enemyHealth = 120f;
    private float presentHealth;
    public float giveDamage = 5f;
    public HealthBar healthBar;

    [Header("Enmy Things")]
    public NavMeshAgent enemyAgent;
    public Transform LookPoint;
    public Camera ShootingRaycastArea;
    public Transform playerBody;
    public LayerMask PlayerLayer;

    [Header("Enmy Guarding Var")]
    public GameObject[] walkPoints;
    int currentEnemyPosition = 0;
    public float enemySpeed;
    float walkingpointRadius = 2;

    [Header("Sounds and UI")]
    public AudioClip shootingSound;
    public AudioSource audioSource;

    [Header("Enemy Shooting Var")]
    public float timebtwShoot;
    bool previouslyShoot;

    [Header("Enemy Animation and Spark effect")]
    public Animator anim;
    public ParticleSystem muzzleSpark;

    [Header("Enemy mood/ situation")]
    public float visionRadius;
    public float shootingRadius;
    public bool playerInVisionRadius;
    public bool playerInshootingRadius;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        presentHealth = enemyHealth;
        healthBar.GivefulHealth(enemyHealth);

        playerBody = GameObject.Find("Player").transform;
        enemyAgent = GetComponent<NavMeshAgent>();      
    }

    private void Update()
    {
        playerInVisionRadius = Physics.CheckSphere(transform.position,visionRadius,PlayerLayer);
        playerInshootingRadius = Physics.CheckSphere(transform.position,shootingRadius,PlayerLayer);

        if (!playerInVisionRadius && !playerInshootingRadius) Guard();
        if (playerInVisionRadius && !playerInshootingRadius) Pursueplayer();
        if (playerInVisionRadius && playerInshootingRadius) ShootPlayer();
    }

    private void Guard()
    {
        if (Vector3.Distance(walkPoints[currentEnemyPosition].transform.position,transform.position) < walkingpointRadius)
        {
            currentEnemyPosition = Random.Range(0, walkPoints.Length);
            if(currentEnemyPosition >= walkPoints.Length)
            {
                currentEnemyPosition = 0;

            }
        }

        transform.position = Vector3.MoveTowards(transform.position, walkPoints[currentEnemyPosition].transform.position, Time.deltaTime * enemySpeed);
        //changing enemy facing
        transform.LookAt(walkPoints[currentEnemyPosition].transform.position);
    }

    private void Pursueplayer()
    {
        if (enemyAgent.SetDestination(playerBody.position))
        {
            //animation
            anim.SetBool("Walk", false);
            anim.SetBool("AimRun", true);
            anim.SetBool("Shoot", false);         
            anim.SetBool("Die", false);

            //+vision and shooting radius
            visionRadius = 30f;
            shootingRadius = 16f;
        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("AimRun", false);
            anim.SetBool("Shoot", false);        
            anim.SetBool("Die", true);

        }
    }

    private void ShootPlayer()
    {
        enemyAgent.SetDestination(transform.position);

        transform.LookAt(LookPoint);

        if (!previouslyShoot)
        {

            muzzleSpark.Play();
            audioSource.PlayOneShot(shootingSound);

            RaycastHit hit;
            if (Physics.Raycast(ShootingRaycastArea.transform.position, ShootingRaycastArea.transform.forward, out hit, shootingRadius))
            {
                Debug.Log("Shooting" + hit.transform.name);

                PlayerScript playerBody = hit.transform.GetComponent<PlayerScript>();

                if(playerBody != null) 
                {
                    playerBody.playerHitDamage(giveDamage);
                }
                anim.SetBool("Shoot", true);
                anim.SetBool("Walk", false);
                anim.SetBool("AimRun", false);              
                anim.SetBool("Die", false);

            }

            previouslyShoot = true;
            Invoke(nameof(ActiveShooting), timebtwShoot);

        }
    }

    private void ActiveShooting()
    {
        previouslyShoot = false;
    }

    public void enemyHitDamage(float takeDamage)
    {
        presentHealth -= takeDamage;
        healthBar.SetHealth(presentHealth);
        //+vision and shooting radius
        visionRadius = 40f;
        shootingRadius = 19f;

        if (presentHealth < 0)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("AimRun", false);
            anim.SetBool("Shoot", false);         
            anim.SetBool("Die", true);

            enemyDie();
        }
    }

    private void enemyDie()
    {
        enemyAgent.SetDestination(transform.position);
        enemySpeed = 0f;
        shootingRadius = 0f;
        visionRadius = 0f;
        playerInVisionRadius = false;
        playerInshootingRadius = false;
        Object.Destroy(gameObject, 5.0f);
    }
}
