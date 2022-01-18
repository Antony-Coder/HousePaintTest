using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector3 startPosition = new Vector3(0.5f, 0.5f, -0.5f);

    public void InstantiatePlayer()
    {
        if (Manager.Get.Player != null) Destroy(Manager.Get.Player.gameObject);

        GameObject player = Instantiate(playerPrefab);
        player.transform.parent = Manager.Get.Wall.transform;
        player.transform.localPosition = startPosition;
        player.transform.eulerAngles = Vector3.zero;


        player.transform.eulerAngles = Vector3.zero;

        Manager.Get.Player = player.transform;

    }



}
