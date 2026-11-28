namespace exam_system.Domain.Enums
{
    public enum QuizAvailability  // calc by time , not save in db 
    {
     Upcoming = 0,     // Published, before StartDate
    Available = 1,    // Published, StartDate <= now < EndDate
    EntryClosed = 2,  // now >= EndDate and some attempts still running
    Finished = 3      // now >= EndDate and all attempts finalized
    }
}
