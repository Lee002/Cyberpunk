using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Player
{
    [SerializeField]private State state = State.Idle;

    public State State { get => state; set => state = value; }
}
public enum State
{
    Idle,
    Crouched,
    Walking,
    Running,
    Harvesting
}
