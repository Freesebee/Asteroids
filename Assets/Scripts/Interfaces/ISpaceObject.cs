﻿using UnityEngine;

public interface ISpaceObject
{
    void Awake();
    void Start();
    void OnEnable();
    void OnDisable();
    void Update();
    void FixedUpdate();
    void OnCollisionEnter2D(Collision2D collision);
    void OnCollisionExit2D(Collision2D collision);
    void OnDestroy();
}
