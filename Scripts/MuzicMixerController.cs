using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;
using Unity.VisualScripting;

public class MuzicMixerController : MonoBehaviour
{
    public AudioMixer mixer;
    public GameObject window;
    public Slider masterSlider;
    public Slider SfxSlider;
    public Slider musicSlider;

    [Header("All Menu's")]
   
   
    public GameObject ObjectiveMenuUI;

    public static bool GameIsStopped = false;


    void SetSliders()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        SfxSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            mixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
            mixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
            mixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));

            SetSliders();
        }
        else
        {
            SetSliders() ;
        }
    }

    public void UpdateMasterVolume()
    {
        mixer.SetFloat("MasterVolume",masterSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
    }

    public void UpdateMusicVolume()
    {
        mixer.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }

    public void UpdaateSFXVolume()
    {
        mixer.SetFloat("SFXVolume", SfxSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", SfxSlider.value);
    }


    private void Update()
    {
        if (Input.GetKeyDown("v"))
        {
            if (GameIsStopped)
            {
                removeObjectives();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                showObjecttives();
                Cursor.lockState = CursorLockMode.None;
            }
        }

    }

    public void showObjecttives()
    {
        ObjectiveMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsStopped = true;
    }

    public void removeObjectives()
    {
        ObjectiveMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        GameIsStopped = false;
    }



}
