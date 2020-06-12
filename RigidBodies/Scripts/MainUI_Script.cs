using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainUI_Script : MonoBehaviour
{
    public Volume_Script _sfxScript;
    public Volume_Script _musicScript;
    private int _trackID;

    public Image _img;
    public Sprite[] _sprites;
    public string[] _scenes;
    private int _levelID;
    public List<GameObject> _playerPrefabs;
    public GameObject[] _prefabOptions;
    public int _playerPrefabID;


    private void Awake()
    {
        _trackID = Random.Range(0, 6);

        _levelID = 0;
        _img.sprite = _sprites[_levelID];

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        _playerPrefabID = 0;
        StartCoroutine(MusicPlayer());
    }

    IEnumerator MusicPlayer()
    {
        _musicScript._audio.clip = _musicScript._audioClip[_trackID];
        _musicScript._audio.Play();
        yield return new WaitForSeconds(_musicScript._audioClip[_trackID].length);
        _trackID++;
        StartCoroutine(MusicPlayer());
    }

    // Close game
    public void QuitGame()
    {
        _sfxScript._audio.clip = _sfxScript._audioClip[0];
        _sfxScript._audio.Play();
        Application.Quit();
    }

    // Play next track
    public void NextTrack()
    {
        _sfxScript._audio.clip = _sfxScript._audioClip[0];
        _sfxScript._audio.Play();
        _trackID++;
        if (_trackID == 6)
        {
            _trackID = 0;
        }
        StopCoroutine(MusicPlayer());
        StartCoroutine(MusicPlayer());
    }

    // Play previous track
    public void PreviousTrack()
    {
        _sfxScript._audio.clip = _sfxScript._audioClip[0];
        _sfxScript._audio.Play();
        _trackID--;
        if (_trackID == -1)
        {
            _trackID = 5;
        }
        StopCoroutine(MusicPlayer());
        StartCoroutine(MusicPlayer());
    }

    // Change level
    public void NextLevel()
    {
        _sfxScript._audio.clip = _sfxScript._audioClip[0];
        _sfxScript._audio.Play();
        _levelID++;
        if (_levelID == 4)
        {
            _levelID = 0;
        }
        _img.sprite = _sprites[_levelID];
    }

    // Change level
    public void PreviousLevel()
    {
        _sfxScript._audio.clip = _sfxScript._audioClip[0];
        _sfxScript._audio.Play();
        _levelID--;
        if (_levelID == -1)
        {
            _levelID = 3;
        }
        _img.sprite = _sprites[_levelID];
    }

    // Start match
    public void StartMatch()
    {
        _sfxScript._audio.clip = _sfxScript._audioClip[0];
        _sfxScript._audio.Play();
        SceneManager.LoadScene(_scenes[_levelID], LoadSceneMode.Single);
        StartCoroutine(MatchTimer());
    }

    IEnumerator MatchTimer()
    {
        yield return new WaitForSeconds(120);
        Application.Quit();
    }

    public void Prefab1Select()
    {
        if (_playerPrefabs.Count <= 3)
        {
            _playerPrefabs.Add(_prefabOptions[0]);
        }
        else
            return;
    }

    public void Prefab2Select()
    {
        if (_playerPrefabs.Count <= 3)
        {
            _playerPrefabs.Add(_prefabOptions[1]);
        }
        else
            return;
    }

    public void Prefab3Select()
    {
        if (_playerPrefabs.Count <= 3)
        {
            _playerPrefabs.Add(_prefabOptions[2]);
        }
        else
            return;
    }

    public void Prefab4Select()
    {
        if (_playerPrefabs.Count <= 3)
        {
            _playerPrefabs.Add(_prefabOptions[3]);
        }
        else
            return;
    }

    public void Prefab5Select()
    {
        if (_playerPrefabs.Count <= 3)
        {
            _playerPrefabs.Add(_prefabOptions[4]);
        }
        else
            return;
    }
}
