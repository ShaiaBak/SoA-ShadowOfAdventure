using System.Collections.Generic;

namespace QuestSystem {

    // basic quest class object
    public class Quest {

        //Name
        //DescriptionSummary
        //Quest Hint
        //Quest Dialog
        //sourceID
        //questID
        //chain quest and next quest is blank (bool)
        //chainquestID
        public Quest() {

        }


        //objectives
        private List<IQuestObjective> objectives;
        // collection objective
        // ex:
        // 10 feathers
        // fill 4 enemies
        //location objective
        // ex:
        // go from A to B
        // timed version: 10 mins from a to b

        //bonus objectives
        //rewards
        //events
        //on completion
        //on failed
        //on update

        // check if quest is completed
        private bool isComplete() {
            for(int i = 0; i < objectives.Count; i++) {
                // if not complete
                if (objectives[i].IsComplete == false && objectives[i].IsBonus == false) {
                    return false;
                }
            }

            return true;    // get reward. fire on complete event
        }
    }
}
