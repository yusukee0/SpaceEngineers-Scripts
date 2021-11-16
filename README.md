# !!! Deprecated, probably does not work anymore !!!

# Space Engineers scripts.
## Gravity Drive:
### Ez a script nem igényel időzítőt.
### !!!Az első metódust ( public GravityDrive() ) át kell nevezni public Program() -ra !!!
Működés: 
- A pilótafülkéből toolbarról kell futtatni a scriptet a megfelelő argumentumokkal.
- A Gravity Drive-hoz tartozó gravity generátorok nevébe bele kell írni [Gravity Drive]  (scriptben módosítható)
- A script elején módosítani kell a 2 gravitációs értéket annak megfelelően, hogy merre néznek a gravity generátorok. 

#### Argumentumok: 
- Előre mozgás: direction=forward
- Hátra mozgás: direction=backward
- Gravity Drive kikapcsolása: Üres argumentummal futtatás. !!! Ez nem fogja megállítani a hajót !!!

#### Előre / hátra mozgás:
- Kikapcsolja a tehetetlenségi csillapítást (inertia dampener)
- Kikapcsolja a normáslis gravitációt (minden, ami nem tartozik a gravity drive-hoz)
- Bekapcsolja a Gravity Drive-hoz tartozó gravity generátorokat
- Bekapcsolja a Mesterséges Tömegeket (Artificial Mass)

#### Gravity Drive kikapcsolás
- Bekapcsolja a tehetetlenségi csillapítást (inertia dampener)
- Bekapcsolja a normáslis gravitációt (minden, ami nem tartozik a gravity drive-hoz)
- Kikapcsolja a Gravity Drive-hoz tartozó gravity generátorokat
- Kikapcsolja a Mesterséges Tömegeket (Artificial Mass)
