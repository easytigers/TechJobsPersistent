--Part 1

SELECT column_name, data_type
FROM information_schema.columns
WHERE table_name = "Jobs"

--Part 2

SELECT Name 
FROM employers
WHERE Location = "St. Louis";

--Part 3

SELECT Name, Description 
FROM jobSkills
WHERE techjobs.jobSkills.jobId IS NOT NULL
ORDER BY Name ASC;
