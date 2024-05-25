<!--
//________________________________________________________________________________________________________________________
//
//  Copyright (C) 2024, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community by pressing the `Watch` button and get started commenting using the discussion panel at
//
//  https://github.com/mpostol/TP/discussions/182
//
//  by introducing yourself and telling us what you do with this community.
//_________________________________________________________________________________________________________________________
-->

# XAML - Description of the Graphical Interface

- XAML - Description of the Graphical Interface

## What is control?

It is a type that encapsulates user interface functionality and is used in client-side applications. This type has associated shape and responsibility to be used on the graphical user interface. A Control is a base class used in .NET applications, and the MSDN documentation explains it in detail. There is a bunch of derived classes that inherit from it, for example, Button.

## See also

- [XAML in WPF](https://docs.microsoft.com/dotnet/framework/wpf/advanced/xaml-in-wpf)
- [TreeView Overview](https://docs.microsoft.com/dotnet/framework/wpf/controls/treeview-overview?view=netframework-4.7.2)

<!-- 
# Dane graficzne - Generowanie Interfejsu Graficznego

- [Dane graficzne - Generowanie Interfejsu Graficznego](#dane-graficzne---generowanie-interfejsu-graficznego)
  - [Wprowadzenie](#wprowadzenie)
    - [Wstęp](#wstęp)
    - [Wybór Technologii](#wybór-technologii)
    - [Uruchomienie programu](#uruchomienie-programu)
  - [Praca z kodem](#praca-z-kodem)
    - [Śledzenie Zmian](#śledzenie-zmian)
    - [Czemu xml](#czemu-xml)
    - [Integracja funkcjonalności i grafiki](#integracja-funkcjonalności-i-grafiki)
    - [Klasa częściowa](#klasa-częściowa)
    - [xaml-semantyka - tworzenie nowych obiektów](#xaml-semantyka---tworzenie-nowych-obiektów)
    - [Kontrolka i renderowanie](#kontrolka-i-renderowanie)
    - [GUI jako drzewo kontrolek](#gui-jako-drzewo-kontrolek)
    - [Co to jest kontrolka](#co-to-jest-kontrolka)
    - [Kompilacja xaml](#kompilacja-xaml)
    - [Konwersja xaml na CSharp](#konwersja-xaml-na-csharp)
    - [Refleksja](#refleksja)
  - [Sekwencja uruchomienia](#sekwencja-uruchomienia)
  - [Praca domowa](#praca-domowa)
  - [Zakończenie](#zakończenie)

## Wprowadzenie

W tej lekcji kontynuujemy cykl dedykowany omówieniu wybranych zagadnień związanych z reprezentacją informacji procesowej w postaci graficznej. W trakcie poprzedniej lekcji omówiliśmy ogólne zagadnienia dotyczące metodyki projektowania graficznego interfejsu użytkownika. Teraz omówimy zagadnienia związane z generowaniem grafiki, która jest dopasowana do automatyzowano procesu biznesowego. Wygenerowanie takiej grafiki wymaga formalnego opisu. W trakcie tej lekcji będziemy odwoływać się do języka Extensible Application Markup Language, w skrócie zaml. On właśnie służy do tego, aby formalnie opisać to co widzimy na ekranie. Nowy język, to brzmi niepokojąco, tym bardziej, że poznanie tego języka jest poza zakresem kursu. Na szczęście jego pogłębiona znajomość nie jest wymagana. To nie jest warunek konieczny do zrozumienia żadnej z lekcji w tej grupie tematycznej.

### Wstęp

Zacznijmy od kilu definicji, wyjaśnień i wskazania kierunków poszukiwań nowych rozwiązań, w zakresie generowania graficznego interfejsu użytkownika na podstawie jego formalnego opisu, który my programiści możemy jakoś wkomponować w cały program. Pamiętajmy, że nadal celem jest rozdzielenie odpowiedzialności.

Obrazek jest ciągiem kolorowych pikseli. Muszą one się komponować w taki sposób, aby reprezentować wybrane informacje procesu, tzn. jego stan lub zachowanie. Podobnie jak w przypadku danych rezydujących w pamięci, których przecież nie przetwarzamy odwołując się bezpośrednio do ich binarnej reprezentacji, również graficzny interfejs użytkownika (w skrócie GUI od angielskiego graphical uset interface) nie tworzymy mozolnie składając piksele w spójną kompozycję. Co więcej, jak wspomniałem wcześniej GUI stanowi pulpit sterujący przebiegiem procesu, więc musi również zachowywać się dynamicznie, a w tym umożliwiać wprowadzanie danych i wydawanie poleceń.

### Wybór Technologii

Kolejnym problemem jest zatem, jak zapewnić odpowiedni poziom abstrakcji, tzn. ukryć szczegóły związane z powstawaniem obrazka. Podobnie jak w każdym przypadku, aby nasze rozważania były osadzone na praktycznych przykładach musimy użyć konkretnej technologii. Wybrałem Windows Presentation Foundation (w skrócie bardziej swojsko brzmiący skrót WPF), ale postaram się, byśmy niezależnie od tego wyboru nie stracili ogólności rozważań. Ważnym elementem składowym tej technologii jest właśnie język zaml, który użyjemy, aby ten wspomniany poziom abstrakcji uzyskać. Omówienie WPF wymaga osobnego kursu, a my pozostaniemy możliwie blisko zagadnieniom związanym z praktyką wykorzystania języka CSharp.

### Uruchomienie programu

Może to zabrzmi na początku zagadkowo, ale to że graficzny interfejs użytkownika jest elementem programu jest czymś oczywistym dla wszystkich. Nie dla wszystkich jest już natomiast takie oczywiste to, że nie jest on integralną częścią procesu realizującego program. Popatrzmy jeszcze raz na rysunek, gdzie widzimy GUI jako coś zewnętrznego w stosunku do procesu. Podobnie jak dane strumieniowe i strukturalne. Interfejs ten może nawet powstać na innej fizycznej maszynie. W takim przypadku dodatkowo trzeba uwzględnić konieczność komunikacji pomiędzy maszynami. W konsekwencji na interfejs i działający program musimy patrzeć jak na dwa niezależne byty działające w asynchronicznych środowiskach. Więc problemem jest jak synchronizować jago zawartość i zachowanie z przebiegiem programu. W tej lekcji nie odpowiemy do końca na to pytanie, a jedynie omówimy jaka jest relacja pomiędzy jego powstaniem i czasem życia instancji programu. Dwustronna synchronizacja to już temat dla następne lekcji.

## Praca z kodem

### Śledzenie Zmian

Wróćmy na chwilę do poprzedniej lekcji, w trakcie której korzystając z niezależnego programu Blend pracowaliśmy nad wyglądem obrazka generowanego przez przykładowy program Po zakończeniu pracy w programie Blend, możemy wrócić do tworzenia tekstu programu, czyli wrócić do Visual Studio. Tu dodatkowa uwaga, Blend to niezależny program, który można uruchomić korzystając z interfejsu systemu operacyjnego, a w tym z menu kontekstowego przeglądarki plików. Jest on niezależny przy zastrzeżeniu, że wyniki jego pracy da się wrzucić do repozytorium jako integralna część całego programu i śledzić historię jego zmian. To będzie możliwe tylko wtedy, jeśli wynik jego działania będą tekstem. To dziś nasz, programistów postulat, który musi być przestrzegany bez żadnych kompromisów. To dodatkowy powód, dlaczego formaty graficzne jak gif, JPG i pliki PowerPoint, żeby ograniczyć się tylko do popularnych rozwiązań ustalania wyglądu GUI, to generalnie zły pomysł.

Zobaczmy zatem jak ten postulat jest zrealizowany w proponowanym scenariuszu. Po powrocie do Visual Studio możemy zauważyć, że zmienił się jeden z plików. Po jego otwarciu w edytorze widzimy, że to plik o składni xml, a więc plik tekstowy, choć obok jest podobny obrazek ja poprzednio. Zamykam obrazek, bo jako programiści koncentrujemy się na samy tekście. Tu jednak trzeba zauważyć, że relacja obrazek tekst istnieje, teraz tylko trzeba ją określić. Przechodząc do folderu, gdzie znajduje się ten plik, możemy dokonać analizy jego zmian. Korzystając z narzędzia, które akurat mam zainstalowane mogę te różnice pokazać. Zmiany są na czerwono. Przy okazji, tu widzimy kolejny przykład GUI, czyli informacji procesowej reprezentowanej graficznie. U mnie procesem jest tekst programu w trakcie jego edycji. W tej reprezentacji każda litera to kompozycja pikseli, a czerwony kolor to informacja – tu jest zmiana. Proponuję nie tracić cennego czasu na analizowanie samych zmian w pliku. Lepiej ten czas poświęcić na zrozumienie treści i roli tego dokumentu, jako pewnego fragmentu naszego programu. Wróćmy zatem do Visual Studio.

### Czemu xml

Pewnie pierwszym zaskoczeniem jest to, że zamiast CSharp mamy xml. Są tego co najmniej dwa powody. Pierwszym jest to, że proces renderingu grafiki nie jest związany z implementacją algorytmów akurat w języku CSharp. Jak to wielokrotnie podkreślałem jest wiele języków, które możemy wykorzystać w tym celu. Więc pierwszy powód to przenośność rezultatu pracy. Drugi powód jest związany z użyciem edytora Blend, więc jakiegoś narzędzia programowego. Przypomnę, że standard xml, tak w ogóle powstał jako język przeznaczony do wymiany danych pomiędzy programami, czyli do integracji aplikacji. Tu widzimy, jak to działa w praktyce dla Blend i Visual Studio. Blend i Visual Studio to właśnie dwa niezależne programy, których funkcjonalność jest kompatybilna względem siebie.

### Integracja funkcjonalności i grafiki

Z punktu widzenia projektowania grafiki fakt, że mamy do czynienia z xml nas specjalnie nie powinien martwić. Wystarczy, że osoby znające się na kolorach i kształtach dadzą nam wygenerowany plik, który my dołączymy do projektu i nich Visual Studio zrobi resztę. No niestety to podejście jest zbyt piękne, by było realne. Cały ten misterny plan rozbija się o fakt, że prędzej czy później - a jak się możemy domyślać raczej prędzej - musimy zacząć mówić o integracji obrazka z funkcjonalnością procesową, a więc to za co nam płacą. Funkcjonalność to aktualne dane procesowe i zachowanie się interfejsu. My natomiast dane, czyli zbiory wartości i operacje na nich realizowanych, definiujemy używając typów i o nich musimy zacząć mówić.

### Klasa częściowa

Szukanie rozwiązania tego dylematu, co nasze, a co wynik działania jakiegoś edytora, rozpoczniemy od zauważenia pozornie błahego faktu, a mianowicie plik, który edytowaliśmy jest połączony w parę z innym plikiem. Jak otworzymy jego parę w edytorze to stwierdzamy, że jest to tekst CSharp. Co więcej widzimy słowo partial, więc zawiera on częściową definicję klasy. A może te dwa pliki tworzą jedną klasę, jeden typ zgodnie z tym o czym mówiliśmy poprzednio w temacie definicji częściowych, czyli partial. W omawianych poprzednio przypadkach definicji częściowych pokazywałem, że ostateczna definicja powstaje w wyniku zmieszania tekstu poszczególnych części. To ma sens tylko wtedy, jeśli części są napisane w tym samym języku, więc mają tę samą składnię i semantykę. W rozważanym przypadku to oczywiście nie jest spełnione. Tu próba mieszania tekstów o różnych składniach musi doprowadzić do rezultatu, który nie jest zgodny z żadnym językiem. Wróćmy zatem do poprzedniego pliku xml. Nasze podejrzenia się potwierdzają,  bo jak widzimy, w pierwszym elemencie tego pliku jest atrybut class i nazwa klasy częściowej, która jest połączona w parę.

### xaml-semantyka - tworzenie nowych obiektów

Składnia i semantyka plików xml zdefiniowana przez specyfikację tego standardu nie jest wystarczająca do wyjaśnienia naszych obaw, ale przecież do każdego pliku xml możemy dodać własne reguły semantyczne, które określą przykładowo, co tu oznacza słowo Grid. Z menu kontekstowego możemy przejść do definicji tego słowa i widzimy, że otwiera się dodatkowe okienko z definicja klasy o tej samej nazwie i gdzie wyróżniony jest konstruktor bezparametrowy dla tej klasy. To pozwala uprawdopodobnić tezę, że znaczenie tego zapisu jest następujące: wywołaj konstruktor bezparametrowy i w konsekwencji utwórz obiekt tej klasy.
Analizując kolejne elementy i atrybuty tego pliku xml widzimy, że odwołują się one do properties, czyli właściwości tej klasy.

### Kontrolka i renderowanie

Upraszczając, renderowanie to proces tworzenia kompozycji pikseli na ekranie korzystając z jakiegoś opisu – czyli u nas to zamiana tekstu w żywy obraz. Ponieważ układamy piksele na ekranie, to możemy mówić wyłącznie o czasie realizacji programu. W przypadku programowania obiektowego ten jakiś opis istniejący w trakcie realizacji programu musi być zbiorem obiektów połączonych w strukturę, a więc grafem. Obiekty są tworzone na podstawie typów. Zatem typy, które użyjemy do opisu obrazka muszą mieś wspólną cechę, a mianowicie przypisany kształt. Cały obrazek zatem musi być kompozycją typowych kształtów, które umożliwiają realizację dwóch dodatkowych funkcji, jak wprowadzanie danych i wykonywanie poleceń. Dodatkowo te kształty muszą również być adoptowalne do aktualnych potrzeb, co widzieliśmy w przypadku sposobu wypełnienia wybranego fragmentu ekranu. To wszystko można zrealizować dzięki polimorfizmowi i właściwościom czyli property typów.

### GUI jako drzewo kontrolek

Wróćmy zatem do pliku zaml, w którym widzimy mechanizm tworzenia obiektów. I teraz już wiemy, że tworzone obiekty muszą mieć wspólną cechę, a mianowicie być renderowalne. Skoro powstaje obiekt, to co zrobić z referencją do niego – przykładowo tu tworzymy obiekt na podstawie definicji klasy Grid. Jeśli nic, to GarbageCollector zajmie się nim natychmiast i go unicestwi. Przyjmijmy zatem tezę, że każdy obiekt utworzony zgodnie z hierarchią elementów pliku xml to kolekcja obiektów wewnętrznych. W takim przypadku wspomniany obiekt Grid byłby dodany do naszej klasy, ale przecież ona nie jest kolekcją. Tu zauważmy, że dziedziczy ona z klasy Window, która już taką kolekcję może być lub ją zawierać. W rezultacie tworzy się drzewko obiektów, którego elementem centralnym – czyli korzeniem - jest nasza klasa, która jest klasą częściową i dziedziczy z klasy Window.

### Co to jest kontrolka

Systematyczne omówienie języka xaml to temat na osobny kurs, więc tu przyjmijmy, że dostajemy ten plik jako rezultat działania specjalistów od estetyki, ergonomii i procesu biznesowego. Bez wnikania w szczegóły tego pliku, możemy zauważyć, że utworzony na ekranie obrazek też ma drzewiastą naturę i składa się z obrazków, które dalej składają się z następnych obrazków. W naszym przykładzie okienko to rodzaj tablicy, w komórkach której znajdują się lista, klawisze, pola tekstowe, itd. Innymi słowy każdy obiekt, który utworzyliśmy jest renderowany na ekranie, czyli każda klasa opisująca formalnie ten obiekt musi mieć skojarzony wygląd, więc reguły tworzenia pewnej kompozycji pikseli. Te klasy nazywamy potocznie kontrolkami. Więc nie wchodząc w szczegóły kontrolka to klasa, która implementuje funkcjonalność pozwalającą odwzorować pewien kształt i zachowanie na ekranie.

### Kompilacja xaml

Za wielce prawdopodobny możemy zatem przyjąć scenariusz, w którym plik xml napisany zgodnie z regułami pewnego języka bazującego na składni xml, jest konwertowany do języka CSharp i następnie możemy już te ujednolicone składniowo i semantycznie teksty wymieszać, tworząc z dwóch części ujednoliconą definicję klasę, a więc wrócić do dobrze znanego nam świata programowania w CSharp. Ten nowy język nazywamy zaml. Zgodnie z przedstawionym tu scenariuszem nie musimy nawet tego języka znać. I to by była prawda, gdyby wystarczyło utworzyć statyczny obrazek. My jednak musimy go ożywić, tzn. zobrazować stan procesu i zachowanie procesu przetwarzania, a więc wyświetlić dane procesowe, umożliwić ich edycję i reagować na polecenia użytkownika. Do tego tematu wrócimy w trakcie następnej lekcji. Może nas uspokajać fakt, że oprócz części w zaml mamy część w CSharp, zwaną codebehind i to że skoro kompilator może dokonać konwersji zaml na CSharp, to może my możemy wszystko napisać od razu w CSharp. Odpowiedź na pytanie czy jest to możliwe by nie używać zaml, jest twierdząca, więc pokusa jest duża. Niestety są koszta i to niemałe. Zaczym przejdziemy do ich szacowania, musimy zrozumieć skąd się biorą, ale pamiętajmy, że mamy trzy opcje. Tylko Blend, tylko CSharp i jakaś ich kombinacja.

### Konwersja xaml na CSharp

Żeby te wspomniane poprzednio koszty konwersji zaml na CSharp oszacować i lepiej zrozumieć mechanizmy działania środowiska, musimy popatrzeć, co robi kompilator na podstawie analizy tekstu programu. Zróbmy krótką analizę bez wnikania w szczegóły. W konstruktorze klasy znajdziemy wywołanie metody InitializeComponent, której - na pierwszy rzut oka - nie ma w tekście programu, ale kompilator nie zgłasza błędu, więc gdzieś jest. Z menu kontekstowego przejdźmy do definicji w tekście, gdzie ta metoda jest zdefiniowana. Z nagłówka otwartego pliku widzimy, że ten tekst jest automatycznie wygenerowany, ale zauważmy też, że nie zawiera on prostej konwersji tekstu zaml na CSharp, natomiast przekazuje on ścieżkę do pliku zaml do metody LoadComponent. Funkcjonalność tej metody jest dostarczana przez bibliotekę, ale z opisu możemy się dowiedzieć, że to ona tworzy wszystkie obiekty używając refleksji. Refleksja to wyższy stopień wtajemniczenia i to są te koszty. Bez refleksji konwersja 1:1 zaml na CSharp w ogólnym przypadku jest niemożliwa.

### Refleksja

Refleksja to temat, o którym mówiliśmy już trochę, więc można do niego wrócić. Tu jednak zakończymy nasze dociekania. Wrócimy jeszcze do tego tematu w następnej lekcji w kontekście automatycznego wiązania warstw w czasie komponowania programu polegającego na tworzeniu obiektów i wykorzystaniu referencji do nich by utworzyć strukturę obiektów odpowiedzialną za kompozycję, dwukierunkowy transfer danych i zachowanie się GUI.

## Sekwencja uruchomienia

W programowaniu obiektowym uruchomienie aplikacji musi skutkować utworzeniem pierwszego obiektu. Jego konstruktor zatem zawiera instrukcję, która jest jako pierwsza realizowana przez proces utworzony przez system operacyjny. Tu rodzi się pytanie, jak ją znaleźć.

Każdy projekt zawiera swój plik konfiguracyjny. W analizowanym projekcie jego zawartość można odczytać korzystając z menu kontekstowego. I tu znajdujemy miejsce, w którym możemy wybrać obiekt startowy. Do wyboru jest tylko jeden, a składnia jego nazwy przypomina nazwę typu. Skoro to jest typ, to tu warto sobie zadać pytanie jak środowisko deleguje typy do tej listy? Czy tu może być więcej elementów na tej liście?

Skoro to ma być obiekt startowy to identyfikator w dropboxie musi być nazwą klasy. W drzewku class view znajdujemy odpowiedni typ. Po otwarciu widzimy, że jest to teks zgodny z xml z rozszerzeniem zaml. Po synchronizacji z resztą plików można zauważyć, że plik ten jest jednym z pary połączonych plików. Drugim jest plikiem CSharp, ale jest to pusta definicja i nie ma tu nawet konstruktora. Jest to kolejny przykład klasy częściowej napisanej w dwóch językach, a więc spodziewamy się konwersji zaml na CSharp i mieszania tekstów. Wynik konwersji możemy znaleźć wracając do drzewka klas. W dolnej części okna znajduje się lista dwóch metod. Wybierając dowolną z nich otwiera się tekst, który został wygenerowany automatycznie i który zawiera metodę statyczną o nazwie Main tworzącą obiekt tej klasy. Wywołuje ona metodę instancji utworzonej klasy Initialize. W tej metodzie możemy znaleźć odwołanie do pliku zaml, a mianowicie podstawienie do property StartupUri wskazujące na poprzednio analizowany plik zawierający definicję graficznego interfejsu użytkownika, często zwanego shell.

Tu warto zwrócić uwagę, na fakt, że ta klasa dziedziczy po klasie Application. W ramach pracy domowej proszę sprawdzić, czy można zadeklarować więcej klas, które dziedziczą po klasie Application i jak to wpływa na zwartość drop-box’a w konfiguracji projektu. Definicja tej klasy jest praktycznie pusta, tzn. nie ma nawet konstruktora, co oznacza, że wykonywany jest konstruktor domyślny, czyli rób nic. Co jednak pozawala na to, żeby tu zdefiniować własny konstruktor bezparametrowy. Można też nadpisać wybrane metody zklasy bazowej, by zachowanie dopasować do indywidualnych potrzeb programu. Z wykorzystaniem wspomnianych konstrukcji językowych tu możemy zlokalizować wymagane działania pomocnicze przed rozpoczęciem realizacji logiki biznesowe. Typowym przykładem jest przygotowanie infrastruktury związanej ze śledzeniem programu, wywoływanie przed zakończeniem programu operacji Dispose dla wszystkich obiektów, które tego wymagają, ale również tworzenie dodatkowych obiektów związanych z logika biznesową lub przygotowanie infrastruktury do wstrzykiwania zależności.

## Praca domowa

Na koniec lekcji, jak zwykle, praca domowa. Aby następna lekcja była bardziej zrozumiała proponuję trzy zadania w ramach pracy domowej.

Po pierwsze, proszę utworzyć własny projekt WPF i zmienić domyślny obiekt startowy. Drugie zadanie to dodać dwie metody, które będą wywołane odpowiednio na początku i na końcu programu. Wszystko to sprawdzić w testach jednostkowych. Uprzedzam, że to ostanie zadanie nie jest banalne.

## Zakończenie

W tej lekcji to już wszystko. Dziękuję za poświęcony czas. W następnej lekcji będziemy kontynuowali omawianie tych zagadnień ze szczególny uwzględnieniem odprzężenia widoku oraz danych/funkcjonalności, które sterują interfejsem graficznym. Omówione tu przykłady ograniczyłem do współdziałania z technologią WPF. Musimy jednak pamiętać, że poznane konstrukcje językowe są uniwersalne i rozszerzalne, innymi słowy mogą być wykorzystane również w kontekście innych technologii.

-->
