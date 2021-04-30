# DotNetCoreAPI_Using_RedisCache

This Example shows how to use Redis Cache with DotNetCore API. Here is how to run this project:

1. Download the Project.

2. Make sure that Redis server is running.

3. Update the Redis server path in the appsettings.json file for below entry

      `"RedisConnectionString" :  "localhost:6300"`     
   
      #### `[Please note] You can run Redis server in any of the way: In your local machine, inside Docker container or you can use Azure Redis cache instance as well.`
   
 4. Example uses one API Endpoint to get user data. While fecthing data if data exists in Cache it feches data from Cache else fecthes from Database.
         
 5. Fetching data from the Database has been mocked in the class only and a delay of 5 Seconds has been added. 
      
 6. Any data entry in cache expires after 60 seconds.
     
 7. While getting data for the first time from the api takes 5 seconds and then consecutive calls withing the 60 seconds would take fraction of seconds.

 8. API Endpoint to get user data
   
      ![image](https://user-images.githubusercontent.com/46951524/116662334-48c45a80-a9b3-11eb-82fb-887d3a2b2468.png)
      
 9. API Response when data is fecthed from Database 
   
      ![image](https://user-images.githubusercontent.com/46951524/116662637-a6f13d80-a9b3-11eb-9fb6-81ed3a3a682b.png)      
            
  10. API Response when data is fecthed from Cache 
      
      ![image](https://user-images.githubusercontent.com/46951524/116662738-c4bea280-a9b3-11eb-80c0-5e7e8c52acdc.png)
      
  
  ### [Note] 
  If you have Docker Desktop already installed you can use below two commands to make Redis server running
  
      `docker pull redis`
      `docker run -p 6300:6379 --name localredis -d redis`

     
