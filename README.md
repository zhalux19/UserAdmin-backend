Please create a local database and called it local-sa-test

Run the MigrationScript in the root folder against the db.

Please adjust your connectionstring if needed.

Start the application from your local.
Make sure application is available in the url https://localhost:44358/ 
The frontend will using the url to make api calls.

Used 3-tier architecture. SATest.Application contains the business layer. 
SATest.Infrastructure contains the db layer. Dapper is used in the db layer.
Implemented DB Rep pattern. Created a test project that contains just one test using NSubstitute and Xunit. 
If more time was given can increase the test coverage. When fetching data, it is currently returning all user data. 
Can implement pagination and some more advanced search (search by name) if more time was given. 
The current mock data is using id int. Can use Guid instead of id to improve the security of the data.
