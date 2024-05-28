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

# MVVM Programming Design Pattern

- MVVM Programming Design Pattern


<!--
# Wzorzec MVVM

- [Wzorzec MVVM](#wzorzec-mvvm)
  - [Wprowadzenie](#wprowadzenie)
  - [Jaki mamy problem](#jaki-mamy-problem)
    - [Manipulowanie obrazkiem](#manipulowanie-obrazkiem)
    - [Model warstwowy mvvm](#model-warstwowy-mvvm)
    - [Wstrzykiwanie zależności](#wstrzykiwanie-zależności)
  - [Dynamiczne Modyfikowanie Cech obrazka](#dynamiczne-modyfikowanie-cech-obrazka)
    - [Widoczność kontrolki](#widoczność-kontrolki)
    - [Modyfikacja innych cech](#modyfikacja-innych-cech)
    - [Ograniczona Rola Code-behind](#ograniczona-rola-code-behind)
    - [Code behind - dependency injection (Binding)](#code-behind---dependency-injection-binding)
  - [Obsługa widoku poprzez powiązania](#obsługa-widoku-poprzez-powiązania)
    - [Sprzęganie kontrolek z danymi](#sprzęganie-kontrolek-z-danymi)
    - [DataContext](#datacontext)
    - [Binding](#binding)
    - [DataBinding – użycie refleksji](#databinding--użycie-refleksji)
    - [INotifyPropertyChange](#inotifypropertychange)
    - [ICommand](#icommand)
    - [RelayCommand](#relaycommand)
  - [Model warstwowy](#model-warstwowy)
    - [Model Warstwowy Wprowadzenie](#model-warstwowy-wprowadzenie)
    - [Czy projekt może być warstwą](#czy-projekt-może-być-warstwą)
    - [MVVM jako podwarstwy warstwa prezentacji](#mvvm-jako-podwarstwy-warstwa-prezentacji)
    - [Diagram View](#diagram-view)
    - [Porządkowanie diagramu](#porządkowanie-diagramu)
    - [Jak Zaimplementować](#jak-zaimplementować)
    - [Implementacja warstw ogólnej architektury programu](#implementacja-warstw-ogólnej-architektury-programu)
    - [Powody Wprowadzenia Warstw](#powody-wprowadzenia-warstw)
    - [Wstrzykiwanie zależności View](#wstrzykiwanie-zależności-view)
  - [Praca domowa](#praca-domowa)
    - [Refleksja](#refleksja)
    - [Wstrzykiwanie zaleznosci](#wstrzykiwanie-zaleznosci)
    - [Diagram kontroli zależności](#diagram-kontroli-zależności)
  - [Zakończenie](#zakończenie)

## Wprowadzenie

W tej lekcji kontynuujemy cykl dedykowany omówieniu wybranych zagadnień związanych z inżynierią tworzenia graficznego interfejsu użytkownika – w skrócie GUI od angielskiego graphical user interface. W trakcie poprzednich lekcji tej grupy tematycznej omówiliśmy ogólne wymagania dotyczące projektowania i programowe mechanizmy tworzenia GUI. Natomiast teraz odpowiem na pytanie jak ożywić obrazek interfejsu?

Na podstawie dotychczasowych doświadczeń możemy zauważyć, że w przypadku danych graficznych okienko, czyli window jest samo-wystarczającą jednostką, która jest tworzona przez program i zarządzana przez system operacyjny. Tu zarządzane oznacza przesuwanie, powiększanie, pomniejszana, itd. To oczywiście nie dziwi od czasów powstania pierwszych systemów operacyjnych Windows, w których podstawą komunikacji człowiek maszyna jest właśni okno.

Program może oczywiście wykorzystywać jednocześnie klika okienek, podobnie jak kilka baz danych, czy kilka plików. W każdym z tych przypadków możemy mówić o niezależnym zewnętrznym repozytorium danych. W przypadku okienek musimy liczyć się jednak z istotną różnicą, a mianowicie w tym przypadku interakcja jest dwukierunkowa. W przypadku baz danych też możemy spodziewać się konieczności uwzględnienia dynamicznych zmian danych, jednak tylko w przypadku okienek musimy reagować na polecenia użytkownika.

Zobaczmy zatem jak sobie z tymi problemami poradzić. Mam prośbę o cierpliwość, bo to jest jedna z dłuższych i bardziej wymagających lekcji.

## Jaki mamy problem

Tradycyjnie – by wprowadzić elementarny porządek - zacznijmy od zdefiniowania najważniejszych problemów i wskazania kierunków dalszych poszukiwań rozwiązań dotyczących architektury aplikacji w kontekście komunikacji z użytkownikiem z wykorzystaniem wzorca MVVM to jest skrót od angielskiego model, view, view-mode, czyli w wolnym tłumaczeniu model, widok i widok modelu.

### Manipulowanie obrazkiem

Manipulowanie obrazkiem, czyli zmiana jego cech,  jak  kolor i wygląd,  to pierwsze zadanie leżące na styku program i graficzna reprezentacja danych. Tu wrócimy do języka zaml z pytaniem, gdzie dynamicznie modyfikować cechy obrazka. Obrazek opisany jest nowym językiem, który nie powstał po to, by w nim implementować algorytm działania, czyli logikę biznesową. Z drugiej strony język ten bezpośrednio wykorzystuje typy zdefiniowane w CSharp, więc punkt styku jest, tylko jak go wykorzystać.

### Model warstwowy mvvm

Zgodnie z dobrze znanymi zasadami inżynierii oprogramowania program powinien mieć konstrukcję warstwową. Konstrukcja warstwowa oznacza, że co najmniej jest warstwa wyższa i niższa, choć zwykle warstw jest więcej. Żebyśmy wiedzieli, która z nich jest wyższa to tylko ona musi się odwoływać do warstwy niższej. Warstwa niższa musi być skonstruowana tak, by nie wiedzieć o istnieniu warstwy wyższej. Czyli odwołania muszą być jednokierunkowe, często nazywamy je hierarchicznymi.

Program powinien mieć konstrukcję warstwową – to łatwo powiedzieć, ale co to jest warstwa. Program to tekst i ma raczej budowę strumieniową – to ciąg znaków. Oczywiście w tej zasadzie pojęcie warstwy jest abstrakcyjne, ale żeby stwierdzić, że architektura programu jest warstwowa musimy to pojęcie jakoś zaimplementować tak, by każdy wiedział co to jest warstwa. Poznamy tu konkretną implementację zwaną mvvm od angielskiego model, view i view-model, czyli w wolnym tłumaczeniu: model, widok i model widoku.

### Wstrzykiwanie zależności

Nie trudno sobie wyobrazić scenariusz, w którym realizując pewną operację w warstwie Logiki potrzebujemy dodatkowych informacji od użytkownika, przykładowo nazwy pliku. Uzyskanie tych informacji wymaga komunikacji z użytkownikiem, a więc zaangażowania warstwy Prezentacji i wyświetlenia okienka zwanego pop-up. No ale przecież warstwa Logiki powinna być skonstruowana tak, żeby nie miała świadomości istnienia warstwy Prezentacji, ba ta jest nad nią. W tej sytuacji pomocy będziemy szukali we wzorcu Wstrzykiwanie zależności, a po angielski Dependency Injection. Ci którzy o tym wzorcu już coś słyszeli mogą poczuć niepokój, że to nie kolejny punkt w lekcji, tylko wstęp do nowego kursu. Faktycznie obawy są uzasadnione, ponieważ na ten temat napisano już wiele opracowań, powstało wiele framework'ów i terminów pochodnych choćby Inversion of Control, czyli w wolnym tłumaczeniu odwrócenie sterowania. Nie wchodząc w spory terminologiczne i nie rozstrzygając, czy te publikacje i rozwiązania dotyczą wstrzykiwania zależności perse, czy raczej automatyzacji wstrzykiwania zależności spróbujemy rozwiązać problem i rozprząc warstwy by uniknąć odwołań cyklicznych pomiędzy nimi, czyli rekurencji w architekturze.

## Dynamiczne Modyfikowanie Cech obrazka

Zacznijmy od określenia w jaki sposób możemy ożywić zawartość interfejsu. Sformułowanie ożywić jest oczywiście kolokwializmem, który oznacza **dynamiczne modyfikowanie cech obrazka**, edycję danych za jego pośrednictwem i reagowanie na polecenia użytkownika. Innymi słowy, zadanie jest takie: sprząc uprzednio wygenerowany obrazek GUI z danymi procesowymi.

Podstawowym narzędziem, które już znamy to wyświetlanie okien. Okno podstawowe jest otwierane przez środowisko. Natomiast w tym projekcie mamy jeszcze jedno okno, które pojawia się po kliknięciu na jeden z klawiszy. Nie wnikając teraz w szczegóły przyjmijmy, że kliknięcie na klawisz ma powodować konieczność wykonania w tle jakiejś ciężkiej pracy - przykładowo czytany i analizowany jest plik - i w konsekwencji wyświetlane jest inne okienko – czyli typowy pop-up, jeśli wszystko się uda. Czyli tu decydujemy jak ma wyglądać okienko, ale decyzje o tym czy będzie ono wyświetlone podejmujemy w części odpowiedzialnej za realizację algorytmu przetwarzania danych procesowych. Tu warto przypomnieć, że okienko to klasa, która dziedziczy z klasy Window i żeby okienko się pojawiło trzeba wywołać metodę Show, którą widzimy w podglądzie definicji klasy Window.

Patrząc na zawartość definicji tej klasy zapisanej w języku xaml widzimy, że wyświetlane kontrolki tworzą strukturę drzewa, tzn. referencje kontrolek wewnętrznych, przykładowo TreeView, są dodawane do kolekcji obiektów zewnętrznych. O hierarchii zawierania decyduje struktura pliku xml. Teoretycznie zatem manipulując zawartością tych kolekcji przez dodawanie i usuwanie z nich elementów można wpływać na zawartość okna. Ponieważ to dość nietypowe postępowanie i funkcjonalność tą łatwo zastąpić nie będziemy tego podejścia dalej analizować, po prostu szkoda czasu.

### Widoczność kontrolki

Zamiast dodawać kontrolki do kolekcji kontrolki nadrzędnej możemy wykorzystać właściwość  Visibility. Przyjmuje ona jedną z trzech wartości, które widzimy na ekranie. Praktyczna rada zatem jest taka, aby na etapie projektowania statycznego obrazka dodać wszystkie kontrolki, które mogą pojawiać się na ekranie i dopiero dynamicznie zmieniać odpowiednio do potrzeb tą właściwość.

Czasami kontrolki mogą być widoczne na ekranie, ale w trybie statycznym. Przykładem takiego trybu jest nieaktywny klawisz, tzn. taki, który jest widoczny na ekranie, ale nie można go kliknąć, więc wydać stosownego polecenia. Kolejna właściwość, tym razem o nazwie IsEnabled może być wykorzystana w tym celu. Ja tu ją zmieniam statycznie, ale w rzeczywistości trzeba to robić dynamicznie w zależności od stanu, w jakim znajduje się proces. Tu warto wspomnieć, że język xaml umożliwia zdefiniowanie GUI jako maszyny stanu i sterowanie wyglądem w zależności od stanu, w jakim interfejs się znajduje. Dzięki temu możemy kontrolki grupować i sterować nimi poprzez zmianę stanu całego interfejsu, a nie poprzez zmianę poszczególnych właściwości kontrolek. Ponieważ naszym celem tu i teraz nie jest poznanie języka zaml, więc wszystkich zainteresowanych szczegółowym poznaniem tego mechanizmu i w ogóle języka zaml odsyłam do innych materiałów dedykowanych dla tego tematu.

### Modyfikacja innych cech

Podobnie modyfikując wartości różnych właściwości zmieniamy inne cechy kontrolek jak: kolor, kształt, sposób wypełniania, itd. Jest ich bardzo dużo, więc w tym zakresie może okazać się przydatny  poznany wcześniej edytor Blend.

Co modyfikować, by ożywić interfejs, to pierwsze ważne pytanie. Ale teraz przechodzimy do drugiego pytania, które brzmi: gdzie modyfikować. Oczywiście jest kilka odpowiedzi na to pytanie i spróbujmy je teraz przeanalizować i sformułować jakieś ogólne praktyczne zalecenia.

Pierwszą odpowiedź na pytanie, gdzie modyfikować, już znamy, tym miejscem jest oczywiście tekst XAML. Modyfikacja w XAML ma tę wadę, że w zasadzie ogranicza się do podstawiania stałych. Tu trzeba podkreślić, że do każdej właściwości zdefiniowanej przez kontrolki są już podstawiane wartości domyślne, więc dla typowego zachowania nie trzeba nic modyfikować. Przykładem jest  Visibility, którego wartością domyślną jest oczywiście Visible. Oczywiście język ten pozwala na podstawiania nie tylko stałych, ale jego użycie do implementacji algorytmów nie związanych bezpośrednio ze sterowaniem GUI, to nie jest dobry pomysł.

### Ograniczona Rola Code-behind

Tekst XAML i skojarzony z nim CSharp, zwany code behind, tworzą razem jedną klasę, bo są to definicje częściowe. Oczywiście wszystkie właściwości mogą być zatem modyfikowane w code-behind. To rozwiązanie ma jednak kilka wad. Ograniczmy się do omówienia trzech, którym można nadać status limitujące.  

Pierwsza wada związana jest z ewidentnym złamaniem w takim przypadku zasady **separation of concerns**. W bardzo wolnym tłumaczeniu ta zasada znaczy unikanie konieczności wykorzystania podzielności uwagi, a w istocie zachęca do koncentrowania się wyłącznie na pojedynczych dobrze odseparowanych zagadnieniach. Ma to związek z psychologią i stwierdzonymi ułomnościami przebiegu naszych procesów myślowych, jeśli rozwiązujemy problem wielowątkowy. W naszym przypadku jeśli pracujemy nad GUI, to nie pracujmy jednocześnie nad automatyzacją procesu, czyli implementacją algorytmów przetwarzania danych procesowych. Skoncentrujmy się wyłącznie na komunikacji człowiek maszyna.

Jest jeszcze jedna bardzo wymierna wada, a mianowicie jednym z popularnych sposobów sprawdzania poprawności programu jest zastosowanie **testów jednostkowych**. Oprócz testowania poprawności są one również szczególnie przydatne do sprawdzenia, czy w tekście programu nie zostały wprowadzone istotne modyfikacje, które mogą mieć efekt uboczny i wymagać uwzględnienia w innych częściach programu. Ja dodatkowo i trochę nietypowo używam testów w przykładach do kursu tak, aby  pokazać wybrane cechy omawianych rozwiązań. Testy jednostkowe mają tę wadę, że nie mają wsparcia dla graficznego interfejsu użytkownika. By je można było stosować w możliwie szerokim zakresie,  dane i funkcjonalność tego interfejsu powinny być odseparowane tak, by można było dla nich utworzyć niezależne testy jednostkowe bez konieczności uruchamiania renderingu grafiki. W naszym przykładzie ten podział zrealizowałem poprzez umieszczenie sterowania grafiką w osobnym projekcie, który w nazwie ma przyrostek View.

Kolejna wada jest równie wymierna. W projekcie dedykowanym dla GUI widzimy twardą zależność, czyli referencję do **PresentationFramework**. To uniemożliwia używanie generowanych tu rezultatów na systemach operacyjnych innych niż Microsoft Windows. Więc program staje się nieprzenośny. Umieszczenie tu tekstu nie związanego bezpośrednio ze sterowaniem grafiką łamie kolejną zasadę inżynierii programowania, a mianowicie reusability, więc znowu w wolnym tłumaczeniu oznacza to możliwość ponownego wykorzystania tekstu - w tym przypadku dla innej technologii GUI. Możliwość ponownego wykorzystania, to już bezpośrednie przełożenie na pieniądze, bo w przypadku braku przenośności podobny tekst programu trzeba jeszcze raz napisać, a co gorsza później go utrzymać.

Podsumowując, umieszczenie tekstu programu implementującego jakiekolwiek działania związane z przetwarzaniem danych procesowych w code-behind, a więc w tej części programu, łamie zasadę separation of concerns, ogranicza możliwość korzystania z testów jednostkowych i ogranicza przenośność rozwiązania. To uwagi limitujące i prowadzą do wniosku – nie róbmy tego, to nie jest dobry pomysł.

### Code behind - dependency injection (Binding)

A co z tym fragmentem tekstu. Czy przypadkiem sam sobie nie zaprzeczam. To tego jeszcze wrócę, na razie proszę przyjąć na wiarę odpowiedź, że to jest zgodnie z zaleceniami, a ten tekst teoretycznie można usunąć, ale to nie takie proste.

Skoro miejscem ożywienia interfejsu użytkownika nie powinien być XAML i code-behind to muszą być inne części programu. Tu niestety napotykamy na barierę związaną z kontrolą zgodności typów. A mianowicie, żeby kontrolować zgodność typów, to najpierw te typy trzeba znać. Skoro projekty technologicznie nie związane z GUI mają być niezależne, jak to jest w naszym przypadku dla projektu `GraphicalData`, nie mogą znać tych typów, bo staną się zależne od technologii i cały misterny plan spali na panewce.

Jak przeciąć ten węzeł gordyjski? Do tej pory dyskusja była reaktywna, mianowicie kończyła się stwierdzeniem czego nie możemy zrobić. Jak się możemy domyślać, rozwiązaniem jest oczywiście kompromis. W ramach kompromisu - po pierwsze - ograniczymy role kontrolek, które tworzą warstwę View do roli pośrednika przekazującego dane pomiędzy użytkownikami interfejsu i warstwami leżącymi poniżej tej warstwy. Do kwestii warstw jeszcze wrócimy w dalszej części lekcji, więc dla uproszczenia tu warstwę View możemy traktować, jako osobny projekt. Wracając do roli pośrednika, ta rola pośrednika ogranicza się do kolokwialnie mówiąc przezroczystego kopiowania danych z i na ekran. W szczególnych przypadkach w ramach tego kopiowania możemy przewidzieć operację konwersji, np. format daty w zależności od języka naturalnego używanego przez użytkownika interfejsu. Dodatkowo interfejs GUI musi być odpowiedzialny za uruchamianie odpowiedniej funkcjonalności w reakcji na polecenia użytkownika.

Funkcjonalność do scenariusza, w którym XAML jest tylko przezroczystym przekaźnikiem danych została zaimplementowana w technologii WPF. Żeby przekazywać dane, to najpierw trzeba je pobrać z jakiegoś źródła. Tu nie mamy wielkiego wyboru, to muszą być obiekty, a właściwie ich właściwości – properties – opisane typami. Ponieważ te typy muszą już być związane z przetwarzaniem danych procesowych, więc ich definicja jest dedykowana do potrzeb tego procesu, więc nasza i znajduje się w projekcie GraphicalData do którego projekt zawierający View ma referencje. Jednak Microsoft implementując WPF – a konkretnie mechanizm kopiowania - tych typów nie mógł znać. Transfer danych w WPF jest mechanizmem generycznym, więc nie może odwoływać się do konkretnych typów, mimo, że może mieć referencje do tych typów. To prowadzi do wniosku, że nie możemy w tym procesie korzystać z definicji typów, więc cóż zostaje tylko refleksja, co nas nie specjalnie powinno zmartwić, bo to nie my musimy jej używać, a w konsekwencji jej znać.

## Obsługa widoku poprzez powiązania

### Sprzęganie kontrolek z danymi

Popatrzmy na przykład. W prawym dolnym rogu okienka używamy kontrolki typu TextBox. Jej zadaniem jest wypisywać i ewentualnie czytać tekst, czyli ciąg znaków. Aktualna wartość, więc to co jest na ekranie jest dostępne za pośrednictwem właściwości Text. Ponieważ oczekujemy czytania i pisania więc znak równości za nazwą Text musi oznaczać transferuj aktualną wartość do/z wybranego miejsca. Wiemy już, że tym wybranym miejscem musi być właściwość jakiegoś obiektu. Słowo `Binding` możemy przetłumaczyć na powiąż, więc prawdopodobnie ActionText jest to właściwość zdefiniowana w jakimś naszym typie. Spróbujmy ten typ znaleźć korzystając z nawigacji w menu kontekstowym Visual Studio. Jak widzimy to działa i właściwość ma faktycznie nazwę zgodną z oczekiwaniami.

### DataContext

Jak widać nawigacja działa, czyli VisualStudio nie ma wątpliwości z jakiego typu pochodzi ta właściwość. Skoro Visual Studio to wie, to chyba my też powinniśmy wiedzieć. Odpowiedź na to pytanie znajduje się w tych trzech linijkach tekstu. Zacznijmy od środkowej, w której mamy pełną nazwę klasy z tym, że przestrzeń nazw została zastąpiona przez dwuliterowy alias vm zdefiniowany zresztą kilka linijek wyżej. Niestety tym razem nawigacja do definicji nie działa, ale definicja klasy jest otwarta w wyniku wcześniejszego poszukiwania właściwości zawierającej tekst do kontrolki TextBox. Zastanówmy się co oznacza nazwa klasy w tym miejscu. Aby uprościć sprawę, najpierw poszukajmy znaczenia identyfikatora DataContext. Jest to właściwość typu object, więc typu bazowego dla wszystkich typów. Skoro właściwość to możemy tylko odczytać lub podstawić do niej jakąś wartość. Odrzuciwszy wszystkie absurdalne propozycje, łatwo wydedukować jedyną poprawna odpowiedź, a mianowicie, że identyfikator MainViewModel w tym miejscu oznacza konstruktor bezparametrowy, a cały ten fragment należy rozumieć jako ekwiwalent instrukcji podstawienia do właściwości DataContext nowo utworzonego z wykorzystaniem tego konstruktora obiektu. Obiekt ten możemy uważać jednocześnie za źródło i repozytorium danych procesowych dedykowanych dla GUI, innymi słowy to rodzaj repliki GUI. Z punktu widzenia danych tworzy on rodzaj repliki tego co jest na ekranie.

### Binding

Wróćmy jeszcze do poprzedniego przykładu z kontrolką TextBox i sprzężenia jej właściwości Text z właściwością ActionText pochodzącą z klasy, której obiekt został podstawiony do DataContext. Występuje tu magiczne słowo `Binding`, które możemy przetłumaczyć transferuj wartość pomiędzy. Na pytanie jak to się dzieje i co oznacza słowo `Binding`, czyli na pytanie o semantykę tego zapisu zwykle otrzymuję odpowiedz: to jakaś magia kina, co należy czytać wewnętrzna implementacja WPF, a `Binding` to słowo kluczowe języka XAML. I to tłumaczenie byłoby wystarczające, choć jest to kolokwializm, gdyby nie fakt, że musimy zrozumieć, kiedy ten transfer ma miejsce. Odpowiedź na to pytanie jest fundamentalna do zrozumienia wymagań dla klas, które mogą być wykorzystane do utworzenia obiektu, którego referencja jest podstawiana do właściwości `DataContext`. Aby znaleźć odpowiedź spróbujmy przejść do definicji tego słowa używając menu kontekstowego lub klawisza F12.

### DataBinding – użycie refleksji

Okazuje się, że `Binding` jest identyfikatorem klasy, a właściwie bezparametrowego konstruktora tej klasy. To w konsekwencji musi oznaczać, że w tym miejscu magia kina oznacza utworzenie obiektu typu Binding, który odpowiada za transfer wartości z jednej właściwości do drugiej. Właściwości zdefiniowane w tym  typie pozwalają na sterowanie sposobem realizacji tego transferu. Tu możemy zobaczyć ich listę. Ponieważ obiekt ten musi operować na nieznanych typach wykorzystywana jest refleksja. To powoduje, że mechanizm ten rzadko jest analizowany w szczegółach i kolokwialne tłumaczenie poprzednio przytoczone, że transfer jest jakoś realizowany jest dość powszechne, bo ma swoje zalety w kontekście opisu skutku. W ramach pracy domowej proponuję stworzyć definicję klasy, która zasymiluje to działanie i dostarczy funkcjonalność podstawiania wybranej wartości do wskazanej właściwości obiektu, którego typ nie jest znany.

### INotifyPropertyChange

Jak wspomniałem wcześniej używając właściwości zdefiniowanych w typie `Binding` możemy parametryzować przebieg transferu i na przykład ograniczyć jego kierunek. Operacje, które są opisane tekstem XAML są realizowane jednorazowo na początku programu, kiedy obiekt MainWindow jest tworzony. Nie możemy zatem określić tu chwil czasowych, w których ten transfer powinien być realizowany. Aby określić te chwile czasowe, w której obiekt typu Binding powinien dokonać tego transferu prześledźmy budowę właściwości ActionText pochodzącej z naszego typu. Tu widzimy, że seter oprócz podstawienia wartości do lokalnego pola wykonuje dwie metody. W kontekście postawionego problemu dla nas istotne jest wywołanie metody RaisePropertyChanged. Metoda ta aktywuje zdarzenie - event, który jest wymagany do zaimplementowania interfejsu INotifyPropertyChanged. Właśnie to zdarzenie wykorzystywane jest przez obiekty klasy Binding do rozpoczęcia transferu wartości. Aktywując to zdarzenie wywołujemy metody zwane handlerami, których delegaty zostały zasubskrybowane do zdarzenia, czyli to my dokonujemy pośrednio tego transferu za pośrednictwem tych handlerów. Jeśli klasa nie implementuje tego interfejsu lub jeśli taka aktywacja zdarzenia PropertyChanged wymaganego przez wspomniany interfejs nie nastąpi, nowa wartość nie zostanie przekazana i nie będzie wyświetlona na ekranie – ekran będzie statyczny.

### ICommand

Analiza poprzednich przykładów pokazuje działanie mechanizmu synchronizacji zawartości ekranu z wartościami właściwości klas dedykowanych do udostępniania danych na potrzeby GUI, które tworzą rodzaj pamięciowej repliki ekranu. Teraz musimy jeszcze tylko wyjaśnić sekwencję operacji realizowanych w konsekwencji wydania polecenia przez użytkownika interfejsu, np. kliknięcia na klawisz ekranowy - `Button`. Przykład mamy tu, a jego właściwość `Command` została podobnie jak poprzednio skojarzona z czymś o identyfikatorze `ShowTreeViewMainWindowCommend`. Korzystając z nawigacji w Visual Studio możemy przejść do definicji tego identyfikatora i zauważamy, że jest to znowu właściwość z naszej klasy, ale tym razem typu `ICommand`. Tym razem to powiązanie nie służy to kopiowania wartości właściwości, tylko do zamiany kliknięcia klawisza na ekranie, np. z wykorzystaniem myszki, na wywołanie operacji `Execute`, która jest zdefiniowana w interfejsie `ICommand` i zatem musi być zaimplementowana w klasie, która służy do utworzenia obiektu i podstawienia referencji do niego do tej właściwości.

### RelayCommand

Dla ułatwienia ten interfejs został zaimplementowany przez klasę pomocniczą o nazwie `RelayCommand`. W konstruktorze tej klasy należy umieścić delegację do metody, która ma być wywołana w wyniku realizacji polecenia. W ramach pracy domowej proszę prześledzić zastosowanie drugiego konstruktora. Ten konstruktor jest pomocny w dynamicznej zmianie stanu aktywności klawisza. Można to wykorzystać, aby uwzględnić zdarzenia przeszłe do ewentualnego blokowania zdarzeń przyszłych, czyli zrealizować maszynę stanu. I właśnie taki scenariusz w przykładowym programie został zaimplementowany. Proszę zwrócić tu uwagę na pominiętą w poprzedniej analizie metodę  `RaiseCanExecuteChanged`.

## Model warstwowy

### Model Warstwowy Wprowadzenie

Kolejnym tematem tej lekcji jest **warstwowy model** architektoniczny nazwany mvvm. Ten skrót pochodzi od angielskiego model, view, view-model, czyli model, widok i model widoku. Zgodnie z dobrymi praktykami inżynierii program powinien być skonstruowany z wykorzystaniem warstw. Warstwa to pojęcie abstrakcyjne i charakteryzuje się tym, że w takim modelu warstwy wyższe odwołują się wyłącznie do warstwy sąsiedniej leżącej poniżej.

Innymi słowy będziemy mówić o architekturze programu. Tu niestety często spotykam się z praktyką lekceważenia zasad warstwowej budowy programu, bo to komplikuje, bo to ogranicza, bo bez tego jest łatwiej i da się żyć, itd. Zauważmy, że mamy tu trzy istotnie różniące się światy. Pierwszy to model wymieniony w temacie, czyli mvvm. Oznak jego bytności jeszcze nie widzimy, ale pojawił się on w kontekście inżynierii tworzenia graficznego interfejsu użytkownika. Drugi, to model wielokrotnie używany w trakcie kursu, w którym wyróżniono też trzy warstwy, ale tym razem nazwane prezentacja, logika i dane. Trzeci świat, to całkowity brak warstw. Skoro te światy istnieją, to pewnie za każdym z nich stoją jakieś powody, choćby błahe, jak brak wiedzy. Żeby wykluczyć brak wiedzy, przyjrzyjmy się temu tematowi z bliska.

Zacznijmy od tego, że nasz program przykładowy ma dwa projekty. Pierwszy z przyrostkiem View bazuje na Framework 4.61, więc jest dedykowany dla konkretnej implementacji biblioteki .NET. To ogranicza pole manewru w zakresie jego wykorzystania na innych platformach sprzętowych i systemowych, ale wyjścia nie ma, bo WPF jest technologią dedykowaną dla Windows. Drugi projekt bazuje na .NET Standard. .NET Standard jest abstrakcyjną definicją biblioteki .NET, tzn. nie zawiera żądnej implementacji, a jedynie abstrakcyjne definicje. Dziki temu projekty bazujące na .NET standard są przenośne i raz skompilowana biblioteka może być realizowana na każdej platformie systemowej, dla której istnieje implementacja .NET. Nie wchodząc w szczegóły, zależność pomiędzy tymi projektami możemy zilustrować w następujący sposób. Dla dociekliwych co oznaczają poszczególne strzałki jest legenda. Na potrzeby tej lekcji nas będzie interesował tylko zwrot tych strzałek.

### Czy projekt może być warstwą

Odpowiadając na pytanie co to jest warstwa, spróbujmy zatem postawić tezę, że warstwy powinny być zaimplementowane z wykorzystaniem projektów. Zauważmy, że w poprzedniej lekcji używałem tego samego programu przykładowego, ale wszystko było w jednym projekcie i działało. Generalnie minimalizowanie liczby projektów prowadzi do zmniejszenia kosztów utrzymania, więc jeśli przenośność nie jest wartością dodaną, to może nie warto wydzielać na siłę osobnych projektów. Tu jednak ćwiczymy scenariusz, w który przenośność jest krytyczna, więc rozdzielenie projektu na dwa jest konieczne. Wydzielenie części programu do  osobnego projektu - z punktu widzenia jego semantyki, więc działania - nic nie zmieniło. Tu trzeba podkreślić, że projekt to tylko jednostka organizacyjna w ramach solution. Solution, czyli rozwiązanie i projekt to pojęcie związane z narzędziem jakim jest Visual Studio, a nie z semantyką programu. Tak, czy inaczej używanie projektów do implementacji warstw to nie jest dobry pomysł. Tu jednak ważne zastrzeżenie, tylko dzięki odpowiedniej architekturze programu wydzielenie jego fragmentu do osobnego projektu nie było trudne. Natomiast warunkiem koniecznym, aby ten proces w ogóle był możliwy jest, aby referencje, czyli odwołania do definicji typów były wyłącznie hierarchiczne, ponieważ tylko takie można zdefiniować dla projektów. Z rysunku oraz z gałęzi references i Depencies widać, że w tym przypadku jest to spełnione.

### MVVM jako podwarstwy warstwa prezentacji

Omawiany wzorzec mvvm powstał jako integralna część technologii Windows Presentation Foundation, więc skoro w nazwie mamy słowo presentation, to w kontekście ogólnej architektury, możemy przyjąć, że warstwy modelu mvvm są podwarstwami warstwy prezentacji tego ogólnego modelu architektonicznego. Na podstawie tej analizy szczegółowej spróbujmy jednak odpowiedzieć na bardziej ogólne pytanie: co to jest warstwa i jak ją zaimplementować.

### Diagram View

Analizę realizacji tego wzorca i implementacji warstw model, view, View-Model rozpocznijmy od wygenerowania diagramu pokazującego różne związki występujące w tekście przykładowego programu. Rozpoczynamy od projektu zawierającego tekst opisujący grafikę interfejsu, a więc warstwę View, czyli widok. Przypomnę, że zastała ona zaimplementowana w osobnym projekcie grupującym wszelkie odwołania do technologii WPF, a więc do pewnej grupy typów, których definicja jest osadzona w ściśle określonych realia zewnętrznych w tym przypadku systemu operacyjnego. Wcześniej podobne uzależnienie dotyczyło baz danych, gdzie w trakcie jednej z lekcji wykorzystaliśmy technologię LINQ to SQL dedykowaną dla konkretnego rodzaju baz danych. Na rysunku mamy trzy elementy składowe Folder rozwiązania, projekt i po rozwinięci projektu jego przestrzenie nazw. Umieśćmy na tym rysunku również projekt zawierający tekst pozostałej części programu i rozwińmy go by pokazać jego zawartość. Wracając do implementacji warstwy. W programie, aby abstrakcyjna warstwa była zaimplementowana, musimy wykorzystywać jakąś konstrukcję językową, którą do tego wykorzystamy. Innymi słowy program jest tekstem, więc warstwa musi być jednoznacznie wydzielonym fragmentem tego teksu.

### Porządkowanie diagramu

Przestrzeń nazw jest konstrukcją językową i zawiera wybraną grupę definicji typów, więc wygląda na dobrego kandydata do implementacji warstw. Łatwo jest również wydzielić tekst w ramach wybranej przestrzeni nazw. Zatem korzystając z filtrów usuńmy z diagramu wszystkie elementy organizacyjne związane z narzędziem, a nie ze składnią i semantyką programu. W tym przypadku to jest folder i projekty. Po uporządkowaniu diagramu widzimy, że w tym przypadku warstwy zostały zaimplementowane jako przestrzenie nazw. W ramach przestrzeni nazw tworzących warstwy mogą występować dodatkowe przestrzenie składowe, w których znajdują się definicje typów pomocniczych i tak wewnątrz przestrzeni MVVMLight zdefiniowałem dwie klasy pomocnicze ułatwiające implementację i kontrolę poprawnego wykorzystania tego wzorca i dostarczające potrzebną dla warstwy View-Model funkcjonalność, więc implementację dwóch interfejsów, a mianowicie INotifyPropertyChange i ICommand. Po uporządkowaniu możemy te trzy warstwy wyróżnić.

### Jak Zaimplementować

Korzystając z tego przykładu spróbujmy teraz zdefiniować kilka uproszczonych reguł, których zastosowanie ułatwi implementację wzorca mvvm. Po pierwsze w przestrzeni nazw View należy zgromadzić wyłącznie definicje, które odwołują się do typów zdefiniowanych w PresentationFramework. Dodatkowo te definicje mogą odwoływać się wyłącznie to typów zdefiniowanych w przestrzeni ViewModel. W skrócie tu umieszczamy praktycznie wyłącznie tekst zapisany w języku zaml i puste definicje w code-behind. W przestrzeni ViewModel natomiast definiujemy wszystkie typy, których obiekty podstawiane są do właściwości DataContex wybranych kontrolek. Ucieszenie tu definicji typów pomocniczych pozwalających sprostać wymaganiom stawianym dla tej warstwy jest już opcjonalnie. Z uwagi na uniwersalny charakter tych implementacji często korzystamy tu z zewnętrznych bibliotek. W uproszczeniu warstwa Model to cała reszta. Podkreślę tu jeszcze raz, że mvvm to wzorzec, więc zasady sprzęgania warstw i podział na same warstwy, natomiast całość dotyczy wyłącznie warstwy Prezentacji ogólnej architektury programu.

### Implementacja warstw ogólnej architektury programu

Postępując podobnie w osobnych przestrzeniach nazw możemy gromadzić typy tak, by zachować wyłącznie hierarchiczne odwołania pomiędzy nimi. Zatem błędem krytycznym dla architektury warstwowej jest, jeśli pomiędzy przestrzeniami nazw wystąpią cykliczne odwołania, czyli jeśli rozpoczynając od dowolnej warstwy i poruszając się wydłuż strzałek zależności uda się wrócić do tej samej przestrzeni nazw. Należy również unikać sytuacji, w której przestrzenie nazw nie odwołują się wyłącznie do swoich poniższych sąsiadów. Implementując warstwy z wykorzystaniem przestrzeni nazw musimy natomiast liczyć się z problemem, że tych warstw nie widać w rozwiązaniu gołym okiem. Wydaje się, że kompromisem jest utrzymywanie nazw folderów i przestrzeni nazw w synchronizacji. Związek jest luźny, ale tworząc nową klasę w wybranym folderze jest ona dodawana do przestrzeni nazw, której identyfikator jest utworzony jako hierarchiczne połączenie nazwy domyślnej, nazw folderów tworzących hierarchię i z przyrostkiem określonym przez nazwę końcowego w hierarchii folderu.

### Powody Wprowadzenia Warstw

Na koniec podsumujmy co dostaliśmy w zamian architektury warstwowej. Odseparowanie warstw pozwala na prowadzanie niezależnie prac projektowych. Oczywiście pod warunkiem, że API, czyli interfejs warstwy jest niezmienny. Można to wykorzystać to prowadzenia prac nad GUI i logiką obsługi interfejsu użytkownika równolegle. Korzyści są dwie, możemy zatrudnić specjalistów i skrócić czas opracowywania produktu. Brak odwołań cyklicznych pozwala natomiast lepiej zaplanować ewentualne modyfikacje i zapanować nad efektami ubocznym. W ten sposób można zmniejszyć koszty utrzymania. Często architektura hierarchiczna zestawiana jest w kontrze do architektury typu spaghetti, o ile spaghetti można w ogóle nazwać architekturą. W przykładzie pokazałem jak dzięki warstwom można uniezależnić się od technologii, więc zapewnić możliwość przenoszenia wyników pracy pomiędzy różnymi platformami. Poprawę wydajności procesu projektowania zapewnimy dzięki zastosowaniu zasady separation of concerns, czyli dobre zaplanowanie warstw pozwoli uniknąć rozpraszania się na rozwiązywanie jednocześnie kilku wątków. Warstwy nie tylko mogą być wydzielane do odrębnych projektów, ale realizowane na innych fizycznych maszynach. Przekładem jest farma serwerów WWW stanowiąca front–end dla całego systemu informatycznego, np. Google, Gmail, itp. Jeśli tę samą warstwę będziemy potrafili realizować równolegle na wielu komputerach - jak w tych przykładach - to zapewnimy skalowalność poziomą - horyzontalną. Możliwość realizacji poszczególnych warstw na niezależnych platformach sprzętowych to skalowalność pionowa (wertykalna).

### Wstrzykiwanie zależności View

Jeżeli aplikacja ma być zbudowana zgodnie z modelem MVVM, to tylko w warstwie widoku – view będziemy decydowali o tym jak ma wyglądać okienko. Natomiast w warstwie poniżej będziemy decydować o konieczności jego wyświetlenia. Wyświetlenie kolejnego okienka często nazywanego pop-up jest wynikiem kliknięcia na klawisz okna podstawowego, które to zdarzenie jest obsługiwane w warstwie modelu widoku, która u nas jest w osobnym projekcie. Przypomnę, że okienko to obiekt o jakimś typie. W tym scenariuszu, aż się prosi żeby to View-Model tworzył ten obiekt i go wyświetlał. Czyli w konsekwencji jako element tej obsługi model widoku powinien utworzyć stosowny obiekt okna pop-up i go wyświetlić, ale to wymaga odwołania się do warstwy widoku, a w efekcie prowadzi do zabronionej tu rekurencji. W tym przypadku to nie tylko problem połamania zasad, ale braku możliwości dodania cyklicznego uzależnienia projektów od siebie.

Po uważnym przyjrzeniu się implementacji warstwy widoku w klasie MainWindow zauważamy, że zasadza dotycząca pustego code-behind nie w pełni jest spełniona. Wyjątek, który tu widzimy jest związany wyłącznie z zapewnieniem odprzęgnięcia warstw- czyli zapewnienia hierarchicznych odwołań. Szczegółową analizę pozostawiam jako pracę domową. Przy okazji proszę się zastanowić, w jaki sposób można się pozbyć tego fragmentu programu i faktycznie zapewnić, że code-behind będzie pusty.

## Praca domowa

Na koniec lekcji, jak zwykle, praca domowa.

### Refleksja

W trakcie lekcji mówiliśmy o wykorzystaniu refleksji do transferowania wartości z właściwości obiektu utworzonego na podstawie typu zdefiniowanego w warstwie ViewModel i obiektu zdefiniowanego w warstwie View. Aby lepiej zrozumieć ten mechanizm poproszę o napisanie metody, która podstawia przekazywaną do niej jako parametr wartość do właściwości obiektu, którego nazwa jest drugim parametrem. Oczywiście w tym scenariuszu nie znamy typu obiektu, który zawiera wspomnianą właściwość. Zadanie nie jest łatwe, ale przykład łatwo znaleźć. Aby podnieść poprzeczkę rozwiązanie powinno być genetyczne, a sygnatura metody może wyglądać jakoś tak:

### Wstrzykiwanie zaleznosci

Kolejne zadanie to, dokonać analizy tekstu programu w nadpisanej metodzie OnInitialized w klasie MainWindow w celu określenia celu w jakim ten tekst został tu umieszczony. Wykorzystać podobne podejście do otwarcia i przeczytania zawartości jakiegoś pliku tekstowego w wyniku wydania polecenia Browse w okienku TreeView example. Klawisz Show TreeView powinien stać się aktywny  wyłącznie jeśli operacja czytania pliku się uda. Proszę pamiętać o konieczności wyświetlenia odpowiedniego okienka pytającego użytkownika o ścieżkę do pliku. Przy okazji proszę się zastanowić, w jaki sposób można się pozbyć tego rodzaju operacji z code-behind i zapewnić, że będzie on faktycznie pusty.

### Diagram kontroli zależności

W tym punkcie pracy domowej proszę dodać do tekstu omawianego programu przykładowego diagram kontroli zależności i sprawdzić jaki jest rezultat próby naruszenia korzystania z warstw, czyli próby zastosowania odwołań cyklicznych. Uwaga nie wszystkie wersje Visual Studio wspierają tą funkcjonalność.

## Zakończenie

W tej lekcji to już wszystko. To również ostatnia lekcja kursu. Dziękuję za poświęcony czas. Mam nadzieję, że trud przebrnięcia przez wszystkie przedstawione tu meandry związane z przetwarzaniem danych zewnętrznych przydadzą się w praktyce. Zapraszam do współpracy nad tekstem przykładowego programu, który jest dostępny na GitHub.

-->