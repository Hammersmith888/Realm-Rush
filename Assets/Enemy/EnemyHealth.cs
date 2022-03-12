using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Enemy))]

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoints = 0;
    Enemy enemy;
    void Start()
    {
        enemy = GetComponent<Enemy>();
        currentHitPoints = maxHitPoints;
    }
    void OnParticleCollision(GameObject other) {
        ProcessHit();

    }
    void ProcessHit(){
        currentHitPoints--;

        if(currentHitPoints <= 0){
            Destroy(gameObject);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }

    
}
