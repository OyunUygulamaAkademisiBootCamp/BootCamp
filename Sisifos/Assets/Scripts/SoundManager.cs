using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Player componenti ile baðlanacak.
    //audio source'un bulunduðu objeyi tanýmlamayý unutma

    

  

    public AudioSource playerSounds;
    [SerializeField] AudioClip collectPositive, collectNegative, finishLine, playerDeath, failedLevel, pushBoulder, brokenBones, sisifosScream;


 
    


    public void CollectPositive()
    {
        playerSounds.clip = collectPositive;
        playerSounds.Play();
    }
   
    public void CollectNegative()
    {
        playerSounds.clip = collectNegative;
        playerSounds.Play();

    }

    public void FinishLine()
    {
        playerSounds.clip = finishLine;
        playerSounds.Play();

    }

    public void PlayerDeath()
    {
        playerSounds.clip = playerDeath;
        playerSounds.Play();

    }

    public void FailedLevel()
    {
        playerSounds.clip = failedLevel;
        playerSounds.Play();

    }

    public void PushBoulder()
    {
        playerSounds.clip = pushBoulder;
        playerSounds.Play();
    }

    public void BrokenBones()
    {
        playerSounds.clip = brokenBones;
        playerSounds.Play();
    }

    public void SisifosScream()
    {
        playerSounds.clip = sisifosScream;
        playerSounds.Play();
    }





}
