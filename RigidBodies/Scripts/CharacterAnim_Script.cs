using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAnim_Script : MonoBehaviour
{
    private Image _img;
    public Sprite[] _sprites;
    public float _animSpeed;


    private void Start()
    {
        _img = GetComponent<Image>();
        StartCoroutine(Delay());
    }


    // Prevents any errors at start
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(AnimateImage());
    }

    // Images don't work with animation
    // I want to use image to retain position as part of canvas
    // This changes the image to create an animation
    IEnumerator AnimateImage()
    {
        for (int i=0; i < _sprites.Length - 1; i++)
        {
            _img.sprite = _sprites[i];
            yield return new WaitForSeconds(_animSpeed);
        }
        StartCoroutine(AnimateImage());
    }
}
