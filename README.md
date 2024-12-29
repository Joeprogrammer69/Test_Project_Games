# Project: Game Store Application

## Structuur van de Applicatie

### Overzicht
De applicatie is ontworpen als een eenvoudige Game Store, waarbij de nadruk ligt op beslissingslogica en acties op basis van game-informatie. Het systeem gebruikt interfaces en dependency injection voor flexibiliteit en testbaarheid.

### Klassen en Verantwoordelijkheden
De applicatie is verdeeld in verschillende klassen met duidelijke verantwoordelijkheden:

#### DecisionModule
**Verantwoordelijkheid**: Verwerken van game-informatie en beslissen of een korting wordt toegepast.  
**Belangrijkste methode**:
- `DecideDiscount(string gameId)`: Gebruikt informatie over een game om een beslissing te nemen.  
**Afhankelijkheden**:
- `IGameInfo` interface voor het ophalen van gamegegevens.

#### IGameInfo (Interface)
**Verantwoordelijkheid**: Definieert een contract voor het ophalen van game-informatie.  
**Methode**:
- `GetGameInfo(string gameId)`: Retourneert een `Game`-object.

#### GameInfoProvider
**Verantwoordelijkheid**: Implementeert de `IGameInfo` interface en simuleert gegevens van een externe API.  
**Methode**:
- `GetGameInfo(string gameId)`: Retourneert een `Game`-object.

#### Game (Model)
**Verantwoordelijkheid**: Bevat eigenschappen van een game.  
**Eigenschappen**:
- `GameId`: Unieke ID van de game.
- `Name`: Naam van de game.
- `ReleaseYear`: Uitgavejaar.
- `Userscore`: Gebruikersbeoordeling.

#### ActionHandler
**Verantwoordelijkheid**: Voert acties uit zoals het loggen van resultaten of het uitvoeren van aanvullende processen.  
**Methode**:
- `HandleAction(string action, string gameName)`.

---

## Teststrategie

### 1. Unit Tests
Unit-tests zijn geschreven voor de `DecisionModule` om de logica te valideren op basis van verschillende scenario's.

#### Testscenario's:
1. **Wanneer een game oud is**:
   - **Verwachte uitkomst**: `"Apply Discount"`.
   - Game heeft een lage gebruikersscore en een uitgavejaar dat ouder is dan 5 jaar geleden.
2. **Wanneer een game populair is**:
   - **Verwachte uitkomst**: `"Apply Discount"`.
   - Game heeft een hoge gebruikersscore en is recent uitgebracht.
3. **Wanneer een game nieuw en niet populair is**:
   - **Verwachte uitkomst**: `"No Discount"`.
   - Game is recent uitgebracht, maar heeft een lage gebruikersscore.

#### Hoe de tests zijn opgesteld
De unit-tests volgen de TDD-methode (Test-Driven Development), waarbij we eerst tests definiëren en vervolgens de implementatie van de beslissingslogica voltooien totdat alle tests slagen.

**Gebruik van ZOMBIES-principe**:
- **Zero**: We testen hoe de module zich gedraagt met geen (lege of ongeldige) game-informatie.
- **One**: Elk testscenario focust op een specifieke game en diens eigenschappen.
- **Many**: Hoewel de implementatie niet meerdere games tegelijk ondersteunt, is de logica schaalbaar voor meerdere verzoeken.
- **Boundaries**: We testen grensgevallen zoals een game met een releasejaar van precies 5 jaar geleden.
- **Interfaces**: `IGameInfo` is een mockbare interface, getest via simulaties.
- **Exception**: Foutafhandeling wordt getest door incorrecte invoer of ontbrekende gegevens.
- **Scenario**: De tests dekken alle verwachte gebruiksscenario's.

**Tools**:
- `Moq`: Voor het mocken van de `IGameInfo` interface.
- `Assert.AreEqual`: Gebruikt om de resultaten te vergelijken met de verwachte uitkomst.

---

### 2. Integratietests
De integratietests valideren de interactie tussen verschillende modules van de applicatie en externe systemen, zoals een API.

#### Testdoel
De integratietests richten zich op het volgende:
1. Valideren dat de `GameInfoProvider` correct de API consumeert en retourneert wat verwacht wordt.
2. Verifiëren dat de `DecisionModule` op basis van realistische data van de API een juiste beslissing neemt.

#### Tools
- **Mockoon**: Gebruikt om een mock-server op te zetten en de externe API te simuleren.
- **HttpClient**: Gebruikt in `GameInfoProvider` om API-aanroepen te maken.
- **xUnit**: Testframework gebruikt voor het schrijven en uitvoeren van tests.

#### Testcases
1. **Game-informatie ophalen via een mock-API**:
   - **Scenario**: Een game met ID `game123` bestaat in de mock-API.
   - **Verwachte uitkomst**: De juiste gamegegevens worden geretourneerd (`GameId`, `Name`, `ReleaseYear`, `Userscore`).
2. **Beslissing nemen op basis van API-gegevens**:
   - **Scenario**: Een game met ID `game123` wordt geretourneerd door de mock-API met een lage gebruikersscore en een oude releasedatum.
   - **Verwachte uitkomst**: De beslissing is `"Apply Discount"`.

#### Implementatie
De integratietests worden uitgevoerd in de `IntegrationTests`-klasse:
