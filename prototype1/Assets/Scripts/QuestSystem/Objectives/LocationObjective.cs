using System;

namespace QuestSystem {
    public class LocationObjective : IQuestObjective {
        private string title;
        private string description;
        private bool isComplete;
        private bool isBonus;
        private PlayerLocation targetLocation; // zone, 2d cord

        public string Title {
            get {
                return title;
            }
        }

        public string Description {
            get {
                return description;
            }
        }

        public bool IsComplete {
            get {
                return isComplete;
            }
        }

        public bool IsBonus {
            get {
                return isBonus;
            }
        }

        public void CheckProgress() {
            //if players location is = to to our target location then we are complete then objective is finished
            if (PlayerInfo.getLocation.Compare(targetLocation)) {
                isComplete = true;
            } else {
                isComplete = false;
            }
        }

        public void UpdatePorgess() {
            throw new NotImplementedException();
        }
    }
}
