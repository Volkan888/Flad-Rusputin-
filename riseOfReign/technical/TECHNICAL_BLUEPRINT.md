# riseOfReign — Technische Architektur

Stand: 2026-09-02 02:47 CEST

## Ziel

Technische Zielarchitektur für ein modernes, rundenbasiertes 4-Spieler-Mobile-Strategiespiel mit gemeinsamer Weltkarte, persistenten Matches und serverautoritativem Spielzustand.

## Technologieentscheidung

### Mobile-Client

**Godot 4.7.2 Standard + GDScript**

Begründung:
- Godot 4.7.2 ist zum Stand August/September 2026 die aktuelle stabile Godot-4-Version.
- Open Source, keine Engine-Lizenzkosten.
- Sehr gut für 2D-Karten, UI, Animationen und Mobile geeignet.
- C# ist in Godot 4 auf Mobile grundsätzlich verfügbar, wird in der offiziellen Dokumentation aber weiterhin mit Einschränkungen/experimentellem Status beschrieben. Für einen neuen Mobile-Produktionsclient wird daher GDScript gewählt.
- Die bestehende C#-Erfahrung bleibt im Backend und in den Domainregeln nutzbar.

### Server

**ASP.NET Core auf .NET 10 LTS / C# 14**

Begründung:
- .NET 10 ist 2026 aktive LTS-Version.
- bestehende C#-Logik kann schrittweise übernommen werden.
- gute API-, Background-Worker- und Test-Unterstützung.
- SignalR eignet sich für Lobby-, Präsenz-, Telefon-/Meeting- und Rundenstatusupdates.

### Datenbank

**PostgreSQL 18**

- relationale, transaktionale Matchdaten
- JSONB für flexible Eventparameter
- gute Locking-/Concurrency-Funktionen
- langfristige Wartbarkeit

### Zusatzdienste

- Redis: optional für Presence, Lobby-Cache, Rate Limits und kurzlebige Locks
- S3-kompatibler Object Storage: Bilder, Audio, Kartenassets
- Nginx/Caddy: TLS + Reverse Proxy
- Docker Compose für Entwicklung; Containerdeployment für Staging/Produktion

Offizielle Versionsbasis 2026:
- Godot 4.7.2 stable, 18.08.2026
- .NET 10.0 LTS, aktuelle Security-Version 10.0.11 im August 2026
- PostgreSQL 18

---

# 1. Serverautorität

Der Client darf **niemals selbst endgültige Ressourcen, Kämpfe oder Eventergebnisse bestimmen**.

Client:
- zeigt Zustand
- sammelt Eingaben
- sendet Befehle
- animiert Serverergebnis

Server:
- validiert Autorität
- prüft Kosten
- sperrt unzulässige Aktionen
- löst Runden deterministisch auf
- speichert Ergebnis
- erzeugt Eventlog

Damit sind Savegame-Manipulation und einfache Client-Cheats deutlich schwieriger.

---

# 2. Architektur

```text
Godot Mobile Client
       |
   HTTPS / SignalR
       |
ASP.NET Core API
       |
+-------------------------+
| Auth / Lobby            |
| Match Service           |
| Turn Engine             |
| Event Engine            |
| Diplomacy Service       |
| Combat Resolver         |
| Economy Resolver        |
| AI Service              |
+-------------------------+
       |
 PostgreSQL 18
       |
 Redis optional
```

---

# 3. Repository-Zielstruktur

```text
riseOfReign/
  design/
    AVATAR_PROLOGUES_1933.md
    RESOURCE_SYSTEM.md
    MAP_1933.md
    SYSTEMS_RULEBOOK.md
    EVENT_CATALOG_1933_1945.md

  client/
    project.godot
    scenes/
      boot/
      auth/
      lobby/
      prologue/
      world_map/
      country/
      city/
      diplomacy/
      phone/
      meeting/
      research/
      military/
      reports/
    scripts/
    assets/
    localization/

  server/
    RiseOfReign.sln
    src/
      RiseOfReign.Api/
      RiseOfReign.Domain/
      RiseOfReign.Application/
      RiseOfReign.Infrastructure/
      RiseOfReign.Worker/
    tests/
      RiseOfReign.Domain.Tests/
      RiseOfReign.Api.Tests/
      RiseOfReign.IntegrationTests/

  data/
    epochs/
      1933/
        avatars/
        countries/
        regions/
        nodes/
        routes/
        technologies/
        events/
        ai_profiles/

  infra/
    docker-compose.yml
    nginx/
    db/
```

