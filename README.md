# System Zarządzania Hotelem

Prosta aplikacja konsolowa do zarządzania hotelem napisana w języku **C#**.
Aplikacja jest podzielona na kilka klas reprezentujących obiekty, które mogły by znaleźć się
w rzeczywistym systemie. Wykorzystuje ona prostą pętlę, w której użytkownik może wybrać poszczególne opcje.

Za pomocą tej aplikacji użytkownik może:
- Dodać nowy pokój
- Zarezerwować pokój
- Wyświetlić dostępne pokoje
- Anulować rezerwację
- Wyświetlić wszystkie rezerwacje

Aplikacja nie posiada funkcjonalności zapisu danych.

# Wymagania systemowe

Program jest napisany dla najnowszych systemów Windows. Do kompilacji i uruchomienia aplikacji
potrzebna jest aplikacja **Visual Studio 2022** lub **.NET**.

# Instalacja i uruchomienie aplikacji za pomocą aplikacji **Visual Studio 2022**

1. Sklonuj repozytorium.
2. Otwórz plik `src/zadanie4/zadanie4.sln` za pomocą programu **Visual Studio 2022**
3. Kliknij na ikonę zielonego zębatego koła, aby zbudować project
4. Uruchom aplikację klikając na ikonę z zieloną strzałką lub otwierając plik `zadanie4.exe` znajdujący się pod folderem `src/zadanie4/bin`.

# Instalacja i uruchomienie aplikacji za pomocą aplikacji **dotnet**

1. Sklonuj repozytorium.
2. Przejdź do katalogu `src/zadanie4` i uruchom następującą komendę:
   ```
   dotnet build
   ```
4. Uruchom aplikację otwierając plik `zadanie4.exe` znajdujący się pod folderem `src/zadanie4/bin` lub używając komendy:
   ```
   dotnet run
   ```

# Instrukcje

- Dodawanie pokoju:
  1. Wybierz opcję `1`
  2. Podaj numer pokoju, liczbę miejsc i cenę za dobę

- Rezerwacja pokoju:
  1. Wybierz opcję `2`
  2. Podaj datę początkową i końcową rezerwacji

- Wyświetlanie dostępnych pokoi:
  1. Wybierz opcję `3`

- Anulowanie rezerwacji:
  1. Wybierz opcję `4`
  2. Podaj ID rezerwacji

- Wyświetlanie rezerwacji:
  1. Wybierz opcję `5`

# Informacje techniczne

Informacje techniczne znajdują się w pliku `docs/docs.md`.