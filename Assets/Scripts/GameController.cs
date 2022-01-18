using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int wallCount;

    private Manager manager;

    private void Start()
    {
        manager = Manager.Get;
    }

    public void ReloadLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

  
    public void StartGame()
    {
        wallCount = 0;
        NewGameStep();
    }
    public void EndGame()
    {
        Manager.Get.ReloadButton.SetActive(true);
        DisableScripts();
    }

    public void GameStepHendler()
    {
        wallCount++;

        if (wallCount > 3)
        {
            EndGame();
            return;
        }

        DisableScripts();
        manager.HouseRotate.Rotate();
        manager.HouseRotate.EndRotate = NewGameStep;


    }

    public void NewGameStep()
    {
        manager.Wall = manager.House.GetComponent<House>().Walls[wallCount];
        manager.CreatePlayer.InstantiatePlayer();
        StartCoroutine(EnableScripts());
    }

    

    private IEnumerator EnableScripts()
    {
        yield return new WaitForEndOfFrame();
        manager.InputSystem.Enable();
        manager.MoveSystem.Enable();
        manager.Draw.Enable(wallCount);
    }

    private void DisableScripts()
    {
        manager.InputSystem.Disable();
        manager.MoveSystem.Disable();
        manager.Draw.Disable();
    }




}
