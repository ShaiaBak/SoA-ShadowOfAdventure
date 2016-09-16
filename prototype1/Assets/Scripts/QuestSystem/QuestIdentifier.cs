using UnityEngine;
using System.Collections;
using System;

namespace QuestSystem {
    public class QuestIdentifier : IQuestIdentifier {
        private int questID;
        private int chainQuestID;
        private int sourceID;

        public int QuestID {
            get {
                return questID;
            }
        }

        public int ChainQuestID {
            get {
                return chainQuestID;
            }
        }

        public int SourceID {
            get {
                return sourceID;
            }
        }
    }
}
