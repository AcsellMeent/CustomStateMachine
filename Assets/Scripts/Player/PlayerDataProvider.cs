using UnityEngine;

namespace Player
{
    public class PlayerDataProvider : MonoBehaviour
    {
        [SerializeField]
        private PlayerSpecifications _specifications;
        [SerializeField]
        private PlayerProperties _properties;
        
        public PlayerSpecifications Specifications { get => _specifications; }
        public PlayerProperties Properties { get => _properties; }
    }
}