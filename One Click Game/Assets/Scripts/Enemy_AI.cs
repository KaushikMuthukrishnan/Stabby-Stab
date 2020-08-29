using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    public Transform player;
    public Collider sword;
    public ParticleSystem deathParticles;
    public GameObject titleP, gameP, deathP;
    MeshRenderer mesh;
    Collider coll;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        deathParticles = GetComponent<ParticleSystem>();
        mesh = GetComponent<MeshRenderer>();
        coll = GetComponent<Collider>();
    }

    void Update()
    {
        agent.destination = player.position;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider == sword)
        {
            if (Movement.attackable)
            {
                EnemySpawn.Score += 100;
                deathParticles.Play();
                mesh.enabled = false;
                coll.enabled = false;
            }
            else
            {
                OnDeath();
            }
        }
            
        if (collision.transform == player)
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        gameP.SetActive(false);
        deathP.SetActive(true);
        player.gameObject.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }
}
