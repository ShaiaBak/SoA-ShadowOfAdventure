namespace QuestSystem {
    public interface IQuestText {
        string Title { get; }
        string DescriptionSummary { get; }
        string Hint { get; }
        string Dialog { get; }
    }
}

//Name
//DescriptionSummary
//Quest Hint
//Quest Dialog
//sourceID
//questID
//chain quest and next quest is blank (bool)
//chainquestID