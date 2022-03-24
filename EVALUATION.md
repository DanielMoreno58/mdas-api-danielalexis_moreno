## Hace todos los puntos pedidos (40%)

#### El nombre del repositorio es el correcto (mdas-web-${nombre}_${apellido})

OK

#### Permite obtener los detalles de un pokemon vía endpoint (datos + número de veces que se ha marcado como favorito)

- No😔. Únicamente se pueden añadir pokemons favoritos por UUID, por lo tanto, nunca consigo añadir pokemon reales como
  favoritos. Y al obtener los detalles nunca me devuelve el contador:

```
  {
    "id": 1,
    "name": "bulbasaur",
    "height": 7,
    "weight": 69
  }
```

Veo que el `PokemonGetAdapter` tiene el atributo count, pero no se expone:

```
    {
        Id = pokemon.PokemonId.Value,
        Name = pokemon.PokemonName.Value,
        Height = pokemon.PokemonHeight.Value,
        Weight = pokemon.PokemonWeight.Value,
        CounterPokemonFavorite = pokemon.PokemonCounterFavorite.Value
    };
```

#### Actualiza el contador de favoritos vía eventos

OK

#### ¿Se controlan las excepciones de dominio? Y si se lanza una excepción desde el dominio, ¿se traduce en infraestructura a un código HTTP?

OK

#### Tests unitarios

- No 😔. Ejemplo: `PokemonSaver`,`UserAddPokemonFavorite`, `AddPokemonFavoriteUseCase`..

#### Tests de aceptación

- No, únicamente hay tests de `AddPokemonFavoriteUseCase`

#### Tests de integración

- No

**Puntuación: 15/40**

## Se aplican conceptos explicados (50%)

#### Separación correcta de capas (application, domain, infrastructure + BC/module/layer)

- No existe el puerto `EventPublisher`
- La implementación del publisher `AddPokemonFavoritePublisher` es infraestructura, no aplicación. Además,
  sería `RabbitMqPublisher` ya que la implementación es con RabbitMq.
- La encargada de unir la pokeApi y la base de datos en memoria es la infraestructura (tu implementación del
  repositorio). Recuerda el ACL (Anti-Corruption Layer), tu dominio no debe estar condicionado por la implementación.

#### Aggregates + VOs

OK

#### No se trabajan con tipos primitivos en dominio

OK

#### Hay servicios de dominio

- Tendría más sentido tener un servicio de dominio llamado `PokemonIncreaser` y delegar aquí la responsabilidad de
  obtener el pokemon, aumentar el número de pokemon favoritos y de guardar en el repositorio.

#### Hay use cases en aplicación reutilizables

- OK, aunque tendría más sentido que el caso de uso indicara que acción realiza: en vez de `PokemonAddAsFavoriteUseCase`
  sería mejor `PokemonFavoriteIncreaserUseCase` o algo similar.

#### Se aplica el patrón repositorio

- Hay dos patrones repositorio: `IPokemonRepository` y `IPokemonFavoriteRepository` si el agregado es pokemon, el único
  puerto de repositorio debería ser `PokemonRepository` (recuerda: 1 módulo -> 1 repositorio)

#### Se usan subscribers

OK

#### Se lanzan eventos de dominio

OK

#### Se utilizan object mothers

OK

**Puntuación: 30/50**

## Facilidad setup + README (10%)

#### El README contiene al menos los apartados "cómo ejecutar la aplicación", "cómo usar la aplicación"

OK

#### Es sencillo seguir el apartado "cómo ejecutar la aplicación"

- Faltan el user y password en el paso `Open RabbitMq`.
- A la hora de añadir un pokemon favorito, si añado el pokemon favorito tal cual lo dice en el readme me da el siguiente
  error:

  ````
  {
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
    "title": "One or more validation errors occurred.",
    "status": 400,
    "traceId": "00-0826340994a419ad7bc0ab604bd8f7e0-0f50bbfccabae5d0-00",
    "errors": {
      "addPokemonFavoriteDto": [
        "The addPokemonFavoriteDto field is required."
      ],
      "$.pokemonId": [
        "The JSON value could not be converted to System.Guid. Path: $.pokemonId | LineNumber: 2 | BytePositionInLine: 18."
      ]
    }
  
  }
  ````

**Puntuación: 5/10**

## Extras

- Commits en "baby steps". Pequeños y legibles

**Puntuación: +3**

## Observaciones

- La prueba se ha entregado 4 horas tarde

**Puntuación: -3**

**PUNTUACIÓN FINAL: 50/100**
