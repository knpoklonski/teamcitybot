using System;

namespace TeamCityApi
{
    public class BuildStateResult
    {
        public BuildStateResult(BuildStatus status, BuildState state, string user, DateTime startDate, DateTime finishDate, string statusText)
        {
            Status = status;
            State = state;
            User = user;
            StartDate = startDate;
            FinishDate = finishDate;
            StatusText = statusText;
        }

        public BuildStatus Status { get; private set; }
        public BuildState State { get; private set; }
        public string User { get; private set; }

        public DateTime StartDate { get; private set; }
        public DateTime FinishDate { get; private set; }

        public TimeSpan Duration
        {
            get { return FinishDate - StartDate; }
        }

        public string StatusText { get; private set; }


        public string GetInfo()
        {
            switch (State)
            {
                case BuildState.Finished:
                    return string.Format("Build was runned by {0} , finished: {1} , duration: {2} {3}", User, Status, Duration, StatusText);
            }

            throw new NotImplementedException();
        }
    }
}