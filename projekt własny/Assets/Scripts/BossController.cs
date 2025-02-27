using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public int bossPhase;
    public bool bossJustSpawned;

    public float arrivalDuration;
    public float arrivalDurationMax;
    public float bossArrivalSpeed;

    public float phaseDuration;
    public float phaseDurationMax;


    void Start()
    {
        BossBulletSpawner.bossController = this;
        bossPhase = 0;
        bossJustSpawned = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (bossJustSpawned == true)
        {
            BossArrival();
        }
    }
    public void BossArrival()
    {
        arrivalDuration += Time.deltaTime;
        if (arrivalDuration >= arrivalDurationMax)
        {
            bossJustSpawned = false;
            bossPhase = 1;
        }
        else
        {
            transform.Translate(bossArrivalSpeed * Time.deltaTime * Vector2.right, Space.World);
        }
    }
    public void BossPhaseChange()
    {
        phaseDuration += Time.deltaTime;
        if (phaseDuration >= phaseDurationMax)
        {

        }
        else
        {

        }
    }


}
