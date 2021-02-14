using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{

    public UnityEvent EscClicked;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnEscClicked();
    }

    private void OnEscClicked()
    {
        EscClicked.Invoke();
    }

}
