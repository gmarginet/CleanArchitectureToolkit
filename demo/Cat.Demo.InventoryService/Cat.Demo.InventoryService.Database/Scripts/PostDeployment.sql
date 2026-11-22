/*
Runs after every deploy of the schema. Both scripts only add what is missing, so they can run again.
The seed lives here and not in the schema, and only the AppHost deploys this project, so the seed never reaches a database that is not a demo.
*/
:r .\Seed.sql
:r .\ChangeCapture.sql
