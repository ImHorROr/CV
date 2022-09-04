//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    [SerializeField] float _maxDistance = 20;
    private bool isKillable;
    [SerializeField] GameObject _gazedAtObject = null;
    testvr vr;
    killable killable;
    [SerializeField] LayerMask interactableLayer;
    [SerializeField]Follower follower;
    MyPlayerInput inputActions;

    private void Start()
    {
        follower = GetComponentInParent<Follower>();
        inputActions = follower.myPlayerInput;
        inputActions.MovmentCont.Kill.performed += Shot;
        inputActions.MovmentCont.zom.performed += zom;
        print(inputActions);
    }

    private void zom(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(1);
    }

    private void Shot(InputAction.CallbackContext obj)
    {
        if(isKillable)
        {
            killable.OnPointerClick();
            
        }
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance, interactableLayer))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                _gazedAtObject = hit.transform.gameObject;

                if (_gazedAtObject.GetComponent<testvr>() != null)
                {
                    vr = _gazedAtObject.GetComponent<testvr>();
                }
                if(_gazedAtObject.GetComponent<killable>() != null)
                {
                    killable = _gazedAtObject.GetComponent<killable>();
                }
                if (vr != null)
                {
                    vr.OnPointerExit();
                    _gazedAtObject = hit.transform.gameObject;
                    vr.OnPointerEnter();

                }
                if (killable != null)
                {
                    killable.OnPointerExit();
                    isKillable = true;
                    _gazedAtObject = hit.transform.gameObject;
                    killable.OnPointerEnter();

                }
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            if (vr != null)
            vr.OnPointerExit();

            if (killable != null)
                killable.OnPointerExit();

            //_gazedAtObject?.SendMessage("OnPointerExit");
            _gazedAtObject = null;
        }

        // Checks for screen touches.

    }
}
