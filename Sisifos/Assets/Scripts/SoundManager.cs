using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    //Player componenti ile ba�lanacak.
    //audio source'un bulundu�u objeyi tan�mlamay� unutma
    
    private AudioSource playerSounds;
    [SerializeField] AudioClip collectPositive, collectNegative, finishLine, playerDeath, failedLevel, pushBoulder, brokenBones, sisifosScream;

    void Start()
    {
        playerSounds = gameObject.GetComponent<AudioSource>();
    }

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
