# Project: Game Store Application

## Structuur van de Applicatie

### Overzicht
De applicatie is ontworpen als een eenvoudige Game Store, waarbij de nadruk ligt op beslissingslogica en acties op basis van game-informatie. Het systeem gebruikt interfaces en dependency injection voor flexibiliteit en testbaarheid.

### Klassen en Verantwoordelijkheden
De applicatie is verdeeld in verschillende klassen met duidelijke verantwoordelijkheden:

1. **DecisionModule**
   - **Verantwoordelijkheid**: Verwerken van game-informatie en beslissen of een korting wordt toegepast.
   - **Belangrijkste methode**:
     - `DecideDiscount(string gameId)`: Gebruikt informatie over een game om een beslissing te nemen.
   - **Afhankelijkheden**:
     - `IGameInfo` interface voor het ophalen van gamegegevens.

2. **IGameInfo (Interface)**
   - **Verantwoordelijkheid**: Definieert een contract voor het ophalen van game-informatie.
   - **Methode**:
     - `GetGameInfo(string gameId)`: Retourneert een `Game`-object.

3. **GameInfoProvider**
   - **Verantwoordelijkheid**: Implementeert de `IGameInfo` interface en simuleert gegevens van een externe API.
   - **Methode**:
     - `GetGameInfo(string gameId)`: Retourneert een `Game`-object.

4. **Game (Model)**
   - **Verantwoordelijkheid**: Bevat eigenschappen van een game.
     - `GameId`: Unieke ID van de game.
     - `Name`: Naam van de game.
     - `ReleaseYear`: Uitgavejaar.
     - `Userscore`: Gebruikersbeoordeling.

5. **ActionHandler**
   - **Verantwoordelijkheid**: Voert acties uit zoals het loggen van resultaten of het uitvoeren van aanvullende processen.
   - **Methode**:
     - `HandleAction(string action, string gameName)`.

---

## Teststrategie

### 1. Unit Tests
Unit-tests zijn geschreven voor de `DecisionModule` om de logica te valideren op basis van verschillende scenario's.

#### Testscenario's:
- **Wanneer een game oud is**:
  - Verwachte uitkomst: "Apply Discount".
  - Game heeft een lage gebruikersscore en een uitgavejaar dat ouder is dan 5 jaar geleden.
- **Wanneer een game populair is**:
  - Verwachte uitkomst: "Apply Discount".
  - Game heeft een hoge gebruikersscore en is recent uitgebracht.
- **Wanneer een game nieuw en niet populair is**:
  - Verwachte uitkomst: "No Discount".
  - Game is recent uitgebracht, maar heeft een lage gebruikersscore.

#### Hoe de tests zijn opgesteld
De unit-tests volgen de **TDD-methode** (Test-Driven Development), waarbij we eerst tests definiëren en vervolgens de implementatie van de beslissingslogica voltooien totdat alle tests slagen.

##### Gebruik van ZOMBIES-principe:
- **Z**ero: We testen hoe de module zich gedraagt met geen (lege of ongeldige) game-informatie.
- **O**ne: Elk testscenario focust op een specifieke game en diens eigenschappen.
- **M**any: Hoewel de implementatie niet meerdere games tegelijk ondersteunt, is de logica schaalbaar voor meerdere verzoeken.
- **B**oundaries: We testen grensgevallen zoals een game met een releasejaar van precies 5 jaar geleden.
- **I**nterfaces: `IGameInfo` is een mockbare interface, getest via simulaties.
- **E**xception: Foutafhandeling wordt getest door incorrecte invoer of ontbrekende gegevens.
- **S**cenario: De tests dekken alle verwachte gebruiksscenario's.

#### Tools:
- **Moq**: Voor het mocken van de `IGameInfo` interface.
- **Assert.AreEqual**: Gebruikt om de resultaten te vergelijken met de verwachte uitkomst.






