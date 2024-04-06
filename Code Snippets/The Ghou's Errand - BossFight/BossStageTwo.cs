using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageTwo : State
{
    public BossStageThree bossStageThree;

    private BossHealth bossHealth;
    public GameObject bossObject;

    public override State RunCurrentState()
    {
        bossHealth = bossObject.GetComponent<BossHealth>(); //Calls the boss health into this script

        if (bossHealth.currentHealth <= 200)
        {
            return bossStageThree;
        }
        else
        {
            bossObject.GetComponent<BossShooting>().enabled = true;
            return this;
        }
    }
}