Alte Flad-/Northborn-Dateien bleiben außerhalb dieses neuen Ordners erhalten und werden nicht überschrieben.

---

# 4. Domänenmodelle

## Match

```text
Match
- Id
- EpochId
- Status
- CurrentDate
- TurnNumber
- TurnDeadline
- RulesetVersion
- RandomSeed
- CreatedAt
```

## MatchPlayer

```text
MatchPlayer
- MatchId
- UserId
- AvatarId
- CountryId nullable
- Authority
- IsReady
- IsAI
- LastSeenAt
```

## AvatarState

```text
AvatarState
- MatchId
- AvatarId
- Age
- Health
- Traits
- Authority
- PartyInfluence
- GovernmentInfluence
- MilitaryInfluence
- IntelligenceInfluence
- EconomicInfluence
- MediaInfluence
- InternationalInfluence
```

## CountryState

```text
CountryState
- MatchId
- CountryId
- GovernmentType
- Treasury
- Stability
- Legitimacy
- Reputation
- Administration
- PopulationMorale
- MilitaryMorale
- ResearchPoints
- DevelopmentPoints
- DiplomacyPoints
- IntelligencePoints
- InfluencePoints
```

## RegionState

```text
RegionState
- MatchId
- RegionId
- ControllerCountryId
- Population
- Workforce
- Infrastructure
- Unrest
- GovernmentLoyalty
- ProductionModifiers
```

## ResourceStock

```text
ResourceStock
- MatchId
- OwnerType country|region|node
- OwnerId
- ResourceType
- Amount
- ReserveTarget
- StorageCapacity
```

## NodeState

```text
NodeState
- MatchId
- NodeId
- Controller
- Damage
- Output
- Storage
```

## RouteState

```text
RouteState
- MatchId
- RouteId
- Capacity
- Condition
- Risk
- Control
```

---

# 5. Command-System

Spielereingaben werden nicht als direkte Datenbankänderungen gesendet, sondern als Commands.

Beispiele:

```text
AllocateBudgetCommand
StartResearchCommand
OfferTradeCommand
AcceptTreatyCommand
MoveFormationCommand
MobilizeCommand
ScheduleMeetingCommand
PhoneResponseCommand
IntelligenceActionCommand
SupportEventCommand
CounterEventCommand
EndTurnCommand
```

Jeder Command enthält:
- MatchId
- PlayerId
- TurnNumber
- ClientCommandId (idempotency)
- Payload
- ClientTimestamp

Server prüft:
- gehört Spieler zum Match?
- richtige Runde?
- ausreichende Autorität?
- Ressourcen vorhanden?
- Aktion bereits ausgeführt?
- Cooldown/Vertrag/Institution erlaubt?

---

# 6. Rundenauflösung

Rundenauflösung ist deterministisch.

## Ablauf

```text
Lock match
Load immutable start-of-turn snapshot
Validate queued commands
Resolve diplomacy agreements
Resolve intelligence actions
Resolve trade commitments
Resolve resource extraction
Resolve energy
Resolve refinement
Resolve industry
Resolve civilian consumption
Resolve military supply
Resolve research/development
Resolve movement/combat
Resolve historical/dynamic events
Resolve population/stability effects
Resolve AI decisions that belong to next planning phase
Persist new snapshot
Append event log
Increment turn
Unlock match
Push result notification
```

## Determinismus

Zufall basiert auf:
- serverseitigem Seed
- MatchId
- TurnNumber
- EventId/ActionId

So kann ein Turn bei Tests exakt reproduziert werden.

---

# 7. Event Sourcing Light

Kein vollständiges Event-Sourcing-System nötig, aber jede relevante Änderung erzeugt einen unveränderlichen Logeintrag.

```text
GameEventLog
- Id
- MatchId
- TurnNumber
- GameDate
- Type
- ActorPlayerId nullable
- TargetId nullable
- PayloadJson
- CreatedAt
```

Nutzen:
- Replay
- Support
- Cheatinganalyse
- Bug-Reproduktion
- Spielerchronik

Snapshots verhindern, dass für jeden Login tausende Events neu abgespielt werden müssen.

---

# 8. Savegames

Online-Matches speichern automatisch.

## Automatische Speicherung

- nach jeder Rundenauflösung
- vor kritischen Migrationen
- bei Matchabschluss

## Snapshot

```text
MatchSnapshot
- MatchId
- TurnNumber
- SchemaVersion
- StateJson/structured snapshot
- Hash
- CreatedAt
```

