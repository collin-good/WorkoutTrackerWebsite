# Goals

  The goal for this project was to make a single-user application that would allow users to keep track of when they works out, what workouts they did, the weights they used, as well as the sets, and reps done. This application could very easily be made into a multi-user application very easily by adding a second database with user information (User ID, username, and password) and add user ID as a foreign key into the workouts database. Then, the queries would just need an additional where clause so the user that is currently logged in only gets their own workouts.  

# Technologies Used

* .NET / C#
* ASP .NET Core
* Entity Framework (EF) Core
