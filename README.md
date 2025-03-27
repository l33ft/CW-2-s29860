# CW-2-s29860

# Przedmiot: Aplikacje Baz Danych
# System Zarządzania Kontenerami

## Przegląd
Aplikacja zarządzająca załadunkiem i transportem kontenerów na statkach. Obsługuje różne typy kontenerów z uwzględnieniem specyficznych wymagań bezpieczeństwa i transportowych.

## Funkcjonalności

### Typy Kontenerów
- Kontener Bazowy
- Kontener na Płyny
- Kontener na Gaz
- Kontener Chłodniczy

### Kluczowe Możliwości
- Automatyczne generowanie numerów seryjnych
- Walidacja załadunku towaru
- Kontrola wagi i pojemności kontenerów
- Zarządzanie statkami kontenerowymi
- Powiadomienia o zagrożeniach

## Przykłady Użycia

```csharp
// Tworzenie kontenera chłodniczego
RefrigeratedContainer banany = new RefrigeratedContainer(
    height: 220, 
    weight: 800, 
    depth: 200, 
    maxCapacity: 10000, 
    productType: "Bananas", 
    temperature: 12
);

// Załadunek na statek
olympus.LoadContainer(banany);
```

## Funkcje Bezpieczeństwa
- Ograniczenie napełnienia kontenerów
- Kontrola temperatury produktów
- Monitorowanie ciśnienia w kontenerach gazowych
- Zabezpieczenie przed przepełnieniem

## Technologie
- Język: C#
- Paradygmat: Programowanie obiektowe
- Środowisko: .NET

## Instalacja
1. Sklonuj repozytorium
2. Otwórz projekt w Visual Studio
3. Zbuduj rozwiązanie
   
