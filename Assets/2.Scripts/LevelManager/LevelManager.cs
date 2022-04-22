using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private ushort buildIndex; 
    [SerializeField] private Image screenFade;
    [SerializeField] private Image screenFill;

    void Awake() 
    {
        screenFade.enabled = true;
        FadeOut();
    }

    IEnumerator ChangeLevel() 
    {
     
        AsyncOperation async = SceneManager.LoadSceneAsync(buildIndex);
        async.allowSceneActivation = false;

        FadeIn();
        yield return new WaitForSeconds(.81f);

        async.allowSceneActivation = true;
    }

    void FadeOut() 
    {
        DOTweenModuleUI.DOFade(screenFade, 0, 0.7f);
    }

    void FadeIn()
    {
        DOTweenModuleUI.DOFillAmount(screenFill, 1, .8f);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
            StartCoroutine(ChangeLevel());
        
    }
}