## Keine klassischen lokalen Savegames für Ranked Multiplayer

Lokale Daten sind nur Cache/UI-Einstellungen.

Singleplayer kann später lokale Slots oder Cloud-Saves erhalten.

---

# 9. Matchmaking/Lobby

Lobbytypen:
- privat mit Code
- Freunde/Einladung
- öffentlich
- KI-Lobby

Lobbyoptionen:
- Epoche
- historische vs. Alternative-History-Regeln
- Turntimer
- KI-Schwierigkeit
- Avatarwahl: Draft/Zufall/frei
- Duplikate historischer Avatare: standardmäßig aus

## Avatar-Draft

Empfohlen:
1. Reihenfolge zufällig
2. Spieler 1→4 wählen
3. zweiter Vorteilsausgleich für spätere Picks über Szenarioziele, nicht über rohe Gratisressourcen

---

# 10. Echtzeitkanal

SignalR wird nur für Dinge genutzt, die sofort sichtbar sein sollen:
- Lobbybeitritt
- Ready-Status
- Turn abgeschlossen
- Telefon klingelt
- Meeting-Einladung
- Vertrag eingegangen
- Chat/Verhandlungssignal

Die eigentliche Spielauflösung bleibt transaktional über Servercommands.

---

# 11. API-Schnittstellen

## Auth
- POST /auth/register
- POST /auth/login
- POST /auth/refresh

## Lobby
- POST /lobbies
- POST /lobbies/{id}/join
- POST /lobbies/{id}/ready
- POST /lobbies/{id}/start

## Match
- GET /matches/{id}/state
- GET /matches/{id}/report
- POST /matches/{id}/commands
- POST /matches/{id}/end-turn

## Diplomatie
- GET /matches/{id}/offers
- POST /matches/{id}/treaties
- POST /matches/{id}/meetings

## Content
- GET /content/epochs/1933/manifest
- GET /content/events/{version}

---

# 12. Datengetriebener Content

Historische Inhalte gehören nicht hart in C#-If-Blöcke.

Beispiel Event JSON:

```json
{
  "id": "de_1933_hitler_chancellor",
  "date": "1933-01-30",
  "mode": "historical_anchor",
  "requirements": [
    {"avatar": "hitler"}
  ],
  "effects": [
    {"target": "avatar.authority", "op": "add", "value": 25},
    {"target": "country.reputation", "op": "add", "value": -5}
  ],
  "responses": ["recognize", "observe", "distance"]
}
```

Server validiert JSON gegen Schema beim Start/Deployment.

---

# 13. Datenbanktabellen

Minimaler MVP:

- users
- sessions/refresh_tokens
- epochs
- avatar_definitions
- country_definitions
- region_definitions
- node_definitions
- route_definitions
- technology_definitions
- event_definitions
- matches
- match_players
- avatar_states
- country_states
- region_states
- node_states
- route_states
- resource_stocks
- formations
- treaties
- research_projects
- queued_commands
- game_event_log
- match_snapshots
- notifications

---

# 14. Concurrency

Problem: zwei Spieler akzeptieren/ändern gleichzeitig Verträge oder Rundenstatus.

Lösung:
- Optimistic Concurrency (`row_version`/xmin-Strategie)
- Matchauflösung mit exklusivem Match-Lock
- Commands idempotent über ClientCommandId
- DB-Transaktion pro Auflösung

---

# 15. Security

- TLS only
- Access/Refresh Token getrennt
- Passwort-Hashing mit aktuellem sicheren Algorithmus
- Rate Limiting
- keine geheimen gegnerischen Daten im Clientstate senden
- Server filtert Sichtbarkeit nach Informationsgrad
- Admin-/Supportzugriffe auditieren
- keine API-Secrets im Mobile-Build

## Fog of Information

API baut player-spezifische Views.

Spieler A erhält über Gegner B nur:
- öffentlich bekannte Werte
- eigene Geheimdienstschätzungen
- vertraglich geteilte Informationen

Der echte Serverzustand bleibt intern.

---

# 16. Tests

## Domain Unit Tests
- Ressourcenformeln
- Autoritätsprüfung
- Handelsrouten
- Forschung
- Eventtrigger
- Kampfauflösung
- Machtvakuum

## Determinism Tests
Gleicher Startsnapshot + gleiche Commands + gleicher Seed = identisches Ergebnis.

## Integration Tests
- Lobby → Match
- 4 Spieler ready
- kompletter Turn
- Disconnect/Reconnect
- doppelte Commands
- Deadline

