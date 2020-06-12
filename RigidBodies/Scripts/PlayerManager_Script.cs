using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager_Script : MonoBehaviour
{
    private GameObject _playerPrefab;
    private MainUI_Script _inputManager;
    public int _IDdata;

    // Responsible for the player
    private void Start()
    {
        _inputManager = GameObject.Find("GameManager").GetComponent<MainUI_Script>();
        _playerPrefab = _inputManager._playerPrefabs[_inputManager._playerPrefabID];
        _IDdata = _inputManager._playerPrefabID;
        _inputManager._playerPrefabID++;
        GameObject _spawnPlayer = Instantiate(_playerPrefab, transform.position, transform.rotation) as GameObject;
        _spawnPlayer.transform.parent = this.transform;
    }

    public void Respawn()
    {
        StartCoroutine(RespawnTimer());
    }

    IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(5);
        GameObject _spawnPlayer = Instantiate(_playerPrefab, transform.position, transform.rotation) as GameObject;
        _spawnPlayer.transform.parent = this.transform;
    }
}
