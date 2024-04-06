using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageThree : State
{

    public GameObject bossObject;
    public override State RunCurrentState()
    {

        bossObject.GetComponent<BossFightController>().enabled = true;
        return this;
    }
}
