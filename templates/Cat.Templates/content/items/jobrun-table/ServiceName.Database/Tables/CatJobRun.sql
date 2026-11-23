-- The table of the scheduler (Cat.Scheduling.EFCore). Each run of a job claims a row here, so two instances never run a job twice,
-- and the rows are the history of the runs. All times are UTC.
-- It must match the model of AddCatScheduling(). Neither this build nor EF Core compares the two, so follow it by hand.
CREATE TABLE dbo.CatJobRun
(
    JobName    nvarchar(200) NOT NULL,
    DueTime    datetime2     NOT NULL,
    Status     nvarchar(20)  NOT NULL,
    StartedAt  datetime2     NOT NULL,
    FinishedAt datetime2     NULL,
    ErrorCode  nvarchar(200) NULL,
    Attempts   int           NOT NULL,
    CONSTRAINT PK_CatJobRun PRIMARY KEY (JobName, DueTime)
);
GO

CREATE INDEX IX_CatJobRun_JobName_Status_StartedAt ON dbo.CatJobRun (JobName, Status, StartedAt);
