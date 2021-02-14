using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : Singleton<LoadingScreen>
{

	public GameObject ContainerGO;

    public void ShowLoading(bool ShowOrHide)
    {
        ContainerGO.SetActive(ShowOrHide);
    }

    public void ShowLoading(bool ShowOrHide, float TimeToWait)
    {
        StopAllCoroutines();
        StartCoroutine(ShowLoadingCor(TimeToWait));
    }

    private IEnumerator ShowLoadingCor(float TimeToWait)
    {
        ShowLoading(true);
        yield return new WaitForSeconds(TimeToWait);
        ShowLoading(false);
    }

}