## Historical Content Tests
- Ankerevent liegt im korrekten Datum/Fenster
- kein Event verweist auf unbekanntes Land/Avatar/Resource
- alle Effektpfade validiert

---

# 17. AI-Architektur

AI erzeugt dieselben Commands wie ein Mensch.

Dadurch existiert keine Sonderregel, die KI heimlich Ressourcen gibt.

AI Pipeline:
1. Observe visible state
2. Score threats/opportunities
3. Set goals
4. Generate candidate commands
5. Budget resources
6. Submit commands

AI-Profile liegen datengetrieben unter `data/epochs/1933/ai_profiles/`.

---

# 18. Client-Screens

MVP:

1. Splash/Login
2. Hauptmenü
3. Lobby
4. Avatar-Draft
5. Prolog
6. Weltkarte
7. Länderübersicht
8. Region/Stadt
9. Wirtschaft
10. Forschung
11. Militär
12. Diplomatie
13. Telefon
14. Meeting
15. Geheimdienst
16. Rundenbericht
17. Chronik
18. Einstellungen

---

# 19. Offline-/Reconnect-Verhalten

- letzter sichtbarer State lokal gecacht
- Befehle nur als „gesendet“ markieren, wenn Server ClientCommandId bestätigt
- nach Reconnect Serverstate neu laden
- keine Konfliktauflösung im Client

---

# 20. Benachrichtigungen

Push-Notifications optional:
- neuer Turn
- 1 Stunde bis Deadline
- Telefon-/Meetinganfrage
- Vertrag
- Match beendet

Keine Push-Nachricht verrät geheime gegnerische Informationen auf Lock Screen.

---

# 21. Audio

Audio-System:
- Musik pro Epoche/Lage
- Telefonklingeln
- Telegramm/Benachrichtigung
- Karten-/UI-Sounds
- Kriegs-/Krisenatmosphäre zurückhaltend

Historische Gewalt- und Verfolgungsereignisse erhalten keine triumphale Gamification-Musik.

---

# 22. Grafikstil

Empfohlener Stil:
- politische Weltkarte mit leichtem Papier-/Archivcharakter
- klare moderne Mobile-UI darüber
- Portraits als stilisierte historische Illustrationen
- Ereigniskarten mit Datum, Ort, Quelle/Archivgefühl
- keine fotorealistische Brutalität

Farbkonzept muss zusätzlich Icons/Muster nutzen, damit Besitz/Alarmzustände barriereärmer erkennbar sind.

---

# 23. Performance-Ziel

Da das Spiel rundenbasiert ist, muss der Client nicht tausende Echtzeiteinheiten simulieren.

Ziel:
- Kartenregionen nur bei sichtbarem Zoom detaillieren
- Marker poolen
- große historische Datenpakete lazy laden
- serverseitige Rundenauflösung innerhalb weniger Sekunden für 4 Spieler

---

# 24. Deployment

Entwicklung:
- Docker Compose: API + PostgreSQL + optional Redis

Staging:
- separater DB-Cluster/Schema
- Test-Content

Produktion:
- Linux VPS/Cloud
- HTTPS
- tägliche Backups
- DB Point-in-Time Recovery nach Bedarf
- Migrationspipeline

---

# 25. Versionsstrategie

Drei unabhängige Versionen:

- `app_version`
- `ruleset_version`
- `content_version`

Ein laufendes Match bleibt auf seiner Ruleset-/Content-Version, damit ein Update nicht mitten im Match Berechnungen verändert.

---

# 26. Umsetzungsreihenfolge

1. neues Server-Solution-Skelett
2. Epoch-1933-Content-Schema
3. Match/Turn Engine
4. Ressourcenresolver
5. Eventresolver
6. Godot-Kartenprototyp
7. Lobby/4-Spieler-Sync
8. Diplomatie/Telefon
9. Forschung/Militär
10. historische Content-Erweiterung
11. KI
12. Balancing/Closed Alpha

## Quellen für technische Versionsentscheidung

- Godot official archive/release pages: Godot 4.7.2 stable (18 Aug 2026).
- Microsoft .NET official downloads: .NET 10 LTS active, 10.0.11 current Aug 2026.
- Microsoft ASP.NET Core docs: SignalR recommended over raw WebSockets for most real-time app scenarios.
- PostgreSQL official FAQ: PostgreSQL 18 current major version.

## Status

Die technische Zielarchitektur ist spezifiziert. Nächster Meilenstein ist der konkrete Projekt-/Content-Scaffold im Git-Branch.