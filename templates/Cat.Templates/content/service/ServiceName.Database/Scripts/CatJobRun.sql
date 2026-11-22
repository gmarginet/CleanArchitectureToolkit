-- The table of the scheduler (Cat.Scheduling.EFCore). Each run of a job claims a row here, so two instances never run a job twice,
-- and the rows are the history of the runs. All times are UTC.
-- It must match the model of AddCatScheduling(). Neither EF Core nor a build compares the two, so follow it by hand.
CREATE TABLE IF NOT EXISTS "CatJobRun"
(
    "JobName"    varchar(200)             NOT NULL,
    "DueTime"    timestamp with time zone NOT NULL,
    "Status"     varchar(20)              NOT NULL,
    "StartedAt"  timestamp with time zone NOT NULL,
    "FinishedAt" timestamp with time zone NULL,
    "ErrorCode"  varchar(200)             NULL,
    "Attempts"   integer                  NOT NULL,
    CONSTRAINT "PK_CatJobRun" PRIMARY KEY ("JobName", "DueTime")
);

CREATE INDEX IF NOT EXISTS "IX_CatJobRun_JobName_Status_StartedAt" ON "CatJobRun" ("JobName", "Status", "StartedAt");
