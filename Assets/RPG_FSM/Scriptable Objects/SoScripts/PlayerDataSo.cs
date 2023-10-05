using RPG_FSM.Scripts.Domain;
using UnityEngine;

namespace RPG_FSM.Scriptable_Objects.Player.PlayerSOScripts
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "Characters/Player")]
    public class PlayerDataSo : ScriptableObject
    {
        [field: SerializeField] public PlayerGroundData GroundData { get; private set; }
        [field: SerializeField] public PlayerGroundData AirData { get; private set; }
    }
}