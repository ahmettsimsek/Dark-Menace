using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalObjective : MonoBehaviour
{
    [Header("Vehicle Button")]
    [SerializeField] private KeyCode vehicleButton = KeyCode.F;

    [Header("Generator Sound Effects and radius")]
    private float radius = 3f;
    public PlayerScript player;



    private void Update()
    {
        if (Input.GetKeyDown(vehicleButton) && Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Final");
            //objective complete
            ObjectivesComplete.occurrence.GetObjectivesDone(true, true, true, true);
        }
    
    }

}
