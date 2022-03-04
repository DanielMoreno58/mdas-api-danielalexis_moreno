# Individual Challenge

### Run App Steps:

1. Start the container:

    `docker-compose -f docker-compose-RetoInd.yml  up -d --force-recreate`

2. Restart the Pokemon Container (if neccesary)

    > _Sometimes the rabbit takes a little time to load and that makes the Pokemon Container failure, but don´t worry, just restart it and you are ready to go!_

3. Open RabbitMq

    You'll need the RabbitMq Opened to check the behavior of the App through the next requests. 

    http://localhost:15672/#/

4. Create Users and Add Favorites Requests:

    Do the following request through Swagger with the following link and data given below: 

    http://localhost:4080/swagger/index.html

    ----

    ### Users

    <br>

    **4.1.** Create a new User named Daniel

    ```json
    {
        "name": "Daniel",
        "id": "8fd82339-ea13-4072-b097-1a5fb53d5e56"
    }
    ```

    **4.2.** Create a Second User named Juan

    ```json
    {
        "name": "Juan",
        "id": "092b09db-337e-4549-a212-5884a303a899"
    }
    ```

    ----

    ### Add Pokemon Favorites

    <br>

    **4.3.** Add Bulbasaur as Pokemon Favorite to Daniel

    ```json
    {
        "userId": "8fd82339-ea13-4072-b097-1a5fb53d5e56",
        "pokemonId": 1
    }
    ```

    **4.3.** Add Pikachu as Pokemon Favorite to Daniel

    ```json
    {
        "userId": "8fd82339-ea13-4072-b097-1a5fb53d5e56",
        "pokemonId": 25
    }
    ```

    **4.4.** Add Pikachu as Pokemon Favorite to Juan
    ```json
    {
        "userId": "092b09db-337e-4549-a212-5884a303a899",
        "pokemonId": 25
    }
    ```

    **4.5.** Check in [Rabbit Mq](http://localhost:15672/#/) to watch the behavior of the publisher and the suscriber.

5. Get Pokemon Data Requests:

    Do the following request through Swagger with the following link and data given below:

    http://localhost:3080/swagger/index.html

    ---

    **5.1** Get Pokemon By Id

    Open **PokemonGet** request and type the following id to watch the data of the pokemon

    `id: 25`

    After that, you'll have to see that the counterPokemonFavorite have been increased in 2, it means that Pikachu has been selected as favorite by two users.

    ---

    **5.2** Get Pokemon By Id (Second Time)

    Open **PokemonGet** request and type the following id to watch the data of the pokemon

    `id: 1`

    After that, you'll have to see that the counterPokemonFavorite have been increased in 1, it means that Bulbasaur has been selected as favorite by one user.

6. Run Tests:

    **6.1.** Docker Test Container

    In docker you can check if all the test are passed.
    Just check the log of the container with the following command in your favorite terminal or cmd:

    `docker logs -f test`

7. ¡Keep enjoying our App!

### [Return to README](README.md)