using System;
using UnityEngine;

namespace RPG_FSM.Scripts.Domain
{
    [Serializable]
    public struct PlayerAirData
    {
        [field: Header("Jump Data")]
        [field: SerializeField]
        public float JumpForce { get; private set; }
    }
}