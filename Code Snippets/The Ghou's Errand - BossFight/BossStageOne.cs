using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageOne : State
{
    public BossStageTwo bossStageTwo;

    private BossHealth bossHealth;
    public GameObject bossObject;


    public override State RunCurrentState()
    {
        bossHealth = bossObject.GetComponent<BossHealth>(); //script to call the boss health into this script

        if (bossHealth.currentHealth <= 440) //checks the current health from the BossHealth script
        {
            return bossStageTwo;
        }
        else
        {

            bossObject.GetComponent<EnemyMovement>().enabled = true;
            return this;
        }
    }
}
