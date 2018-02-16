using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject camLoadScene;
    public GameObject gobAnimator;
    [SerializeField]
    private Animator animatorLoadScene;
    [SerializeField]
    private bool isAnimationFinished = false;
    [SerializeField]
    private int countAnim = 0;
    public GameValueManager instanceGameManager;
    private void Awake()
    {
        instanceGameManager = GameValueManager.Instance;
    }
    private void Start()
    {
        //animatorLoadScene = gobAnimator.GetComponent<Animator>();
    }
    public void onLoadLevel(int argSceneIndex)
    {
        StartCoroutine(onLoadAsynchronously(argSceneIndex));
    }
    IEnumerator onLoadAsynchronously(int argSceneIndex)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(argSceneIndex);
        while (!asyncOperation.isDone)
        {
            float progress = asyncOperation.progress / 0.9f;
            //Debug.Log("Progress: " + progress + " Progress: " + progress * 100 + "%");
            yield return null;
        }
    }
    public void onLoadLevel(string argSceneName)
    {
        if (camLoadScene != null)
        {
            camLoadScene.SetActive(true);
            //animatorLoadScene = gobAnimator.GetComponent<Animator>();
            //onPlayAnimation("FlowerAnimState");
        }
        StartCoroutine(onLoadAsynchronously(argSceneName));
    }
    IEnumerator onLoadAsynchronously(string argSceneName)
    {
        yield return new WaitForSeconds(2.75f);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(argSceneName);
        while (!asyncOperation.isDone)
        {
            float progress = asyncOperation.progress / 0.9f;
            //Debug.Log("Progress: " + progress + " Progress: " + progress * 100 + "%");
            yield return null;
        }
    }
    public void onClickSetIndex(int argLetterIndex)
    {
        //Debug.Log(argLetterIndex);
        if(instanceGameManager == null)
        {
            instanceGameManager = GameValueManager.Instance;
        }
        instanceGameManager.letterIndext = argLetterIndex;
    }
    private void Update()
    {
        if(animatorLoadScene == null)
        {
            //return;
        }
        //Debug.Log("DDLKJKL");
        //onCheckAnimation();
    }
    private void onPlayAnimation(string argStateName)
    {
        animatorLoadScene.Play(argStateName);
    }
    private void onCheckAnimation()
    {
        /*if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("EndState"))
        {
            // Avoid any reload.
            if (!isElse)
            {
                Debug.Log("IF");
                isElse = true;
            }
            //gobAnim.SetActive(false);
        }
        else
        {
            Debug.Log("ELSE");
            isElse = false;
            // You have just leaved your state!
        }*/
        if (animatorLoadScene.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animatorLoadScene.IsInTransition(0))
        {
            //Debug.Log("another_if");
            //Finished
            /*if (countAnim > 10)
            {
                isAnimationFinished = true;
            }*/
            isAnimationFinished = true;
        }
        else
        {
            //Not finished
            countAnim++;
        }
    }
}
