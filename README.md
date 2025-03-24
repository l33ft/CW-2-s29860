# CW-2-s29860

# Przedmiot: Aplikacje Baz Danych
## System Zarządzania Kontenerami

## Przegląd
System Zarządzania Kontenerami to aplikacja w języku C# zaprojektowana do zarządzania załadunkiem i transportem różnych typów kontenerów transportowych na statkach kontenerowych. System obsługuje różne typy kontenerów (na płyny, gaz, chłodnicze), każdy z określonymi właściwościami i ograniczeniami.

## Funkcjonalności

### Typy Kontenerów
- **Kontener Bazowy:** Klasa abstrakcyjna z wspólnymi właściwościami jak wymiary, waga, pojemność i unikalny system numeracji
- **Kontener na Płyny:** Do transportu płynów ze szczególnym uwzględnieniem materiałów niebezpiecznych
- **Kontener na Gaz:** Do transportu gazów z monitorowaniem ciśnienia i funkcjami bezpieczeństwa
- **Kontener Chłodniczy:** Kontenery z kontrolowaną temperaturą dla produktów spożywczych z walidacją typu produktu

### Funkcjonalność Kontenerów
- Automatyczne generowanie numerów seryjnych (format KON-X-Y)
- Załadunek towaru z walidacją pojemności
- Opróżnianie kontenera ze specjalnym traktowaniem kontenerów gazowych (5% retencji)
- Egzekwowanie wymagań temperaturowych produktów
- Powiadomienia o zagrożeniach dla niebezpiecznych operacji

### Zarządzanie Statkami
- Śledzenie inwentarza kontenerów na statkach
- Egzekwowanie limitów wagi i pojemności
- Załadunek i rozładunek kontenerów
- Transfery kontenerów między statkami
- Operacje wymiany kontenerów
- Szczegółowe raportowanie statusu statków i ich zawartości

### Funkcje Bezpieczeństwa
- Obsługa materiałów niebezpiecznych (limit napełnienia 50%)
- Ograniczenie dla płynów nienebezpiecznych (limit napełnienia 90%)
- Ochrona przed przepełnieniem z niestandardowymi wyjątkami
- Walidacja temperatury dla towarów chłodniczych
- Śledzenie ciśnienia dla kontenerów gazowych

## Szczegóły Techniczne

### Struktura Klas
- `IHazardNotifier`: Interfejs do obsługi i powiadamiania o niebezpiecznych sytuacjach
- `Container`: Abstrakcyjna klasa implementująca wspólną funkcjonalność kontenerów
- `LiquidContainer`, `GasContainer`, `RefrigeratedContainer`: Specjalistyczne implementacje kontenerów
- `ContainerShip`: Klasa dla operacji statków kontenerowych
- `OverfillException`: Niestandardowy wyjątek dla naruszeń pojemności

### Przykłady Kodu

#### Tworzenie Kontenerów
```csharp
// Tworzenie na banany
RefrigeratedContainer banany = new RefrigeratedContainer(
    height: 220, 
    weight: 800, 
    depth: 200, 
    maxCapacity: 10000, 
    productType: "Bananas", 
    temperature: 12
);

// Tworzenie kontenera dla paliwa
LiquidContainer paliwo = new LiquidContainer(
    height: 250, 
    weight: 500, 
    depth: 200, 
    maxCapacity: 8000, 
    isHazardous: true
);
```

#### Operacje Załadunku
```csharp
// Załadowanie kontenera towarem
banany.LoadCargo(9000);

// Załadowanie kontenera na statek
olympus.LoadContainer(banany);

// Przeniesienie kontenera między statkami
olympus.TransferContainer("KON-C-1", atlas);
```

## Przykłady Użycia

System zawiera walidację zapobiegającą operacjom takim jak:
- Przepełnianie kontenerów ponad ich pojemność
- Ustawianie niewystarczających temperatur chłodzenia dla produktów
- Przekraczanie limitów wagi i pojemności statków

System umożliwia efektywne zarządzanie flotą kontenerów i statków, z uwzględnieniem wszystkich ograniczeń bezpieczeństwa i operacyjnych wymagań.
