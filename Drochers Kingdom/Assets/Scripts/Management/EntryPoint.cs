using System.Linq;
using UnityEngine;

namespace Management
{
    public interface IDisabledOnAwake
    {
        public void Initialize();
    }
    public class EntryPoint : MonoBehaviour
    {
        private void Start()
        {
            FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include,
                    FindObjectsSortMode.None)
                .OfType<IDisabledOnAwake>()
                .ToList()
                .ForEach(x => x.Initialize());
        }
    }
}