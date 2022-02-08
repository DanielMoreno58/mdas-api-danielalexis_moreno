# Project ePokemon | Group 2 

This project was created by **Group 2** for the course Software Design 2 with the programming language: **C#**

---

### Bounded Context: 

* **Pokemon**

### Module: 

* Type

### Entities:

* Type

### Value Objects:

* TypeName
* PokemonName

### Exceptions:

* PokemonNotFoundException
* PokemonApiNotResponseException


---

### Requeriments to Run App:

- Docker
- Docker Compose
  
---

### Run App Steps:

1. Start the container:

    `docker-compose up -d --force-recreate`

2. Make Requests:
   
    **2.1.** Api

    > Do the following request through postman or your favorite browser: <br><br>
    > `http://localhost:3080/api/v1/TypeGet/charizard` <br><br>
    > Exception Scenarios: <br>
    > 1. Change the name `charizard` for any other pokemon you can imagine, and if not exists the app will throw an exception (***PokemonNotFoundException***) that indicates that the pokemon does not exist!
    > 2. Test the Api without conection to internet to get the next controlled excepetion(***PokemonApiNotResponseException***) that indicates that the api is not responding!

     **2.2.** Console

    > Access to the console app within inside the container:<br><br>
    > `docker exec -it pokemon /bin/sh`<br><br>
    > Run the following command to execute the console app:<br><br>
    > `dotnet PokemonConsole.dll`<br><br>
    > Write the name of a pokemon and the app will return you the types of that peculiar pokemon.

3. ¡Enjoy our App!

---

## Authors Project

| **Raúl Camisón García**  | <img src="https://estudy.salle.url.edu/fotos2/eac/raul.camison.jpg" alt="drawing" width="35"/>  |
| :-----------                        | ----------- |
| **Damian Cervantes Rodon** | <img src="https://estudy.salle.url.edu/fotos2/eac/damian.cervantes.jpg" alt="drawing" width="35"/>  |
| **Daniel Alexis Moreno Herrera**  | <img src="https://avatars.githubusercontent.com/u/25211032?v=4" alt="drawing" width="35"/>   |
| **Erick Arostegui Cunza** | <img src="https://avatars.githubusercontent.com/u/13504293?v=4" alt="drawing" width="35"/> |