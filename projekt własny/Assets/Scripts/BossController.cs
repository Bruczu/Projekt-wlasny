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
    public float phaseDurationMaxShort;


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
        BossPhaseChange();
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
        if ((bossPhase == 1) || (bossPhase == 2) || (bossPhase == 3))
        {
            phaseDuration += Time.deltaTime;
            if (phaseDuration >= phaseDurationMax)
            {
                phaseDuration = 0;
                bossPhase++;
            }
        }
        if ((bossPhase == 4) || (bossPhase == 5) || (bossPhase == 6))
        {
            phaseDuration += Time.deltaTime;
            if (phaseDuration >= phaseDurationMaxShort)
            {
                phaseDuration = 0;
                bossPhase++;
            }
        }
        if (bossPhase == 7)
        {
            phaseDuration += Time.deltaTime;
            if (phaseDuration >= phaseDurationMaxShort)
            {
                phaseDuration = 0;
                bossPhase = 1;
            }
        }
    }
}
