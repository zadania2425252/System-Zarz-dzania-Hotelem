# Struktura projektu

Aplikacja składa się z jednego pliku: `src/zadanie4/Program.cs`, w którym znajdują się następujące klasy:

- **Program**
  Klasa posiadająca metodę `Main`, w której tworzony jest obiekt klasy Hotel
  i wywoływana jest metoda główna `MenuStart`.

- **Room**
  Klasa reprezentująca pokój, posiadająca:
  - `Nr`: Unikatowy numer pokoju
  - `BedCount`: Liczbę osób w danym pokoju
  - `Cost`: Cenę za dobę w formacie `decimal`

- **Reservation**
  Klasa reprezentująca rezerwację, posiadająca:
  - `Room`: Odniesienie do zarezerwowanego pokoju
  - `StartDate`: Datę początkową rezerwacji
  - `EndDate`: Datę końcową rezerwacji

- **Hotel**
  Klasa zarządzająca, posiadająca
  Atrybuty:
  - `Rooms`: Listę pokoi
  - `Reservations`: Listę rezerwacji
  Metody pomocnicze:
  - `FindRoom`
  - `RoomIsReserved`
  - `PrintRoom`
  - `PrintReservation`
  - `ListRooms`
  - `ListAvailableRooms`
  - `ListReservations`
  Metody główne:
  - `MenuAddRoom`:
    1. Wyświetla informacje o wszystkich pokojach za pomocą metody `ListRooms`
    2. Pyta użytkownika o podanie numeru nowego pokoju, sprawdzając czy pokój o takim numerze nie istnieje
       za pomocą metody `FindRoom`
    3. Pyta użytkownika o podanie liczby miejsc, sprawdzając czy liczba nie jest równa 0
    4. Pyta użytkownika o podanie ceny za dobę, sprawdzając czy jest większa od 0
    5. Dodaje nowy pokój do listy `Rooms` za pomocą metody `Add`

  - `MenuReserveRoom`
    1. Wyświetla informacje o niewypożyczonych pokojach za pomocą metody `ListAvailableRooms`
    2. Pyta użytkownika o podanie numeru nowego pokoju, sprawdzając czy pokój o takim numerze znajduje się w bazie
       za pomocą metody `FindRoom`
    3. Sprawdza, czy pokój o podanym numerze nie jest zarezerwowany za pomocą metody `RoomIsReserved`
    4. Pyta użytkownika o podanie daty początkowej i końcowej rezerwacji, sprawdzając, czy podany okres jest zgodny
       i już nie minął
    5. Dodaje nową rezerwację do listy `Reservations` za pomocą metody `Add`

  - `MenuCancelReservation`
    1. Wyświetla informacje o wszystkich rezerwacjach za pomocą metody `ListReservations`
    2. Pyta użytkownika o indeks rezerwacji i sprawdza, czy należy on do listy `Reservations`
    3. Usuwa rezerwację o podanym indeksie z listy `Reservations` za pomocą metody `RemoveAt`

  - `MenuStart`
    1. Wypisuje informacje o numerach opcji do konsoli
    2. Pyta użytkownika o podanie numeru opcji i przechodzi do odpowiedniej metody
    3. Po zakończeniu wykonywania wybranej opcji, wraca do punku 1

# Dodawanie nowej funkcjonalności

1. Dodaj potrzebne atrybuty do klas **Room**, **Reservation** lub **Hotel**
2. Dodaj nową, pustą metodę do klasy **Hotel**
3. Przejdź do metody `MenuStart`, wypisz numer i nazwę opcji do konsoli
   oraz wywołaj nową metodę dla wypisanego numeru w bloku switch.
   Użytkownik będzie teraz miał możliwość wyboru nowej opcji.
4. Uzupełnij nową metodę, trzymając się następujących zasad:
   - Używaj bloków `try-catch` nad metodami, które mogą wywołać błąd
   - W przypadku wystąpienia błędu lub podania przez użytkownika niepoprawnych danych,
     wypisz stosowny komunikat do konsoli i zwróć