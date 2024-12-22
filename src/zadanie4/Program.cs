namespace zadanie4 {
    // klasa reprezentująca pokój
    class Room {
        public uint Nr; // numer
        public uint BedCount; // liczb osób
        public decimal Cost; // cena za dobę

        public Room(uint nr, uint bedCount, decimal cost)
            => (Nr, BedCount, Cost) = (nr, bedCount, cost);
    }

    // klasa reprezentująca rezerwację pokoju
    class Reservation {
        public Room Room; // pokój
        public DateTime StartDate; // data początkowa
        public DateTime EndDate; // data końcowa

        public Reservation(Room room, DateTime startDate, DateTime endDate)
            => (Room, StartDate, EndDate) = (room, startDate, endDate);
    }

    // klasa zarządzająca pokojami i rezerwacjami
    class Hotel {
        List<Room> Rooms = []; // lista pokoi
        List<Reservation> Reservations = []; // lista rezerwacji

        // metoda zwracająca pokój o numerze nr, przechodząc po liście pokoi
        Room? FindRoom(uint nr) {
            foreach (Room room in Rooms) {
                if (room.Nr == nr) return room;
            }

            return null;
        }

        // metoda sprawdzająca czy dla danego pokoju występuje rezerwacja, przechodząc
        // przez listę rezerwacji i porównując podany pokój z pokojem zarezerwowanym
        bool RoomIsReserved(Room room) {
            foreach (Reservation rsv in Reservations) {
                if (rsv.Room == room) return true;
            }

            return false;
        }

        // metoda wypisująca informacje o danym pokoju
        void PrintRoom(Room room) {
            Console.WriteLine($"Numer: {room.Nr}");
            Console.WriteLine($"Liczba miejsc: {room.BedCount}");
            Console.WriteLine($"Cena za dobę: {room.Cost}zł");
        }

        // metoda wypisująca dane o rezerwacji o indeksie w liście rezerwacji
        // oznaczonym argumentem index
        void PrintReservation(int index) {
            Reservation rsv = Reservations[index];

            Console.WriteLine($"ID: {index}");
            Console.WriteLine($"Okres rezerwacji: {rsv.StartDate} - {rsv.EndDate}");
            Console.WriteLine("Pokój:\n");
            PrintRoom(rsv.Room);
        }

        // metoda wypisująca informacje o wszystkich pokojach w liście
        void ListRooms() {
            Console.WriteLine("Pokoje:");
            foreach (Room room in Rooms) {
                Console.WriteLine("-----");
                PrintRoom(room);
                Console.WriteLine("-----");
            }
            Console.WriteLine("");
        }

        // metoda wypisująca informacje o jedynie niezarezerwowanych pokojach w liście
        void ListAvailableRooms() {
            Console.WriteLine("Dostępne pokoje:");
            foreach (Room room in Rooms) {
                if (RoomIsReserved(room))
                    continue;

                Console.WriteLine("-----");
                PrintRoom(room);
                Console.WriteLine("-----");
            }
            Console.WriteLine("");
        }

        // funkcja wypisująca informacje o każdej rezerwacji w liście
        void ListReservations() {
            Console.WriteLine("Rezerwacje:");
            for (int i = 0; i < Reservations.Count; i++) {
                Console.WriteLine("-----");
                PrintReservation(i);
                Console.WriteLine("-----");
            }
            Console.WriteLine("");
        }

        // menu służące dodaniu do systemu pokoju o wprowadzonych przez użytkownika parametrach
        void MenuAddRoom() {
            try {
                ListRooms();

                Console.WriteLine("Podaj numer pokoju:");
                uint nr = Convert.ToUInt32(Console.ReadLine());
                if (FindRoom(nr) is not null) { // pokoju o numerze nr nie może być w systemie
                    Console.WriteLine($"Pokój o numerze {nr} już istnieje.");
                    return;
                }

                Console.WriteLine("Podaj liczbę miejsc:");
                uint bedCount = Convert.ToUInt32(Console.ReadLine());
                if (bedCount == 0) { // liczba osób musi być dodatnia
                    Console.WriteLine("Pokój musi być przynajmniej jednoosobowy.");
                    return;
                }

                Console.WriteLine("Podaj cenę za dobę: (zł)");
                decimal cost = Convert.ToDecimal(Console.ReadLine());
                if (cost <= 0) { // cena za dobę musi być dodatnia
                    Console.WriteLine("Cena jest zbyt niska.");
                    return;
                }

                Rooms.Add(new Room(nr, bedCount, cost));
                Console.WriteLine("\nPokój został dodany do systemu.");
            }
            catch {
                Console.WriteLine("Podane dane nie są poprawne.");
            }
        }

        // menu służące dodaniu do systemu rezerwacji o wybranych przez użytkownika parametrach
        void MenuReserveRoom() {
            try {
                ListAvailableRooms(); // wypis dostępnych pokoi

                Console.WriteLine("Podaj numer pokoju:");
                uint nr = Convert.ToUInt32(Console.ReadLine());

                Room? room = FindRoom(nr);
                if (room is null) { // pokój o numerze nr musi znajdować się w systemie
                    Console.WriteLine($"Pokój o numerze {nr} nie istnieje.");
                    return;
                }
                if (RoomIsReserved(room)) { // pokój nie morze być już zarezerwowany
                    Console.WriteLine($"Pokój o numerze {nr} jest już zarezerwowany.");
                    return;
                }

                Console.WriteLine("Podaj datę początkową rezerwacji: (XX/XX/XXXX XX:XX)");
                DateTime startDate = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Podaj datę końcową rezerwacji: (XX/XX/XXXX XX:XX)");
                DateTime endDate = Convert.ToDateTime(Console.ReadLine());

                if (startDate >= endDate) {
                    Console.WriteLine("Okres nie jest zgodny.");
                    return;
                }
                if (DateTime.Now >= startDate) {
                    Console.WriteLine("Okres już minął.");
                    return;
                }

                Reservations.Add(new Reservation(room, startDate, endDate));
                Console.WriteLine("\nPokój został zarezerwowany.");
            }
            catch {
                Console.WriteLine("Podane dane nie są poprawne.");
            }
        }

        // menu służące anulowaniu rezerwacji
        void MenuCancelReservation() {
            try {
                ListReservations(); // wypis rezerwacji

                Console.WriteLine("Podaj ID rezerwacji:");
                int index = Convert.ToInt32(Console.ReadLine());
                if (index < 0 || index >= Reservations.Count) { // rezerwacja musi należeć do listy
                    Console.WriteLine($"Rezerwacji o ID {index} nie ma w systemie.");
                    return;
                }

                Reservations.RemoveAt(index);
                Console.WriteLine("\nRezerwacja została zanulowana.");
            }
            catch {
                Console.WriteLine("Podane dane nie są poprawne.");
            }
        }

        // menu główne
        public void MenuStart() {
            while (true) {
                Console.WriteLine("System zarządzania zadaniami pracowników.");
                Console.WriteLine("1. Dodaj pokój.");
                Console.WriteLine("2. Zarezerwuj pokój.");
                Console.WriteLine("3. Wyświetl dostępne pokoje.");
                Console.WriteLine("4. Anuluj rezerwację.");
                Console.WriteLine("5. Wyświetl wszystkie rezerwacje.");
                Console.WriteLine("6. Wyjdź.");

                int op;
                try {
                    op = Convert.ToInt32(Console.ReadLine());
                }
                catch {
                    op = 0;
                }

                Console.Clear();

                switch (op) {
                    case 1: MenuAddRoom(); break;
                    case 2: MenuReserveRoom(); break;
                    case 3: ListAvailableRooms(); break;
                    case 4: MenuCancelReservation(); break;
                    case 5: ListReservations(); break;
                    case 6: return;
                    default: Console.WriteLine("Nieprawidłowa operacja."); break;
                }

                Console.WriteLine("Przyciśnij jakikolwiek klawisz.");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    internal class Program {
        static void Main(string[] args) {
            Hotel hotel = new();
            hotel.MenuStart();
        }
    }
}
