Zewnętrzne API, odpowiedzialne za zarządzanie użytkownikami naszej aplikacji udostępnia nam bibliotekę do komunikacji z nimi. Biblioteka zawiera jedną metoda, zwracającą listę użytkowników w formacie XML (imię, nazwisko).

Część systemu tworzona przez nas, na potrzeby jednego z modułów wymaga listy nazw użytkowników (wynik konkatenacji imię + nazwisko). W innym module aplikacji potrzebne jest wczytywanie użytkowników z dokumentu CSV, dostarczonego przez dział księgowy.

Proszę napisać adapter który dokona konwersji listy użytkowników z formatu CSV na interfejs znany naszej aplikacji, a następnie wyświetlić w terminalu wszystkich klientów.

Wynik działania aplikacji:

1. Adam Nowak
2. Katarzyna Kowalska
3. Wojciech Jankowski