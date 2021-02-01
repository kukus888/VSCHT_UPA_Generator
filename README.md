# VŠCHT_ÚPA_Generator

Úkol do předmětu Úvod do Programování a algoritmů.

### Nastavení programu
**Rozlišení:** Nastavte rozlišení, které bude soubor generovat. 255\*255 je standartní rozlišení
**Škálování:** Jak velký bude každý pixel. Např 4 řekne, že obrázek bude mít 4\*255 na 4\*255 pixelů, tj. každý *vygenerovaný pixel* bude mít 4\*4 *reálných pixelů*
**Okraj nalevo/ nahoře:** Tato funkce byla implementována kvůli souřadnicovému systému, který jednak nefunguje a jednak trvá dlouho na vypočtení. Stejně jako *Nevyplněné pixely počítat jako* je proto nedůležitý.
**Název:** Název souboru obrázku. Uloží se do stejné složky, ve kterém je umístěn program. Musí mít příponu bmp.

### Pravidla instrukcí
Na každý řádek se dá dát jen jedna instrukce. Řádky by neměly obsahovat mezery. Instrukce nepotřebují mít na konci řádku středník. Program na konci instrukcí nastaví barvu pixelu jako hodnotu uloženou v proměnné ```a```. Například:
```a=sin(x)```
(konec) => stupeň šedi se nastaví jako sinus pozice x pixelu.

### Proměnné
```a``` – Nastaví na konci instrukcí pixel na tento odstín šedi
```b``` –Podivná proměnná, sám přesně nevím, jak funguje, souvisí spřeskakováním řádků u funkce if, prosím nepoužívat. Měl by fungovat tak, že pokud nastavíte b na 1, jeden řádek se přeskočí
```c, d, e, f``` – Proměnné volné kpoužití.
```x, y``` jsou speciální, určují pozici pixelu.
Přiřazení probíhá následovně:
```a=(funkce, nebo proměnná)```, například: ```a=b```, nebo ```a=sin(x)```

Lze taky přistupovat k barvám (stupním šedi) ostatních pixelů pomocí hranatých závorek:
```a=\[-1,-4]```
přiřadí do hodnoty a hodnotu pixelu, který se nachází o 1 px vlevo a 4 px nahoru.

Upozornění!
Pozitivní hodnoty v hranatých závorkách nemají úplně smysl, počítalo by se pak s přednastavenou barvou. To samé platí o \[0,0].

### Matematické funkce
```sin()``` –Funkce sinus
```cos()``` –Funkce cosinus
```tan()``` –funkce tangens
```cotg()``` –Funkce kotangens
```sgn()``` –Funkce signum
if: Jedna z funkcí na kterou jsem obzvlášť pyšný je umožnění zpracovávání podmínek. Funguje následovně:
if(výrok) kdy pokud je výrok pravda, vykoná se JEDEN následující řádek. Pokud výrok není pravda, řádek se přeskočí. Typy výroků: == <= >= != < >
Poznámka: nechávejte mezeru mezi proměnnou a operátorem, aby si program nemyslel, že chcete přiřazovat proměnnou:
```if(a==x)``` –Špatně
```if(a == x)``` –Správně

### Počítání
Program také umí základní počítání, tj. + - \* / a %. Použít ho můžete následovně:
```
a=x%2
f=2-y\*c
d=(e\*e)-4
```
K tomuto se váže další omezení. Prosím používejte operátory „v rámci jedněch závorek“. Program funguje tak, že rozdělí vstupní instrukci podle operátoru, což může vněkterých případech (třeba ```a=sin(x\*4)-y\*2```) vyhodit chybu. Prosím rozepište vtakovýchto případech instrukce na více řádků.

### Souřadnice
Program stále podporuje souřadnicový systém a referování na ostatní pixely. Nicméně nefunguje spolehlivě (prosím nepoužívat). Syntax je následující:
```
a=[-1;0]
```
Tento kód vezme odstín šedi nalevo a uloží ho do proměnné a.

```
