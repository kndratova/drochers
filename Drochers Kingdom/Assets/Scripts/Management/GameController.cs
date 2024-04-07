using Game;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace Management {
    public class GameController : MonoBehaviour {
        private const string JsonString = @"{
            ""playerCards"": [1, 2, 3],
            ""world"": {
                ""a2"": {
                    ""card"": [1, 2],
                    ""player"": 2
                },
                ""a1"": {
                    ""card"": [1],
                    ""player"": 2
                }
            }
        }";

        private void Start() {
            var gameParameters = JsonConvert.DeserializeObject<GameParameters>(JsonString);
            Debug.Log("Player of a2: " + gameParameters.world["a2"].player);
        }

        [System.Serializable]
        public class GameParameters {
            public int[] playerCards;
            public Dictionary<string, JsonFieldCell> world;
        }

        [System.Serializable]
        public class JsonFieldCell {
            public int[] card;
            public int player;
        }
    }
}
